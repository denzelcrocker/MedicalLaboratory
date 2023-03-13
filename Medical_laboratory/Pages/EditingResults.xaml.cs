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
    /// Логика взаимодействия для EditingResults.xaml
    /// </summary>
    public partial class EditingResults : Page
    {
        public bool isEmployeeForManager;
        Result thisResult;
        public EditingResults(Result result, bool isEmployee)
        {
            InitializeComponent();
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
            isEmployeeForManager = isEmployee;
            UserComboBox.Text = db.Users.ToList().Where(x => x.UserId == result.UserId).FirstOrDefault().Name;
            EmployeeComboBox.Text = db.Employees.ToList().Where(x => x.EmployeeId == result.EmployeeId).FirstOrDefault().Name;
            ServiceComboBox.Text = db.Services.ToList().Where(x => x.ServiceId == result.ServiceId).FirstOrDefault().NameOfService;
            ResultTextBox.Text = result.Result1;
            DateAdd.Text = Convert.ToString(result.Date);
            thisResult = result;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserComboBox.Text != "" && EmployeeComboBox.Text != "" && ServiceComboBox.Text != "" && ServiceComboBox.Text != "" && ResultTextBox.Text != "" && DateAdd.Text != "")
            {
                try
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        if (results[i].ResultId == thisResult.ResultId)
                        {
                            results[i].UserId = db.Users.ToList().Where(x => x.Name == UserComboBox.Text).FirstOrDefault().UserId;
                            results[i].EmployeeId = db.Employees.ToList().Where(x => x.Name == EmployeeComboBox.Text).FirstOrDefault().EmployeeId;
                            results[i].ServiceId = db.Services.ToList().Where(x => x.NameOfService == ServiceComboBox.Text).FirstOrDefault().ServiceId;
                            results[i].Result1 = ResultTextBox.Text;
                            results[i].Date = Convert.ToDateTime(DateAdd.Text);
                            db.SaveChanges();
                            Manager.frame.Navigate(new ViewResults(isEmployeeForManager));
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте формат введенных данных");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                db.Results.Remove(thisResult);
                db.SaveChanges();
                Manager.frame.Navigate(new ViewResults(isEmployeeForManager));
            }
        }

        private void Click_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.frame.Navigate(new ViewResults(isEmployeeForManager));
        }
    }
}
