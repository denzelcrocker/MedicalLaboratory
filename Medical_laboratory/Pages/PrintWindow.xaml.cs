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
using System.Windows.Shapes;

namespace Medical_laboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        public PrintWindow(Result result)
        {
            InitializeComponent();
            numberOfResult.Text = Convert.ToString(result.ResultId);
            dateOfResult.Text = Convert.ToString(result.Date);
            employeeTB.Text = result.Employee.Name;
            userTB.Text = result.User.Name;
            serviceTB.Text = result.Service.NameOfService;
            resultTB.Text = result.Result1;
            priceOfResultTB.Text = Convert.ToString(result.Service.Price);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(PrintGrid, "Распечатываем отчет по услуге");
            }
        }
    }
}
