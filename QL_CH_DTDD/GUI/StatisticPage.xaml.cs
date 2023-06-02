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
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();
        }


        ThongKeBUS ThongKe = new ThongKeBUS();

        BindingList<DonHang> _listBill = null;
        List<DonHang> _viewBill = null;
        List<DonHang> _viewBillnew = null;


        BindingList<LoaiSanPham> _listCategory = null;
        List<LoaiSanPham> _viewCategory = null;

        public string[] Labels { get; set; }

        private void StatisticPage_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            // bill
            _listBill = ThongKe.GetAllCustomBill();
            _viewBill = _listBill.ToList();

            // category
            _listCategory = ThongKe.GetAllCategories();
            _viewCategory = _listCategory.ToList();

            //  int catecount = _viewCategory.Count();

            //

            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            LiveCharts.SeriesCollection seriesPrice = new LiveCharts.SeriesCollection();
            LiveCharts.SeriesCollection seriesProfit = new LiveCharts.SeriesCollection();

            List<double> Values = new List<double>();
            List<double> Price = new List<double>();
            List<double> profit = new List<double>();
            List<string> Label = new List<string>();
            List<string> NameLabel = new List<string>();
            List<string> NameLabe2 = new List<string>();



            //dem co bao nhieu loai san pham
            var count = _viewBill.GroupBy(bill => bill.loaiSanPhamId).Count();
            string[] arr1 = new string[count];

            // gom nhom theo categoryId
            var kq = _viewBill.GroupBy(bill => bill.loaiSanPhamId);

            foreach (var group in kq)
            {
                double value = 0; double price = 0; string label = ""; double profits = 0;
                foreach (var b in group)
                {
                    if (b.soLuongMua > 0)
                    {
                        value = value + b.soLuongMua;
                        price = price + b.tongTien;
                        profits = profits + b.loiNhuan;
                        label = b.loaiSanPhamId.ToString();


                    }
                }
                Values.Add(value);
                Price.Add(price);
                Label.Add(label);
                profit.Add(profits);
            }

            // tong san pham cua tung loai
            series.Add(new ColumnSeries()
            {
                Values = new ChartValues<double>(Values),
                Title = "Số lượng"
            });

            // tổng tiền bán dược cua tung loai
            seriesPrice.Add(new ColumnSeries()
            {
                Values = new ChartValues<double>(Price),
                Title = "Số tiền"
            });
            // loi nhuan 40% trên 1 san pham ban dc
            seriesProfit.Add(new LineSeries()
            {
                Values = new ChartValues<double>(profit),
                Title = "Số tiền lời"
            });

            // them tên loại vào mảng
            for (int i = 0; i < count; i++)
            {
                arr1[i] = Label[i];
            }
            Labels = arr1;

            for (int i = 0; i < count; i++)
            {
                if (_viewCategory[i].loaiSanPhamId.ToString() == arr1[i])
                {
                    arr1[i] = _viewCategory[i].tenLoai;
                }
            }
            Labels = arr1;

            // ve bieu do
            ToTalproduct.Series = series;
            Totalprice.Series = seriesPrice;
            TotalProfit.Series = seriesProfit;
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra 2 DatePicker có trống không
            if (StarDate.Text.Length == 0 || endDate.Text.Length == 0)
            {
                MessageBox.Show($"Vui lòng nhập thông tin từ ngày đến ngày", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // lấy thông tin 2 textbox
            DateTime dayBegin = StarDate.SelectedDate.Value;
            DateTime dayEnd = endDate.SelectedDate.Value;

            _viewBillnew = _viewBill.Where(x => dayBegin <= x.ngayBan && x.ngayBan <= dayEnd).ToList();

            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            LiveCharts.SeriesCollection seriesPrice = new LiveCharts.SeriesCollection();
            LiveCharts.SeriesCollection seriesProfit = new LiveCharts.SeriesCollection();

            List<double> Values = new List<double>();
            List<double> Price = new List<double>();
            List<double> profit = new List<double>();

            var kq = _viewBillnew.GroupBy(bill => bill.loaiSanPhamId);

            foreach (var group in kq)
            {
                double value = 0; double price = 0; double profits = 0;
                foreach (var b in group)
                {
                    if (b.soLuongMua > 0)
                    {
                        value = value + b.soLuongMua;
                        price = price + b.tongTien;
                        profits = profits + b.loiNhuan;
                    }
                }
                Values.Add(value);
                Price.Add(price);
                profit.Add(profits);
            }
            // tong san pham cua tung loai
            series.Add(new ColumnSeries()
            {
                Values = new ChartValues<double>(Values),
                Title = "Số lượng"
            });

            // tổng tiền bán dược cua tung loai
            seriesPrice.Add(new ColumnSeries()
            {
                Values = new ChartValues<double>(Price),
                Title = "Số tiền"
            });
            // loi nhuan 40% trên 1 san pham ban dc
            seriesProfit.Add(new LineSeries()
            {
                Values = new ChartValues<double>(profit),
                Title = "Số tiền lời"
            });
            // ve bieu do
            ToTalproduct.Series = series;
            Totalprice.Series = seriesPrice;
            TotalProfit.Series = seriesProfit;

        }
    }
}
