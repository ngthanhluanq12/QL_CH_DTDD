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
   public class DashBoard_BUS
    {
        DashBoard_DAO DashBoard = new DashBoard_DAO();

        // doc danh sach san pham
        public BindingList<SanPham> GetAllProduct()
        {
            BindingList<SanPham> result = DashBoard.GetAllProduct();
            return result;
        }

        // doc danh sach san pham
        public BindingList<SanPham> GetAllProductSmall()
        {
            BindingList<SanPham> result = DashBoard.GetAllProductSmall();
            return result;
        }
        // doc danh sach hoa don
        public BindingList<DonHang> GetAllCustomBill()
        {
            BindingList<DonHang> result = DashBoard.GetAllCustomBill();

            return result;
        }
    }
}
