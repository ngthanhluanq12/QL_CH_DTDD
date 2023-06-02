using QL_CH_DTDD.BUS;
using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        List<SanPham> _viewModel = null;

        int _currentPage = 0;
        int _totalItems = 0;
        int _totalPages = 0;
        int _rowsPerPage = 6;


        public ProductPage()
        {
            InitializeComponent();
        }

        SanPhamBUS SanPham = new SanPhamBUS();
        BindingList<SanPham> _iphones = null;
        BindingList<LoaiSanPham> _list = null;

        private void ProductPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách sản phẩm và hiển thị
            _iphones = SanPham.GetAllProduct();
            IphoneComboBox.ItemsSource = _iphones;

            //Hiển thị loại sản phẩm
            _list = SanPham.GetAllCategories();
            categoriesComboBox.ItemsSource = _list;

            // phân trang

            IphoneComboBox.ItemsSource = _iphones;

            _viewModel = _iphones.ToList();

            _totalItems = _viewModel.Count;
            _totalPages = calcTotalPages(_totalItems, _rowsPerPage);

            createPagingInfo();
            pagesComboBox.SelectedIndex = 0;

            //ID category
            categoriesComboBox.SelectionChanged += CategoriesComboBox_SelectionChanged;

            infoTextBlock.Text = " Tổng Số Sản Phẩm Hiện Có: " + _totalItems.ToString();
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Hiển thị id của category
            var category = categoriesComboBox.SelectedItem as LoaiSanPham;
            int index = category.loaiSanPhamId;
            // hiển thị danh sách sản phẩm theo loại được chọn

            string keyword = index.ToString();
            //  keyword = index.ToString();
            Debug.WriteLine(keyword);

            Regex regex = new Regex(keyword, RegexOptions.Compiled);

            //phan trang
            _viewModel = _iphones
                    .Where(line => regex.Match((line as SanPham).loaiSanPhamId.ToString()).Success)
                    .ToList();
            IphoneComboBox.ItemsSource = _viewModel;

            _totalItems = _viewModel.Count;
            _totalPages = calcTotalPages(_totalItems, _rowsPerPage);

            createPagingInfo();
            pagesComboBox.SelectedIndex = 0;
        }

        private void updateCurrentView()
        {
            IphoneComboBox.ItemsSource = _viewModel
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

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int page = pagesComboBox.SelectedIndex + 1;
            _currentPage = page;

            updateCurrentView();
        }

        // nếu hộp tìm kiếm rỗng thì hiển thị hết sản phẩm
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(keywordTextBox.Text))
                return true;
            else
                return ((item as SanPham).tenSanPham.IndexOf(keywordTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        // Tìm kiếm theo tên
        private void keywordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string keyword = keywordTextBox.Text;
                Debug.WriteLine(keyword);

                Regex regex = new Regex(keyword, RegexOptions.Compiled);

                _viewModel = _iphones
                    .Where(line => regex.Match((line as SanPham).tenSanPham).Success)
                    .ToList();
                IphoneComboBox.ItemsSource = _viewModel;

                _totalItems = _viewModel.Count;
                _totalPages = calcTotalPages(_totalItems, _rowsPerPage);

                createPagingInfo();
                pagesComboBox.SelectedIndex = 0;
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void IphoneComboBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as SanPham;
            if (item != null)
            {
                // Chọn xem sản phẩm hay chọn tạo đơn hàng

                if (OderDisplay.displayOder == true)
                {
                    var oderproduc = new NewOrderPage(item);
                    NavigationService.Navigate(oderproduc);
                }
                else
                {
                    var detail = new EditProductPage(item);
                    NavigationService.Navigate(detail);

                }
                // gán lại bằng false
                OderDisplay.displayOder = false;
            }

        }
        // tìm theo giá san pham
        private void findPrice_Click(object sender, RoutedEventArgs e)
        {

            if (startprice.Text.Length == 0 && endprice.Text.Length == 0)
            {

                _iphones.Clear();
                _iphones = SanPham.GetAllProduct();
                IphoneComboBox.ItemsSource = _iphones;

            }
            else
            {
                int priceMin = 0;
                int priceMax = 0;
                int.TryParse(startprice.Text, out priceMin);
                int.TryParse(endprice.Text, out priceMax);
                if (priceMin > 0 && priceMax > 0)
                {
                    _iphones = SanPham.FilterPrice(priceMin, priceMax);

                    IphoneComboBox.ItemsSource = _iphones;

                }
            }
            _viewModel = _iphones.ToList();

            _totalItems = _viewModel.Count;
            _totalPages = calcTotalPages(_totalItems, _rowsPerPage);

            createPagingInfo();
            pagesComboBox.SelectedIndex = 0;
        }

        private void startprice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void endprice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
