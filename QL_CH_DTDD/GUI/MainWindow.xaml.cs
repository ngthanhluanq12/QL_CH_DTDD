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

namespace QL_CH_DTDD.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new System.Uri("/GUI/DashBoardPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("/GUI/DashBoardPage.xaml", UriKind.RelativeOrAbsolute));

            grdCursor.Margin = new Thickness(10, 172, 10, 0);
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("/GUI/CategoryPage.xaml", UriKind.RelativeOrAbsolute));

            grdCursor.Margin = new Thickness(10, 238, 10, 0);
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("/GUI/ProductPage.xaml", UriKind.RelativeOrAbsolute));

            grdCursor.Margin = new Thickness(10, 301, 10, 0);
        }

        private void btnBill_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("/GUI/OrderPage.xaml", UriKind.RelativeOrAbsolute));

            grdCursor.Margin = new Thickness(10, 364, 10, 0);
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("/GUI/StatisticPage.xaml", UriKind.RelativeOrAbsolute));

            grdCursor.Margin = new Thickness(10, 430, 10, 0);
        }
    }
}
