using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DAO
{
   
    public class ThemDH_DAO:DB
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

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="edited">Thông tin mới cần cập nhật</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int UpdateProductEndNum(int id, int num)
        {
            var sql = "update SanPham set TonKho=@tonKho where SanPhamId=@ID";
            var command = new SqlCommand(sql, _connection);

            command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
            command.Parameters.AddWithValue("@tonKho", SqlDbType.Int).Value = num;
            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }



    }
}
