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
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Medical_laboratory.CurrentList;
using Medical_laboratory.Entities;

namespace Medical_laboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            string name = nameOfUser.Text;
            string login = loginOfUser.Text;
            string password = passwordOfUser.Text;
            string passwordRepeat = passwordRepeatOfUser.Text;
            if (login != "" && name != "" && password != "" && passwordRepeat != "" && password == passwordRepeat)
            {
                string hostName = Dns.GetHostName();
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);

                int countOfUsers = db.Users.Count();
                User user = new User();
                user.Name = name;
                user.Login = login;
                user.Password = password;
                user.UserIp = Convert.ToString(addresses[1]);
                db.Users.Add(user);
                db.SaveChanges();
                Manager.frame.Navigate(new Autorization());
            }
            else
            {
                MessageBox.Show("Введены некорректные данные");
            }
        }
    }
}
