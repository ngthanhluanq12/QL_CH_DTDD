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
    public class SanPhamBUS
    {
       
        
        SanPhamDAO SanPham = new SanPhamDAO();
      
        public SanPham GetProductById(int id)
        {
            SanPham result = SanPham.GetProductById(id);

            return result;
        }

        public BindingList<SanPham> GetAllProduct()
        {
            BindingList<SanPham> result = SanPham.GetAllProduct();
            return result;
        }

        // get allcategory
        public BindingList<LoaiSanPham> GetAllCategories()
        {
            BindingList<LoaiSanPham> result = SanPham.GetAllCategories();
            return result;
        }


        public BindingList<SanPham> FilterPrice(int star, int end)
        {
            BindingList<SanPham> result = SanPham.FilterPrice(star, end);

            return result;
        }


    }


}
