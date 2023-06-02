﻿using QL_CH_DTDD.DTO;
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
   public class DonHangDAO:DB
    {
        SqlConnection _connection = new SqlConnection(ConnectionString());

        public int AddCustomBill(DonHang addted)
        {
            var sql = "insert into DonHang(loaiSanPhamId, sanPhamId, tenKhachHang, tenSanPham, ngayBan, dienThoai, diaChi, soLuongMua, giaBan, tongTien, tienKhachDua, tienThoiLai, loiNhuan)" +
                " values(@LoaiSanPhamId, @SanPhamId, @TenKhachHang, @TenSanPham, @NgayBan, @DienThoai, @DiaChi, @SoLuongMua, @GiaBan, @TongTien, @TienKhachDua, @TienThoiLai, @LoiNhuan)";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("id", SqlDbType.Int).Value = addted.ID;
            command.Parameters.Add("LoaiSanPhamId", SqlDbType.Int).Value = addted.loaiSanPhamId;
            command.Parameters.Add("SanPhamId", SqlDbType.Int).Value = addted.sanPhamId;
            command.Parameters.Add("TenKhachHang", SqlDbType.NVarChar).Value = addted.tenKhachHang;
            command.Parameters.Add("TenSanPham", SqlDbType.NVarChar).Value = addted.tenSanPham;
            command.Parameters.Add("NgayBan", SqlDbType.DateTime).Value = addted.ngayBan;
            command.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = addted.dienThoai;
            command.Parameters.Add("DiaChi", SqlDbType.NVarChar).Value = addted.diaChi;
            command.Parameters.Add("SoLuongMua", SqlDbType.Int).Value = addted.soLuongMua;
            command.Parameters.Add("GiaBan", SqlDbType.Int).Value = addted.giaBan;
            command.Parameters.Add("TongTien", SqlDbType.Int).Value = addted.tongTien;
            command.Parameters.Add("TienKhachDua", SqlDbType.Int).Value = addted.tienKhachDua;
            command.Parameters.Add("TienThoiLai", SqlDbType.Int).Value = addted.tienThoiLai;
            command.Parameters.Add("LoiNhuan", SqlDbType.Int).Value = addted.loiNhuan;

            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }

        // Đọc danh sách don hang
        public BindingList<DonHang> GetAllCustomBill()
        {
            var result = new BindingList<DonHang>();
            var sql = "select * from DonHang";
            var command = new SqlCommand(sql, _connection);
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

            return result;
        }

        // Đọc Bill với ID
        public DonHang GetCustomBillById(int id)
        {
            var sql = "select * from DonHang where id=@CatId";
            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("CatId", SqlDbType.Int).Value = id;

            var reader = command.ExecuteReader();

            DonHang result = null;

            if (reader.Read()) // ORM - Object relational mapping
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

                result = new DonHang()
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
            }

            return result;
        }
      
        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="edited">Thông tin mới cần cập nhật</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int UpdateCustomBill(DonHang edited)
        {
            var sql = "update DonHang set loaiSanPhamId=@LoaiSanPhamId, sanPhamId=@SanPhamId, tenKhachHang=@TenKhachHang, tenSanPham=@TenSanPham, ngayBan=@NgayBan, dienThoai=@DienThoai, diaChi=@DiaChi, soLuongMua=@SoLuongMua, giaBan=@GiaBan, tongTien=@TongTien, tienKhachDua=@TienKhachDua, tienThoiLai=@TienThoiLai where id=@ID";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("ID", SqlDbType.Int).Value = edited.ID;
            command.Parameters.Add("LoaiSanPhamId", SqlDbType.Int).Value = edited.loaiSanPhamId;
            command.Parameters.Add("SanPhamId", SqlDbType.Int).Value = edited.sanPhamId;
            command.Parameters.Add("TenKhachHang", SqlDbType.NVarChar).Value = edited.tenKhachHang;
            command.Parameters.Add("TenSanPham", SqlDbType.NVarChar).Value = edited.tenSanPham;
            command.Parameters.Add("NgayBan", SqlDbType.DateTime).Value = edited.ngayBan;
            command.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = edited.dienThoai;
            command.Parameters.Add("DiaChi", SqlDbType.NVarChar).Value = edited.diaChi;
            command.Parameters.Add("SoLuongMua", SqlDbType.Int).Value = edited.soLuongMua;
            command.Parameters.Add("GiaBan", SqlDbType.Int).Value = edited.giaBan;
            command.Parameters.Add("TongTien", SqlDbType.Int).Value = edited.tongTien;
            command.Parameters.Add("TienKhachDua", SqlDbType.Int).Value = edited.tienKhachDua;
            command.Parameters.Add("TienThoiLai", SqlDbType.Int).Value = edited.tienThoiLai;


            var rowsCount = command.ExecuteNonQuery();

            return rowsCount;
        }
        /// <summary>
        /// Xóa một loại sản phẩm
        /// </summary>
        /// <param name="id">ID của sản phẩm cần xóa</param>
        /// <returns>Số lượng sản phẩm đã xóa</returns>
        public int DeleteCustomBillById(object id)
        {
            var sql = "delete from DonHang where id=@ID";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("ID", SqlDbType.Int).Value = id;
            var rowsCount = command.ExecuteNonQuery();

            return rowsCount;
        }
        public BindingList<DonHang> FilterCustomBill(DateTime star, DateTime end)
        {
            var result = new BindingList<DonHang>();
            var sql = "select * from DonHang where NgayBan between @fromDate and @toDate";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@fromDate", SqlDbType.DateTime).Value = star;
            command.Parameters.AddWithValue("@toDate", SqlDbType.DateTime).Value = end;

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
                var catProfit = (int)reader["LoiNhuan"];

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
                    tienThoiLai = catExchangMony,
                    loiNhuan = catProfit

                };
                result.Add(cat);
            }
            reader.Close();

            return result;
        }
    }
}
