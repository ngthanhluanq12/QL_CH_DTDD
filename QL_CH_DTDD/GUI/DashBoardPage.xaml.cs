using LiveCharts;
using LiveCharts.Wpf;
using QL_CH_DTDD.BUS;
using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DashBoardPage.xaml
    /// </summary>
    public partial class DashBoardPage : Page
    {
        public DashBoardPage()
        {
            InitializeComponent();
            DataContext = this;
        }


        DashBoard_BUS DashBoard = new DashBoard_BUS();

        BindingList<DonHang> _listBill = null;
        BindingList<SanPham> _listProduct = null;
        BindingList<SanPham> _listSmall = null;

        List<DonHang> _Bill = null;
        List<SanPham> _Procduct = null;


        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách 
            _listProduct = DashBoard.GetAllProduct();
            _Procduct = _listProduct.ToList();
            var ToltalProducts = _Procduct.Sum(x => x.tonKho);


            // lay danh sach bill
            _listBill = DashBoard.GetAllCustomBill();
            _Bill = _listBill.ToList();
            var Toltal = _Bill.Count;

            // cac san pham it hon 5
            int counts = 0;
            for (int i = 0; i < _Procduct.Count; i++)
            {
                if (_Procduct[i].tonKho < 5)
                    counts++;
            }
            ProductSmall.Text = counts.ToString();

            // tinh tong sp va tong don hang
            OderBill.Text = Toltal.ToString();
            TolTalProduct.Text = ToltalProducts.ToString();

            //liet ke san pham < 5
            _listSmall = DashBoard.GetAllProductSmall();
            LViewProduct.ItemsSource = _listSmall;
            // piechart
            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            List<double> Values = new List<double>();

            var kq = _Procduct.GroupBy(bill => bill.loaiSanPhamId);
            foreach (var group in kq)
            {
                double value = 0;
                foreach (var b in group)
                {
                    if (b.tonKho > 0)
                    {
                        value = value + b.tonKho;

                    }
                }
                Values.Add(value);
            }
            // tong san pham cua tung loai
            series.Add(new ColumnSeries()
            {
                Values = new ChartValues<double>(Values),
                Title = "Số lượng"
            });

            ToTalEndNum.Series = series;
        }
    }
}
