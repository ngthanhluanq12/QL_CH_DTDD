using QL_CH_DTDD.DAO;
using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.BUS
{
   public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAO loaiSP = new LoaiSanPhamDAO();


        public LoaiSanPham GetCategoryById(int id)
        {
            LoaiSanPham result = loaiSP.GetCategoryById(id);

            return result;
        }


        public BindingList<LoaiSanPham> GetAllCategories()
        {
            BindingList<LoaiSanPham> result = loaiSP.GetAllCategories();
            return result;
        }

        /// <summary>
        /// Cập nhật loại sản phẩm
        /// </summary>
        /// <param name="edited">Thông tin cần cập nhật</param>
        /// <returns>Số lượng loại sản phẩm đã cập nhật</returns>
        public int AddCategory(LoaiSanPham add)
        {
            var result = loaiSP.AddCategory(add);
            return result;
        }

        public int UpdateCategory(LoaiSanPham edited)
        {
            var result = loaiSP.UpdateCategory(edited);
            return result;
        }

        public int DeleteCategoryById(int id)
        {
            int result = loaiSP.DeleteCategoryById(id);
            return result;
        }

        internal object UpdateCategory(object edited)
        {
            throw new NotImplementedException();
        }
    }

    
}
