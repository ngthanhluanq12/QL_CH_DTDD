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
   
    public class SuaSP_DAO:DB
    {
        SqlConnection _connection = new SqlConnection(ConnectionString());
        // Đọc danh sách category
        public BindingList<LoaiSanPham> GetAllCategories()
        {
            var result = new BindingList<LoaiSanPham>();
            var sql = "select * from LoaiSanPham";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catId = (int)reader["LoaiSanPhamId"];
                var catName = (string)reader["TenLoai"];

                var cat = new LoaiSanPham()
                {
                    loaiSanPhamId = catId,
                    tenLoai = catName,
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="edited">Thông tin mới cần cập nhật</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int UpdateProduct(SanPham edited)
        {
            var sql = "update SanPham set loaiSanPhamId=@LoaiSanPhamId, tenSanPham=@TenSanPham, giaBan=@GiaBan, hinhAnh=@HinhAnh, moTa=@MoTa, ngayNhap=@NgayNhap, soLuong=@SoLuong, giaVon=@GiaVon, tonKho=@TonKho where SanPhamId=@SanPhamId";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("SanPhamId", SqlDbType.Int).Value = edited.sanPhamId;
            command.Parameters.Add("LoaiSanPhamId", SqlDbType.Int).Value = edited.loaiSanPhamId;
            command.Parameters.Add("TenSanPham", SqlDbType.NVarChar).Value = edited.tenSanPham;
            command.Parameters.Add("GiaBan", SqlDbType.Int).Value = edited.giaBan;
            command.Parameters.Add("HinhAnh", SqlDbType.NVarChar).Value = edited.hinhAnh;
            command.Parameters.Add("MoTa", SqlDbType.NVarChar).Value = edited.moTa;
            command.Parameters.Add("NgayNhap", SqlDbType.DateTime).Value = edited.ngayNhap;
            command.Parameters.Add("SoLuong", SqlDbType.Int).Value = edited.soLuong;
            command.Parameters.Add("GiaVon", SqlDbType.Int).Value = edited.giaVon;
            command.Parameters.Add("TonKho", SqlDbType.Int).Value = edited.tonKho;

            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }
        /// <summary>
        /// Xóa một loại sản phẩm
        /// </summary>
        /// <param name="id">ID của sản phẩm cần xóa</param>
        /// <returns>Số lượng sản phẩm đã xóa</returns>
        public int DeleteProductById(object id)
        {
            var sql = "delete from SanPham where SanPhamId=@ID";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("ID", SqlDbType.Int).Value = id;
            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }
    }
}
