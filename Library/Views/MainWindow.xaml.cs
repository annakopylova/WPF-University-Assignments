using BLL;
using DAL;
using Library.Views;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDatabase dbOperations = new DatabaseAPI(IocKernel.Get<IDatabase>());

        List<Visit> visits = new List<Visit>();
        User user;

        public MainWindow(User user) //конструктор окна читательского билета
        {
            InitializeComponent();
            this.user = user;
            if (user.Admin)
            {
                adminBtn.Visibility = Visibility.Visible; //если пользователь админ, то кнопка админ панель видима
            }
            else
            {
                adminBtn.Visibility = Visibility.Hidden;
            }
            
            if (user is Visitor)//если студент, то показывается вот это
            {
                studentGrid.Visibility = Visibility.Visible;
                employerGrid.Visibility = Visibility.Hidden;
                if (user.FIO.Equals(""))
                {
                    FIO.Content = user.FIO;
                } else
                {
                    FIO.Content = user.Login;
                }
                group.Content += (user as Visitor).Age.ToString();
                course.Content += (user as Visitor).Height.ToString();
                faculty.Content += (user as Visitor).Weight.ToString();
                registrationPacket.Content += (user as Visitor).SubscriptionFinish.ToString();
            }
            
            GetVisits();
        }

        private void AddVisit_Click(object sender, RoutedEventArgs e)//метод нажатия на кнопку добавления книги
        {
            Visit visit = new Visit();
            visit.UserId = user.Id;
            dbOperations.AddVisits(visit);
            GetVisits();
        }

        private void GetVisits()
        {

            listVisits.Items.Clear();
            visits = dbOperations.GetVisits(user);
            foreach (Visit visit in visits)
            {
                listVisits.Items.Add(visit);
            }
            
        }

        private void ListVisit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
                if (listVisits.SelectedIndex > 0 && listVisits.SelectedIndex < listVisits.Items.Count)
                    //если выбраная книга находится в списке книг (проверка на валидность данных)
                {
                    EditVisit editVisitScreen = new EditVisit(user, listVisits.Items[listVisits.SelectedIndex] as Visit);
                    //получение посещения из списка посещений по выбранному адресу
                    editVisitScreen.Owner = this;//указывает на родительское окно
                    editVisitScreen.ShowDialog();
                    GetVisits();
                    
                }
            
            
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(user);
            adminPanel.Owner = this;
            adminPanel.Show();
        }
    }
}
