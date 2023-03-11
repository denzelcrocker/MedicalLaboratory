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
using System.Windows.Threading;


namespace Medical_laboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewServices.xaml
    /// </summary>
    public partial class ViewServices : Page
    {
        Switching switching = new Switching();
        public ViewServices()
        {
            
            InitializeComponent();
            DataContext = switching;
            int countOfServices = db.Services.Count();
            services = db.Services.ToList();
            switching.CountPage = 8;
            switching.Countlist = countOfServices;
            LViewTours.ItemsSource = services.Skip(0).Take(switching.CountPage).ToList();

        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "Back":
                    switching.CurrentPage--;
                    break;
                case "Next":
                    switching.CurrentPage++;
                    break;
                case "InStart":
                    switching.CurrentPage = 1;
                    break;
                case "InEnd":
                    {
                        int countOfServices = db.Services.Count();
                        int a = countOfServices;
                        int b = Convert.ToInt32(3);

                        if (a % b == 0)
                        {
                            switching.CurrentPage = a / b;
                        }
                        else
                        {
                            switching.CurrentPage = a / b + 1;
                        }

                    }
                    break;
                default:
                    switching.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            LViewTours.ItemsSource = services.Skip(switching.CurrentPage * switching.CountPage - switching.CountPage).Take(switching.CountPage).ToList();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            services = db.Services.ToList();
            services = services.Where(p => p.NameOfService.ToLower().Contains(search.Text.ToLower())).ToList();
            switching.CurrentPage = 3;
            switching.Countlist = services.Count;
            LViewTours.ItemsSource = services.Skip(0).Take(switching.CountPage).ToList();

        }
    }
}
