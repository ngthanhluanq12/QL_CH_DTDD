using QL_CH_DTDD.DAO;
using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.BUS
{
   public class SuaSP_BUS
    {
        SuaSP_DAO SuaSP = new SuaSP_DAO();
        // get allcategory
        public BindingList<LoaiSanPham> GetAllCategories()
        {
            BindingList<LoaiSanPham> result = SuaSP.GetAllCategories();
            return result;
        }
        public int UpdateProduct(SanPham edited)
        {
            var result = SuaSP.UpdateProduct(edited);
            return result;
        }

        public int DeleteProductById(int id)
        {
            int result = SuaSP.DeleteProductById(id);
            return result;
        }
    }
}
