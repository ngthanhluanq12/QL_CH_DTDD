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
    public class ThemSP_BUS
    {
        ThemSP_DAO ThemSP = new ThemSP_DAO();
        public SanPham GetProductById(int id)
        {
            SanPham result = ThemSP.GetProductById(id);

            return result;
        }

        public BindingList<SanPham> GetAllProduct()
        {
            BindingList<SanPham> result = ThemSP.GetAllProduct();
            return result;
        }

        // get allcategory
        public BindingList<LoaiSanPham> GetAllCategories()
        {
            BindingList<LoaiSanPham> result = ThemSP.GetAllCategories();
            return result;
        }
        /// <summary>
        /// Cập nhật loại sản phẩm
        /// </summary>
        /// <param name="edited">Thông tin cần cập nhật</param>
        /// <returns>Số lượng loại sản phẩm đã cập nhật</returns>
        public int AddProduct(SanPham edited)
        {
            var result = ThemSP.AddProduct(edited);
            return result;
        }
    }
}
