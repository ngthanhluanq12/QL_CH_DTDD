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
    /// Interaction logic for EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public SanPham EditedProduct { get; set; }
        int ID = 0;

        public EditProductPage(SanPham product)
        {
            InitializeComponent();
            // EditedProduct = (Products)product.Clone();
            EditedProduct = (SanPham)product;
            DataContext = EditedProduct;

            ID = product.sanPhamId;
            editProductType.Text = product.loaiSanPhamId.ToString();
            editProductType.Text = product.tenSanPham;
            editProductPrice.Text = product.giaBan.ToString();
            editProductDes.Text = product.moTa;
            editProductDate.Text = product.ngayNhap.ToString();
            editProductNum.Text = product.soLuong.ToString();
            editProductCost.Text = product.giaVon.ToString();
            if (product.hinhAnh != null)
            {
                BitmapImage source = new BitmapImage(new Uri(product.hinhAnh));
                imgProduct.Source = source;
            }

        }
        public EditProductPage()
        {
            InitializeComponent();
        }

        SuaSP_BUS SuaSP = new SuaSP_BUS();
        BindingList<LoaiSanPham> _list = null;
        private void EditProductPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị danh sách loại sản phẩm
            _list = SuaSP.GetAllCategories();
            categoriesComboBox.ItemsSource = _list;

            // hiển thị đúng loại cần tìm
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].loaiSanPhamId == (EditedProduct.loaiSanPhamId))
                {
                    categoriesComboBox.SelectedIndex = i; break;
                }
            }
        }
        //update product
        SanPham update = new SanPham();
        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy đối tượng categoryID tương ứng
            if (categoriesComboBox.SelectedItem == null) return;
            var categoryId = categoriesComboBox.SelectedItem as LoaiSanPham;

            // Đưa thông tin vào các TextBox
            editProductType.Text = categoryId.loaiSanPhamId.ToString();
        }

        private void btnAddImageProduct_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);

                try
                {
                    imgProduct.Source = new BitmapImage(fileUri);
                    string sourceFile = openFileDialog.FileName;
                    string resourceUri = "D:/QL_CH_DTDD/Images/cellPhone/" + System.IO.Path.GetFileName(openFileDialog.FileName);
                    System.IO.File.Copy(sourceFile, resourceUri, true);
                    //gán đường dẫn sau khi copy
                    BitmapImage source = new BitmapImage(new Uri(resourceUri));
                    imgProduct.Source = source;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hình Ảnh không đúng hoặc đang được sử dụng", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void updateProduct_Click(object sender, RoutedEventArgs e)
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
            update.sanPhamId = ID;
            update.loaiSanPhamId = int.Parse(editProductType.Text);
            update.tenSanPham = editProductName.Text;
            update.giaBan = int.Parse(editProductPrice.Text);
            update.hinhAnh = imgProduct.Source.ToString();
            update.moTa = editProductDes.Text;
            update.ngayNhap = DateTime.Parse(editProductDate.Text);
            update.soLuong = int.Parse(editProductNum.Text);
            update.giaVon = int.Parse(editProductCost.Text);
            update.tonKho = int.Parse(editProductNum.Text);


            //sửa product
            var oldProduct = new SanPham();

            oldProduct.sanPhamId = update.sanPhamId;
            oldProduct.loaiSanPhamId = update.loaiSanPhamId;
            oldProduct.tenSanPham = update.tenSanPham;
            oldProduct.giaBan = update.giaBan;
            oldProduct.hinhAnh = update.hinhAnh;
            oldProduct.moTa = update.moTa;
            oldProduct.ngayNhap = update.ngayNhap;
            oldProduct.soLuong = update.soLuong;
            oldProduct.giaVon = update.giaVon;
            oldProduct.tonKho = update.tonKho;

            var rowsCount = SuaSP.UpdateProduct(oldProduct);

            if (rowsCount == 1)
            {
                MessageBox.Show($"Đã cập nhật thành công sản phẩm {oldProduct.tenSanPham}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // refesh, thoát ra màn hình danh sách
            Refesh();
            NavigationService.Navigate(new ProductPage());
        }
        // hàm xóa trắng các dữ liệu nhập
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
        // chỉ cho phép nhập số
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
        // hủy không lưu và xóa các text
        private void CancelProduct_Click(object sender, RoutedEventArgs e)
        {
            Refesh();
            NavigationService.Navigate(new ProductPage());
        }
        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var delete = new SanPham();
            int idproduct = ID;
            //Thông báo 
            if (MessageBox.Show($"Bạn chắc chắn muốn xóa sản phẩm {editProductName.Text}", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            // gán ID cho product được chọn
            {
                delete.sanPhamId = idproduct;
                if (delete.sanPhamId >= 0)
                {
                    int rowsCount = SuaSP.DeleteProductById(delete.sanPhamId);

                    if (rowsCount > 0)
                    {
                        MessageBox.Show($"Đã xóa thành công sản phẩm {editProductName.Text}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        Refesh();
                        NavigationService.Navigate(new ProductPage());

                    }
                }
            }
            else
            {
                // Dong
            }
        }
        private void saveProduct_Click(object sender, RoutedEventArgs e)
        {
            //  DialogResult = true;
        }
    }
}
