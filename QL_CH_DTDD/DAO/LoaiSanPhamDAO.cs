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
    public class LoaiSanPhamDAO:DB
    {

        SqlConnection _connection = new SqlConnection(ConnectionString());

        public LoaiSanPham GetCategoryById(int id)
        {
            
            var sql = "select * from LoaiSanPham where id=@CatId";
            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("CatId", SqlDbType.Int).Value = id;
            _connection.Open();
            var reader = command.ExecuteReader();
            

            LoaiSanPham result = null;

            if (reader.Read()) // ORM - Object relational mapping
            {
                var catLoaiSanPhamId = (int)reader["LoaiSanPhamId"];
                var catTenLoai = (string)reader["TenLoai"];
                var catMoTa = (string)reader["MoTa"].ToString();

                result = new LoaiSanPham()
                {
                    loaiSanPhamId = catLoaiSanPhamId,
                    tenLoai = catTenLoai,
                    moTa = catMoTa
                };
            }
            _connection.Close();
            return result;
        }

        public BindingList<LoaiSanPham> GetAllCategories()
        {
            var result = new BindingList<LoaiSanPham>();
            var sql = "select * from LoaiSanPham";
            var command = new SqlCommand(sql, _connection);
          
            _connection.Open();
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                var catLoaiSanPhamId = (int)reader["LoaiSanPhamId"];
                var catTenLoai = (string)reader["TenLoai"];
                var catMoTa = (string)reader["MoTa"].ToString();

                var cat = new LoaiSanPham()
                {
                    loaiSanPhamId = catLoaiSanPhamId,
                    tenLoai = catTenLoai,
                    moTa = catMoTa
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }


        /// <summary>
        /// Cập nhật loại sản phẩm
        /// </summary>
        /// <param name="addted">Thông tin mới cần thêm</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int AddCategory(LoaiSanPham addted)
        {
            var sql = "insert into LoaiSanPham(tenLoai, moTa) values(@CatTenLoai, @CatMota)";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("LoaiSanPhamId", SqlDbType.Int).Value = addted.loaiSanPhamId;
            command.Parameters.Add("@CatTenLoai", SqlDbType.NVarChar).Value = addted.tenLoai;
            command.Parameters.Add("@CatMota", SqlDbType.NVarChar).Value = addted.moTa;

            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }

        /// <summary>
        /// Cập nhật loại sản phẩm
        /// </summary>
        /// <param name="edited">Thông tin mới cần cập nhật</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int UpdateCategory(LoaiSanPham edited)
        {
            var sql = "Update LoaiSanPham set tenLoai=@TenLoai, moTa=@MoTa where LoaiSanPhamId=@LoaiSanPhamId";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("LoaiSanPhamId", SqlDbType.Int).Value = edited.loaiSanPhamId;
            command.Parameters.Add("TenLoai", SqlDbType.NVarChar).Value = edited.tenLoai;
            command.Parameters.Add("MoTa", SqlDbType.NVarChar).Value = edited.moTa;

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
        public int DeleteCategoryById(object id)
        {
            var sql = "delete from LoaiSanPham where LoaiSanPhamId=@loaiSanPhamId";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("loaiSanPhamId", SqlDbType.Int).Value = id;

            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }
    }
}
