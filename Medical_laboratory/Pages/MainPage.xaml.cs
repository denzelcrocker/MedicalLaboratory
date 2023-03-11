using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medical_laboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage(bool isEmployee)
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            if(isEmployee == true)
            {
                string roleOfEmployee = db.Roles.ToList().Where(x => x.RoleId == employee.RoleId).FirstOrDefault().NameOfRole;
                userInfo.Text = $"{roleOfEmployee}: {employee.Name}";
            }
            else
            {
                userInfo.Text = $"Пациент: {user.Name}";
            }

        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.frame.Navigate(new Autorization());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginHistory loginHistory = new LoginHistory();
            loginHistory.Show();
        }

        private void Button_Services_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new ViewServices());
        }

        private void Button_Results_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new ViewRezults());
        }
    }
}
