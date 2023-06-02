using Microsoft.Win32;
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
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
        }

        
        ThemSP_BUS ThemSP = new ThemSP_BUS();
        BindingList<LoaiSanPham> _list = null;
        private void AddProductPage_Loaded(object sender, RoutedEventArgs e)
        {

            //Hiển thị danh sách loại sản phẩm
            _list = ThemSP.GetAllCategories();
            categoriesComboBox.ItemsSource = _list;
        }
        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy đối tượng ProductType tương ứng
            if (categoriesComboBox.SelectedItem == null) return;
            var categoryType = categoriesComboBox.SelectedItem as LoaiSanPham;

            // Đưa thông tin vào các TextBox
            editProductType.Text = categoryType.loaiSanPhamId.ToString();
        }


        SanPham add = new SanPham();
        //Thêm mới sản phẩm
        private void saveProduct_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra dữ liệu có nhập đầy đủ không
            if (editProductName.Text.Length == 0 || editProductDes.Text.Length == 0 || editProductDate.Text.Length == 0
                || editProductNum.Text.Length == 0 || editProductCost.Text.Length == 0 || categoriesComboBox.Text.Length == -1
                || editProductPrice.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // lấy thông tin các textbox
            add.loaiSanPhamId = int.Parse(editProductType.Text);
            add.tenSanPham = editProductName.Text;
            add.giaBan = int.Parse(editProductPrice.Text);
            // add.Avatar = editProductDes.Text;
            add.moTa = editProductDes.Text;
            add.ngayNhap = DateTime.Parse(editProductDate.Text);
            add.soLuong = int.Parse(editProductNum.Text);
            add.giaVon = int.Parse(editProductCost.Text);
            add.tonKho = int.Parse(editProductNum.Text);

            var rowsCount = ThemSP.AddProduct(add);


            if (rowsCount == 1)
            {
                MessageBox.Show($"Đã thêm thành công loại sản phẩm {add.tenSanPham}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // refesh để thêm mới sản phẩm
            Refesh();

        }
        // hàm xóa để thêm sản phẩm mới
        public void Refesh()
        {
            editProductName.Clear();
            editProductNum.Clear();
            editProductPrice.Clear();
            editProductDes.Clear();
            editProductCost.Clear();
            editProductType.Clear();
            categoriesComboBox.SelectedIndex = -1;
            editProductDate.Text = null;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,/GUI/Images/cellphone.png");
            image.EndInit();
            imgProduct.Source = image;

        }
        // chỉ cho nhập số
        private void editProductPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        private void editProductNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        private void editProductCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        // chọn hình ảnh bên ngoài
        private void btnAddImageProduct_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgProduct.Source = new BitmapImage(fileUri);
                string sourceFile = openFileDialog.FileName;
                string resourceUri = "D:/QL_CH_DTDD/Images/cellPhone/" + System.IO.Path.GetFileName(openFileDialog.FileName);
                System.IO.File.Copy(sourceFile, resourceUri, true);
                //gán đường dẫn hình ảnh vào csdl
                add.hinhAnh = resourceUri;
            }
        }
        // hủy bỏ /nhập mới
        private void CancelProduct_Click(object sender, RoutedEventArgs e)
        {
            Refesh();
        }
    }
}
