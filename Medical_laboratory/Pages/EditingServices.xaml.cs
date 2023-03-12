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
    /// Логика взаимодействия для EditingServices.xaml
    /// </summary>
    public partial class EditingServices : Page
    {
        public bool isEmployeeForManager;
        Service thisService;
        public EditingServices(Service service, bool isEmployee)
        {
            InitializeComponent();
            isEmployeeForManager = isEmployee;
            serviceTextBox.Text = service.NameOfService;
            priceTextBox.Text = service.Price.ToString();
            thisService = service;
        }

        private void Click_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.frame.Navigate(new ViewServices(isEmployeeForManager));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            if (serviceTextBox.Text != "" && priceTextBox.Text != "")
            {
                try
                {
                    for (int i = 0; i < services.Count; i++)
                    {
                        if (services[i].NameOfService == thisService.NameOfService)
                        {
                            services[i].NameOfService = serviceTextBox.Text;
                            services[i].Price = Convert.ToDecimal(priceTextBox.Text);
                            db.SaveChanges();
                            Manager.frame.Navigate(new ViewServices(isEmployeeForManager));
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте формат введенных данных");
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                db.Services.Remove(thisService);
                db.SaveChanges();
                Manager.frame.Navigate(new ViewServices(isEmployeeForManager));
            }
        }
    }
}
