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
    /// Логика взаимодействия для AddBookScreen.xaml
    /// </summary>
    public partial class EditVisit : Window
    {
        IDatabase dbOperations = new DatabaseAPI(IocKernel.Get<IDatabase>());
        User savedUser;
        Visit savedVisit;

        public EditVisit(User user, Visit visit)//конструктор
        {
            InitializeComponent();//создает компоненты
            savedUser = user;
            savedVisit = visit;
            if (!savedUser.Admin)
            {
                deleteVisit.Visibility = Visibility.Hidden;
            }
            comments.Text = savedVisit.VisitNotes;
        }

        private void DeleteVisit_Click(object sender, RoutedEventArgs e)
        {
            if(dbOperations.CheckAdminRole(savedUser.Login, savedUser.Password))
            {
                dbOperations.DeleteVisit(savedVisit);
            }
        }

        private void AddVisit_Click(object sender, RoutedEventArgs e)
        {
            if (comments.Text != String.Empty && !comments.Text.Equals(savedVisit.VisitNotes))
               // берем текст из поля названивание и сравниваем, не пустые ли поля
            {
                Visit newVisit = new Visit(savedVisit);
                newVisit.VisitNotes = comments.Text;
                dbOperations.UpdateVisit(savedVisit, newVisit);
                Close();//и закрываем элемент
            }
            else
            {
                Close();
            }
        }
    }
}
