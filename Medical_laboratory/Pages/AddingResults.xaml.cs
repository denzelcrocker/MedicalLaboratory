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
    /// Логика взаимодействия для AddingResults.xaml
    /// </summary>
    public partial class AddingResults : Page
    {
        public bool isEmployeeForManager;
        public AddingResults(bool isEmployee)
        {
            InitializeComponent();
            isEmployeeForManager = isEmployee;
            foreach (var item in db.Users.ToList())
            { 
                UserComboBox.Items.Add(item.Name);
            }
            foreach (var item in db.Employees.ToList())
            { 
                EmployeeComboBox.Items.Add(item.Name);
            }
            foreach (var item in db.Services.ToList())
            {
                ServiceComboBox.Items.Add(item.NameOfService);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserComboBox.Text != "" && EmployeeComboBox.Text != "" && ServiceComboBox.Text != "" && ResultTextBox.Text != "")
                {
                    List<Result> results = new List<Result> { new Result() };
                    results[0].UserId = db.Users.ToList().Where(x => x.Name == UserComboBox.Text).FirstOrDefault().UserId;
                    results[0].EmployeeId = db.Employees.ToList().Where(x => x.Name == EmployeeComboBox.Text).FirstOrDefault().EmployeeId;
                    results[0].ServiceId = db.Services.ToList().Where(x => x.NameOfService == ServiceComboBox.Text).FirstOrDefault().ServiceId;
                    results[0].Result1 = ResultTextBox.Text;
                    results[0].Date = Convert.ToDateTime(DateAdd.Text);
                    db.Results.Add(results[0]);
                    db.SaveChanges();
                    Manager.frame.Navigate(new ViewResults(isEmployeeForManager));
                }
            }
            catch (Exception)
            {
            }
        }

        private void Click_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.frame.Navigate(new ViewResults(isEmployeeForManager));

        }
    }
}
