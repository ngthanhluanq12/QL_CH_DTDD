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
   public class ThongKeBUS
    {
        ThongKeDAO ThongKe = new ThongKeDAO();

        public BindingList<LoaiSanPham> GetAllCategories()
        {
            BindingList<LoaiSanPham> result = ThongKe.GetAllCategories();
            return result;
        }


        public BindingList<DonHang> GetAllCustomBill()
        {
            BindingList<DonHang> result = ThongKe.GetAllCustomBill();

            return result;
        }

    }
}
