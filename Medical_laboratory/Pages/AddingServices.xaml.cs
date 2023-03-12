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
    /// Логика взаимодействия для AddingServices.xaml
    /// </summary>
    public partial class AddingServices : Page
    {
        public bool isEmployeeForManager;
        public AddingServices(bool isEmployee)
        {
            InitializeComponent();
            isEmployeeForManager = isEmployee;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceTextBox.Text != "" && priceTextBox.Text != "")
            {
                List<Service> services = new List<Service> { new Service() };
                services[0].NameOfService = serviceTextBox.Text;
                    services[0].Price = Convert.ToDecimal(priceTextBox.Text);
                    db.Services.Add(services[0]);
                    db.SaveChanges();
                    Manager.frame.Navigate(new ViewServices(isEmployeeForManager));
            }
        }
        private void Click_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.frame.Navigate(new ViewServices(isEmployeeForManager));

        }
    }
}
