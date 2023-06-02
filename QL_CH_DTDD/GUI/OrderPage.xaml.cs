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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }
        private void OderproductName_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

            OderDisplay.displayOder = true;
            NavigationService.Navigate(new ProductPage());


        }

        private void listProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListBillPage());
        }
    }
}
