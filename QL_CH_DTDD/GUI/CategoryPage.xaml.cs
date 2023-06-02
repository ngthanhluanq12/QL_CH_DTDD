using QL_CH_DTDD.BUS;
using QL_CH_DTDD.DAO;
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
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        LoaiSanPhamBUS LoaiSP = new LoaiSanPhamBUS();
        BindingList<LoaiSanPham> _list = null;

        public CategoryPage()
        {
            InitializeComponent();
            //disable 2 nut sửa, xóa
            updatecategory.IsEnabled = false;
            deletecategory.IsEnabled = false;
        }
        private void CategoryPage_Loaded(object sender, RoutedEventArgs e)
        {

            //string connectionString = DB.ConnectionString();
            //var dao = new SqlDataAccess(connectionString);
            //LoaiSP = new Business(dao);



            //if (!dao.CanConnect())
            //{
            //    MessageBox.Show("Không thể kết nối đến CSDL", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    dao.Connect();

                // Lấy danh sách loại sản phẩm và hiển thị
                _list = LoaiSP.GetAllCategories();
                categoryListView.ItemsSource = _list;
            //}
        }

        private void categoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy đối tượng ProductType tương ứng
            if (categoryListView.SelectedItem == null) return;
            var categoryType = categoryListView.SelectedItem as LoaiSanPham;

            // Đưa thông tin vào các TextBox
            IdTextBox.Text = categoryType.loaiSanPhamId.ToString();
            nameTextBox.Text = categoryType.tenLoai;
            desTextBox.Text = categoryType.moTa;

            //enable 2 nut sửa, xóa
            updatecategory.IsEnabled = true;
            deletecategory.IsEnabled = true;

            // editProductTypeDescription.Text = categoryType.Description;
        }

        // thêm category
        private void addcategory_Click(object sender, RoutedEventArgs e)
        {
            LoaiSanPham add = new LoaiSanPham();
            // Kiểm tra dữ liệu có nhập đầy đủ không
            if (nameTextBox.Text.Length == 0 || desTextBox.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // lấy thông tin 2 textbox
            add.tenLoai = nameTextBox.Text;
            add.moTa = desTextBox.Text;
            var rowsCount = LoaiSP.AddCategory(add);

            if (rowsCount == 1)
            {
                MessageBox.Show($"Đã thêm thành công loại sản phẩm {add.tenLoai}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Cập nhật giao diện
            _list.Add(add);

            _list.Clear();
            _list = LoaiSP.GetAllCategories();
            categoryListView.ItemsSource = _list;

        }

        //update category
        private void updatecategory_Click(object sender, RoutedEventArgs e)
        {
            var update = categoryListView.SelectedItem as LoaiSanPham;
            // Kiểm tra dữ liệu có nhập đầy đủ không
            if (nameTextBox.Text.Length == 0 || desTextBox.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // lấy thông tin 2 textbox
            update.tenLoai = nameTextBox.Text;
            update.moTa = desTextBox.Text;
            var rowsCount = LoaiSP.UpdateCategory(update);

            if (rowsCount == 1)
            {
                MessageBox.Show($"Đã cập nhật thành công loại sản phẩm {update.tenLoai}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Cập nhật giao diện
            _list.Clear();
            _list = LoaiSP.GetAllCategories();
            categoryListView.ItemsSource = _list;
            //vô hiệu 2 nut sửa, xóa
            updatecategory.IsEnabled = false;
            deletecategory.IsEnabled = false;

        }
        // delete category
        private void deletecategory_Click(object sender, RoutedEventArgs e)
        {
            var delete = categoryListView.SelectedItem as LoaiSanPham;
            int index = categoryListView.SelectedIndex;
            //thong bao
            if (MessageBox.Show($"Bạn chắc chắn muốn xóa loại sản phẩm {delete.tenLoai}", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (index >= 0)
                {
                    int rowsCount = LoaiSP.DeleteCategoryById(delete.loaiSanPhamId);

                    if (rowsCount > 0)
                    {
                        MessageBox.Show($"Đã xóa thành công loại sản phẩm: {delete.tenLoai}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Cập nhật giao diện
                        _list.RemoveAt(index);
                    }
                }
                // Cập nhật giao diện
                _list.Clear();
                _list = LoaiSP.GetAllCategories();
                categoryListView.ItemsSource = _list;
                //vô hiệu 2 nut sửa, xóa
                updatecategory.IsEnabled = false;
                deletecategory.IsEnabled = false;
            }
            else
            {
                // Dong 
            }
        }



    }
}
