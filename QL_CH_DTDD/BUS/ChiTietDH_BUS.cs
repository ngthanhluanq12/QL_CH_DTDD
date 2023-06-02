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
   public class ChiTietDH_BUS
    {
        ChiTietDH_DAO DonHang = new ChiTietDH_DAO();

        public BindingList<DonHang> GetAllCustomBill()
        {
            BindingList<DonHang> result = DonHang.GetAllCustomBill();

            return result;
        }
        public SanPham GetProductById(int id)
        {
            SanPham result = DonHang.GetProductById(id);

            return result;
        }
    }
}
