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
    /// Логика взаимодействия для ViewResults.xaml
    /// </summary>
    public partial class ViewResults : Page
    {
        public List<Result> currentResults;
        public IEnumerable<Service> currentList = services;
        Switching switching = new Switching();
        public bool isEmployeeForManager;
        public ViewResults(bool isEmployee)
        {
            InitializeComponent();
            if (isEmployee == true)
            {
                Add.Visibility = Visibility.Visible;
                isEmployeeForManager = isEmployee;
                DataContext = switching;
                int countOfResults = db.Results.Count();
                results = db.Results.ToList();
                currentResults = results;
                switching.CountPage = 8;
                switching.Countlist = countOfResults;
                LViewTours.ItemsSource = currentResults.Skip(0).Take(switching.CountPage).ToList();
                currentResults = results;
            }
            else
            {
                isEmployeeForManager = isEmployee;
                DataContext = switching;
                currentResults = db.Results.ToList();
                for (int i = 0; i < currentResults.Count; i++)
                {
                    if (currentResults[i].UserId != db.Users.ToList().Where(x => x.Name == user.Name).FirstOrDefault().UserId)
                    {
                        currentResults.RemoveAt(i);
                        i--;
                    }
                }
                int countOfResults = currentResults.Count();
                switching.CountPage = 8;
                switching.Countlist = countOfResults;
                LViewTours.ItemsSource = currentResults.Skip(0).Take(switching.CountPage).ToList();
            }


            //InitializeComponent();
            //if (isEmployee == true)
            //{
            //    Add.Visibility = Visibility.Visible;
            //}

            //isEmployeeForManager = isEmployee;
            //DataContext = switching;
            //int countOfResults = db.Results.Count();
            //results = db.Results.ToList();
            //switching.CountPage = 8;
            //switching.Countlist = countOfResults;
            //LViewTours.ItemsSource = results.Skip(0).Take(switching.CountPage).ToList();
            //currentResults = results;

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
                        int countOfServices = currentResults.Count();
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
            LViewTours.ItemsSource = currentResults.Skip(switching.CurrentPage * switching.CountPage - switching.CountPage).Take(switching.CountPage).ToList();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "" && LViewTours != null)
            {
                var searchName = currentResults.Where(p => p.Service.NameOfService.ToLower().Contains(search.Text.ToLower())).ToList();
                switching.CurrentPage = 3;
                switching.Countlist = searchName.Count;
                LViewTours.ItemsSource = searchName.Skip(0).Take(switching.CountPage).ToList();
            }
            else if (LViewTours != null)
            {
                var current = currentResults.ToList();
                switching.CurrentPage = 3;
                switching.Countlist = current.Count;
                LViewTours.ItemsSource = current.Skip(0).Take(switching.CountPage).ToList();
            }

            if (search.Text != "" && LViewTours != null)
            {
                var searchName = currentResults.Where(p => p.User.Name.ToLower().Contains(search.Text.ToLower())).ToList();
                switching.CurrentPage = 3;
                switching.Countlist = searchName.Count;
                LViewTours.ItemsSource = searchName.Skip(0).Take(switching.CountPage).ToList();
            }
            else if (LViewTours != null)
            {
                var current = currentResults.ToList();
                switching.CurrentPage = 3;
                switching.Countlist = current.Count;
                LViewTours.ItemsSource = current.Skip(0).Take(switching.CountPage).ToList();
            }

        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new MainPage(isEmployeeForManager));
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var track = ((ListView)sender).SelectedItem as Result;
            if (track != null && employee != null && isEmployeeForManager == true)
            {
                Manager.frame.Navigate(new EditingResults(track, isEmployeeForManager));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new AddingResults(isEmployeeForManager));
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        private void PremierFilter_Click(object sender, RoutedEventArgs e)
        {
            //currentServices = currentServices.Where(p => p.NameOfService.ToLower().Contains(search.Text.ToLower())).ToList();
            //for (int i = 0; i < currentServices.Count; i++)
            //{
            //    if (currentServices[i].Price >= 300)
            //    {
            //        currentServices.RemoveAt(i);
            //        i--;
            //    }
            //}
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentServices.Skip(0).Take(switching.CountPage).ToList();
        }

        private void SecondFilter_Click(object sender, RoutedEventArgs e)
        {
            //currentServices = currentServices.Where(p => p.NameOfService.ToLower().Contains(search.Text.ToLower())).ToList();
            //for (int i = 0; i < currentServices.Count; i++)
            //{
            //    if (currentServices[i].Price < 300 || currentServices[i].Price >= 700)
            //    {
            //        currentServices.RemoveAt(i);
            //        i--;
            //    }
            //}
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentServices.Skip(0).Take(switching.CountPage).ToList();
        }

        private void ThirdFilter_Click(object sender, RoutedEventArgs e)
        {
            //currentServices = currentServices.Where(p => p.NameOfService.ToLower().Contains(search.Text.ToLower())).ToList();
            //for (int i = 0; i < currentServices.Count; i++)
            //{
            //    if (currentServices[i].Price < 700 || currentServices[i].Price >= 1000)
            //    {
            //        currentServices.RemoveAt(i);
            //        i--;
            //    }
            //}
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentServices.Skip(0).Take(switching.CountPage).ToList();
        }

        private void FourthFilter_Click(object sender, RoutedEventArgs e)
        {
            //currentServices = currentServices.Where(p => p.NameOfService.ToLower().Contains(search.Text.ToLower())).ToList();
            //for (int i = 0; i < currentServices.Count; i++)
            //{
            //    if (currentServices[i].Price < 1000)
            //    {
            //        currentServices.RemoveAt(i);
            //        i--;
            //    }
            //}
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentServices.Skip(0).Take(switching.CountPage).ToList();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            //currentServices = db.Services.ToList();
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentServices.Skip(0).Take(switching.CountPage).ToList();
        }

        private void SortByАlphabet_Click(object sender, RoutedEventArgs e)
        {
            //currentList = currentServices.OrderBy(x => x.NameOfService);
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentList.Skip(0).Take(switching.CountPage).ToList();
        }

        private void SortButton_Button(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void ReverseByAlphabet_Click(object sender, RoutedEventArgs e)
        {
            //currentList = currentServices.OrderByDescending(x => x.NameOfService);
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentList.Skip(0).Take(switching.CountPage).ToList();
        }

        private void SortByPrice_Click(object sender, RoutedEventArgs e)
        {
            //currentList = currentServices.OrderBy(x => x.Price);
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentList.Skip(0).Take(switching.CountPage).ToList();
        }
        private void ReverseByPrice_Click(object sender, RoutedEventArgs e)
        {
            //currentList = currentServices.OrderByDescending(x => x.Price);
            //switching.CurrentPage = 3;
            //switching.Countlist = currentServices.Count;
            //LViewTours.ItemsSource = currentList.Skip(0).Take(switching.CountPage).ToList();
        }
    }
}
