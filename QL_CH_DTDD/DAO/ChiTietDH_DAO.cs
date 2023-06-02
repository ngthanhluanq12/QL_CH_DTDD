using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DAO
{
   public class ChiTietDH_DAO:DB
    {
        SqlConnection _connection = new SqlConnection(ConnectionString());

        // Đọc danh sách don hang
        public BindingList<DonHang> GetAllCustomBill()
        {
            var result = new BindingList<DonHang>();
            var sql = "select * from DonHang";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catId = (int)reader["id"];
                var catCategoryId = (int)reader["LoaiSanPhamId"];
                var productId = (int)reader["SanPhamId"];
                var catCustommerName = (string)reader["TenKhachHang"];
                var CatProductName = (string)reader["TenSanPham"];
                var catOderDate = (DateTime)reader["NgayBan"];
                var catPhone = (string)reader["DienThoai"];
                var catAddress = (string)reader["DiaChi"];
                var catOderNumber = (int)reader["SoLuongMua"];
                var catCostPrice = (int)reader["GiaBan"];
                var catFinalPrice = (int)reader["TongTien"];
                var catCustomMoney = (int)reader["TienKhachDua"];
                var catExchangMony = (int)reader["TienThoiLai"];


                var cat = new DonHang()
                {
                    ID = catId,
                    loaiSanPhamId = catCategoryId,
                    sanPhamId = productId,
                    tenKhachHang = catCustommerName,
                    tenSanPham = CatProductName,
                    ngayBan = catOderDate,
                    dienThoai = catPhone,
                    diaChi = catAddress,
                    soLuongMua = catOderNumber,
                    giaBan = catCostPrice,
                    tongTien = catFinalPrice,
                    tienKhachDua = catCustomMoney,
                    tienThoiLai = catExchangMony

                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }
        // doc productId
        public SanPham GetProductById(int id)
        {
            var sql = "select * from SanPham where SanPhamId=@CatId";
            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("CatId", SqlDbType.Int).Value = id;
            _connection.Open();
            var reader = command.ExecuteReader();

            SanPham result = null;

            if (reader.Read()) // ORM - Object relational mapping
            {
                var catId = (int)reader["SanPhamId"];
                var catCategoryId = (int)reader["LoaiSanPhamId"];
                var catProductName = (string)reader["TenSanPham"];
                var catPrice = (int)reader["GiaBan"];
                var catAvatar = (string)reader["HinhAnh"];
                var catDescription = (string)reader["MoTa"];
                var catAddDate = (DateTime)reader["NgayNhap"];
                var catNumberProduct = (int)reader["SoLuong"];
                var catCostPrice = (int)reader["GiaVon"];

                result = new SanPham()
                {
                    sanPhamId = catId,
                    loaiSanPhamId = catCategoryId,
                    tenSanPham = catProductName,
                    giaBan = catPrice,
                    hinhAnh = catAvatar,
                    moTa = catDescription,
                    ngayNhap = catAddDate,
                    soLuong = catNumberProduct,
                    giaVon = catCostPrice
                };
            }
            _connection.Close();
            return result;
        }


    }
}
