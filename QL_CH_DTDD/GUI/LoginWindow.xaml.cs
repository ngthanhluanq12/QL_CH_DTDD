using MaterialDesignThemes.Wpf;
using QL_CH_DTDD.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace QL_CH_DTDD.GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public bool IsDarktheme { get; set; }
        private readonly PaletteHelper paletehepper = new PaletteHelper();

        public LoginWindow()
        {
            InitializeComponent();
        }
        private void ToggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletehepper.GetTheme();
            if (IsDarktheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarktheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarktheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletehepper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = DB.ConnectionString();
            SqlConnection sqlCon = new SqlConnection(connectionString);

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT * FROM NhanVien WHERE TenDangNhap=@Username AND MatKhau=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", usernameTextBox.Text);
                sqlCmd.Parameters.AddWithValue("@Password", passwordTextBox.Password);

                var reader = sqlCmd.ExecuteReader();

                //int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (reader.Read())
                {

                    var tenNhanVien = (string)reader["TenNhanVien"];


                    new MainWindow() { DataContext = tenNhanVien }.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
