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

namespace Medical_laboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginHistory.xaml
    /// </summary>
    public partial class LoginHistory : Window
    {
        public static List<History> histories = new List<History>();
        public LoginHistory()
        {
            InitializeComponent();
            histories = db.Histories.ToList();
            GridHistory.ItemsSource= histories;
        }
    }
}
