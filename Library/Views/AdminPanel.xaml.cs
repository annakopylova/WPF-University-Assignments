using BLL;
using DAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        IDatabase dbOperations = new DatabaseAPI(IocKernel.Get<IDatabase>());//создает объект бизнес логики
        User currentUser = new User();
        List<User> users = new List<User>();//список пользователей

        public AdminPanel(User user)//получаем сюда пользователя и ставим текущего пользователя этим пользователем
        {
            InitializeComponent();
            currentUser = user;
            GetUsers();
        }

        private void GetUsers()
        {
                
            listUsers.Items.Clear();//очищем визуальный список всех пользователей (элемент на формочке)
            if (dbOperations.CheckAdminRole(currentUser.Login, currentUser.Password))
                //еще раз проверяем права пользователя
            {
                users = dbOperations.GetUsers();//получаем с бд пользователей
                foreach (User user in users)
                {
                    listUsers.Items.Add(user);//заполняем формочку пользователей
                }
            }
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)//обработка клика
        {
            foreach (User user in users)//обновляется пользователь
            {
                
                dbOperations.UpdateUser(user);
                
            }
        }
    }
}
