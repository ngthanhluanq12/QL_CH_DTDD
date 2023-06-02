using QL_CH_DTDD.BUS;
using QL_CH_DTDD.DTO;
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
    /// Interaction logic for OderDetails.xaml
    /// </summary>
    public partial class OderDetails : Page
    {
        public DonHang oderbillProduct { get; set; }
        int proId = 0;
        public SanPham produc = null;

        public OderDetails(DonHang billproduct)
        {
            InitializeComponent();
            oderbillProduct = (DonHang)billproduct;
            DataContext = oderbillProduct;
            oderCustomerName.Text = billproduct.tenKhachHang;
            CustomerPhone.Text = billproduct.dienThoai;
            oderAddress.Text = billproduct.diaChi;
            oderproductName.Text = billproduct.tenSanPham;
            editProductDate.Text = billproduct.ngayBan.ToString();
            oderNumberProduct.Text = billproduct.soLuongMua.ToString();
            productId.Text = billproduct.sanPhamId.ToString();

            // gan id de lay hinh anh
            proId = billproduct.sanPhamId;

        }
        public OderDetails()
        {
            InitializeComponent();
        }

        ChiTietDH_BUS DonHang = new ChiTietDH_BUS();

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListBillPage());
        }

        private void OderDetails_Loaded(object sender, RoutedEventArgs e)
        {
            // lấy hinh anh san pham
            produc = DonHang.GetProductById(proId);

            string resourceUri = produc.hinhAnh;
            BitmapImage source = new BitmapImage(new Uri(resourceUri));
            imgProduct.Source = source;


        }
    }
}

