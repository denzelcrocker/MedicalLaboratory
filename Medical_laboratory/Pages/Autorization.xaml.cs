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
using Microsoft.EntityFrameworkCore;
using System.Windows.Shapes;
using Medical_laboratory.Entities;
using System.Net;
using System.Diagnostics;

namespace Medical_laboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public int countForCapcha = 3;
        DateTime date;
        public Autorization()
        {
            InitializeComponent();
            password1.Visibility = Visibility.Hidden;
            closedEye.Visibility = Visibility.Hidden;
            date = DateTime.Now;
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void closedEye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            password.Visibility = Visibility.Visible;
            password1.Visibility = Visibility.Hidden;
            openEye.Visibility = Visibility.Visible;
            closedEye.Visibility = Visibility.Hidden;
            password.Password = password1.Text;
        }
        private void openEye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            password.Visibility = Visibility.Hidden;
            password1.Visibility = Visibility.Visible;
            openEye.Visibility = Visibility.Hidden;
            closedEye.Visibility = Visibility.Visible;
            password1.Text = password.Password;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            History history = new History();
            string hostName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            bool isEmployee = false;
            bool checkAutorization = false;
            string userLogin = login.Text;
            string userPassword = password.Password;
            int countOfUsers = db.Users.Count();
            int countOfEmployees = db.Employees.Count();
            employees = db.Employees.ToList();
            users = db.Users.ToList();
            for (int i = 0; i < countOfEmployees; i++)
            {
                if (employees[i].Login == userLogin && employees[i].Password == userPassword)
                {
                    isEmployee = true;
                    checkAutorization = true;
                    employee = employees[i];
                    history.Login = userLogin;
                    history.Date = date;
                    history.Ip = Convert.ToString(addresses[1]);
                    db.Histories.Add(history);
                    db.SaveChanges();
                    Manager.frame.Navigate(new MainPage(isEmployee));
                }
            }
            for (int i = 0; i < countOfUsers; i++)
            {
                if (users[i].Login == userLogin && users[i].Password == userPassword)
                {
                    checkAutorization = true;
                    user = users[i];
                    history.Login = userLogin;
                    history.Date = DateTime.Now;
                    history.Ip = Convert.ToString(addresses[1]);
                    db.Histories.Add(history);
                    db.SaveChanges();
                    Manager.frame.Navigate(new MainPage(isEmployee));
                }
            }
            if (checkAutorization == false)
            {
                if (countForCapcha == 0)
                {
                    countForCapcha = 3;
                    MessageBox.Show("Попытки закончились");
                    Manager.frame.Navigate(new CheckCapcha());
                }
                else
                {
                    MessageBox.Show($"Неверный логин или пароль, осталось попыток: {countForCapcha}");
                    countForCapcha--;
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Registration());
        }
    }
}
