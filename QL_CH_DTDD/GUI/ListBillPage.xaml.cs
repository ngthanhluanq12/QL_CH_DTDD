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
    /// Interaction logic for ListBillPage.xaml
    /// </summary>
    public partial class ListBillPage : Page
    {
        //Phan trang danh sach don hang
        List<DonHang> _viewModel = null;

        int _currentPage = 0;
        int _totalItems = 0;
        int _totalPages = 0;
        int _rowsPerPage = 11;
        public ListBillPage()
        {
            InitializeComponent();
        }

        DanhSachDH_BUS DonHang = new DanhSachDH_BUS();
        BindingList<DonHang> _list = null;

        private void oderBill_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }

        private void CustomerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        private void ListBillPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách loại sản phẩm và hiển thị
            _list = DonHang.GetAllCustomBill();
            BillListView.ItemsSource = _list;

            // phân trang

            _viewModel = _list.ToList();

            _totalItems = _viewModel.Count;
            _totalPages = calcTotalPages(_totalItems, _rowsPerPage);

            createPagingInfo();
            pagesComboBox.SelectedIndex = 0;
        }

        private void updateCurrentView()
        {
            BillListView.ItemsSource = _viewModel
                .Skip((_currentPage - 1) * _rowsPerPage)
                .Take(_rowsPerPage)
                .ToList();
        }

        private void createPagingInfo()
        {
            // Tạo ra danh sách các trang cho comboBox
            List<string> pages = new List<string>();
            for (int i = 1; i <= _totalPages; i++)
            {
                pages.Add($"{i} / {_totalPages}");
            }

            pagesComboBox.ItemsSource = pages;
        }

        private int calcTotalPages(int totalItems, int rowsPerPage)
        {
            int result = totalItems / rowsPerPage +
                (totalItems % rowsPerPage == 0 ? 0 : 1);
            return result;
        }
        //nut tien lui
        private void previousButton_Click(object sender, RoutedEventArgs e)
        {

            int page = pagesComboBox.SelectedIndex;

            if (page != 0)
            {
                pagesComboBox.SelectedIndex = page - 1;
            }

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

            int page = pagesComboBox.SelectedIndex;
            pagesComboBox.SelectedIndex = page + 1;

        }

        // khi click vào từng dòng đơn hàng
        private void BillListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy đối tượng custombill tương ứng
            if (BillListView.SelectedItem == null) return;
            var CustomBill = BillListView.SelectedItem as DonHang;

            // Đưa thông tin vào các TextBox
            oderCustomerName.Text = CustomBill.tenKhachHang;
            oderAddress.Text = CustomBill.diaChi;
            CustomerPhone.Text = CustomBill.dienThoai;

            //enable 2 nut sửa, xóa
            saveOderProduct.IsEnabled = true;
            CancelProduct.IsEnabled = true;
            BillDetails.IsEnabled = true;
            // disable nut tao
            oderBill.IsEnabled = false;
        }
        // cap nhat bill
        private void saveOderProduct_Click(object sender, RoutedEventArgs e)
        {
            var update = BillListView.SelectedItem as DonHang;
            // Kiểm tra dữ liệu có nhập đầy đủ không
            if (oderCustomerName.Text.Length == 0 || oderAddress.Text.Length == 0 || CustomerPhone.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // lấy thông tin 2 textbox
            update.tenKhachHang = oderCustomerName.Text;
            update.diaChi = oderAddress.Text;
            update.dienThoai = CustomerPhone.Text;
            var rowsCount = DonHang.UpdateCustomBill(update);

            if (rowsCount == 1)
            {
                MessageBox.Show($"Đã cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Cập nhật giao diện
            _list.Clear();
            _list = DonHang.GetAllCustomBill();
            BillListView.ItemsSource = _list;
            //vô hiệu 2 nut sửa, xóa
            saveOderProduct.IsEnabled = false;
            CancelProduct.IsEnabled = false;
            BillDetails.IsEnabled = false;
        }
        // xoa hoa don
        private void CancelProduct_Click(object sender, RoutedEventArgs e)
        {
            var delete = BillListView.SelectedItem as DonHang;
            int index = BillListView.SelectedIndex;
            //Thông báo 
            if (MessageBox.Show($"Bạn chắc chắn muốn xóa hóa đơn {delete.tenSanPham}", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (index >= 0)
                {
                    int rowsCount = DonHang.DeleteCustomBillById(delete.ID);

                    if (rowsCount > 0)
                    {
                        MessageBox.Show($"Đã xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Cập nhật giao diện
                        _list.RemoveAt(index);
                    }
                }
                // Cập nhật giao diện
                _list.Clear();
                _list = DonHang.GetAllCustomBill();
                BillListView.ItemsSource = _list;
                //vô hiệu 2 nut sửa, xóa
                saveOderProduct.IsEnabled = false;
                CancelProduct.IsEnabled = false;
                BillDetails.IsEnabled = false;
            }
            else
            {
                // đóng
            }
        }

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int page = pagesComboBox.SelectedIndex + 1;
            _currentPage = page;

            updateCurrentView();
        }
        // tim kiem tu ngay den ngay
        private void FetchData_Click(object sender, RoutedEventArgs e)
        {

            // Kiểm tra 2 DatePicker có trống không
            if (StarDate.Text.Length == 0 || endDate.Text.Length == 0)
            {
                MessageBox.Show($"Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // lấy thông tin 2 textbox
            DateTime star = StarDate.SelectedDate.Value;
            DateTime end = endDate.SelectedDate.Value;

            _list = DonHang.FilterCustomBill(star, end);
            BillListView.ItemsSource = _list;

        }

        private void BillDetails_Click(object sender, RoutedEventArgs e)
        {
            var CustomBill = BillListView.SelectedItem as DonHang;
            if (CustomBill != null)
            {
                var oderbillproduc = new OderDetails(CustomBill);
                NavigationService.Navigate(oderbillproduc);

            }
        }
    }
}
