using QL_CH_DTDD.BUS;
using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        public SanPham oderProduct { get; set; }
        int ID = 0;
        int Endnum = 0;

        public NewOrderPage(SanPham product)
        {
            InitializeComponent();
            oderProduct = (SanPham)product;
            DataContext = oderProduct;
            ID = product.sanPhamId;
            oderproductName.Text = product.tenSanPham;
            editProductDate.SelectedDate = DateTime.Now;
            oderProductPrice.Text = product.giaBan.ToString();
            oldNumberProduct.Text = product.tonKho.ToString();
            Endnum = product.tonKho;

        }
        public NewOrderPage()
        {
            InitializeComponent();
        }

        ThemDH_BUS ThemDH = new ThemDH_BUS();
        BindingList<DonHang> _list = null;
        DonHang add = new DonHang();
        private void NewOrderPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // lưu đơn hàng vào CSDL
        private void saveOderProduct_Click(object sender, RoutedEventArgs e)
        {
            // kiểm tra thông tin đầy đủ không?.
            if (oderCustomerName.Text.Length == 0 || editProductDate.Text.Length == 0 || CustomerPhone.Text.Length == 0
               || oderNumberProduct.Text.Length == 0 || oderAddress.Text.Length == 0 || oderMoneyCustomer.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Kiểm tra còn đủ hàng không?
            int number = 0;
            int.TryParse(oderNumberProduct.Text, out number);// Số lượng mua
            int Oldnumber = 0;
            int.TryParse(oldNumberProduct.Text, out Oldnumber); // Số lượng tồn
            if (number > Oldnumber)
            {
                MessageBox.Show("Vui lòng kiểm tra lại hàng tồn", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // lấy thông tin các textbox
            add.loaiSanPhamId = oderProduct.loaiSanPhamId;
            add.sanPhamId = oderProduct.sanPhamId;
            add.tenKhachHang = oderCustomerName.Text;
            add.tenSanPham = oderproductName.Text;
            add.ngayBan = DateTime.Parse(editProductDate.Text);
            add.dienThoai = CustomerPhone.Text;
            add.diaChi = oderAddress.Text;
            add.soLuongMua = int.Parse(oderNumberProduct.Text);
            add.giaBan = int.Parse(oderProductPrice.Text);
            add.tongTien = int.Parse(ProductCost.Text);
            add.tienKhachDua = int.Parse(oderMoneyCustomer.Text);
            add.tienThoiLai = int.Parse(oderMoneychange.Text);
            add.loiNhuan = (int)(int.Parse(ProductCost.Text) * 0.4);

            // cập lại hàng tồn
            List<SanPham> products = null;
            int _endNum = Endnum - (int.Parse(oderNumberProduct.Text));

            ThemDH.UpdateProductEndNum(ID, _endNum);

            //if(rowsNum==1)
            //{
            //    MessageBox.Show($"Đã cap nhat thanh cong hang ton ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            //}


            // them don hang 
            var rowsCount = ThemDH.AddCustomBill(add);

            if (rowsCount == 1)
            {
                MessageBox.Show($"Đã thêm thành công đơn hàng ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // refesh để thêm mới sản phẩm
            //  Refesh();
        }

        // chọn sản phẩm để tạo đơn
        private void CancelProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }
        // chỉ cho nhập số
        private void oderNumberProduct_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        // khi nhập số lượng
        private void oderNumberProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (oderNumberProduct.Text.Length > 0)
            {
                int NumberBuy = 0;
                int.TryParse(oderNumberProduct.Text, out NumberBuy);
                // tinh tong
                double value = 0;
                value = NumberBuy * oderProduct.giaBan;
                ProductCost.Text = value.ToString();

            }
            else
            {
                ProductCost.Clear();
                oderMoneychange.Clear();
                oderMoneyCustomer.Clear();
            }
        }

        private void oderMoneyCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void oderMoneyCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (oderMoneyCustomer.Text.Length > 0)
            {
                // tiền khách đưa
                double taken = 0;
                double.TryParse(oderMoneyCustomer.Text, out taken);
                oderMoneyCustomer.Text = taken.ToString();
                oderMoneyCustomer.CaretIndex = oderMoneyCustomer.Text.Length;

                // tiền thối lại
                double sellPrice = 0;
                double.TryParse(ProductCost.Text, out sellPrice);
                oderMoneychange.Text = (taken - sellPrice).ToString();
            }
            else oderMoneychange.Clear();
        }

        // nhập số điện thoại
        private void CustomerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        // danh sach don hang
        private void listProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListBillPage());
        }
    }
}
