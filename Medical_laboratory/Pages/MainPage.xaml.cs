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
        public bool isEmployeeForManager;

        public MainPage(bool isEmployee)
        {
            InitializeComponent();
            isEmployeeForManager = isEmployee;
            if (isEmployee == true)
            {
                string roleOfEmployee = db.Roles.ToList().Where(x => x.RoleId == employee.RoleId).FirstOrDefault().NameOfRole;
                userInfo.Text = $"{roleOfEmployee}: {employee.Name}";
                if (db.Roles.ToList().Where(x => x.RoleId == employee.RoleId).FirstOrDefault().NameOfRole == "Администратор")
                    HistoryButton.Visibility = Visibility.Visible;
                isEmployeeForManager = isEmployee;
            }
            else
            {
                userInfo.Text = $"Пациент: {user.Name}";
                isEmployeeForManager = isEmployee;
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
            Manager.frame.Navigate(new ViewServices(isEmployeeForManager));
        }

        private void Button_Results_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new ViewResults(isEmployeeForManager));
        }
    }
}
