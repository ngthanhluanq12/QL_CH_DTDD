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
  public  class DanhSachDH_BUS
    {
        DanhSachDH_DAO DonHang = new DanhSachDH_DAO();

        public DonHang GetCustomBillById(int id)
        {
            DonHang result = DonHang.GetCustomBillById(id);

            return result;
        }

        public BindingList<DonHang> GetAllCustomBill()
        {
            BindingList<DonHang> result = DonHang.GetAllCustomBill();

            return result;
        }

        public int UpdateCustomBill(DonHang edited)
        {
            var result = DonHang.UpdateCustomBill(edited);
            return result;
        }

        public int DeleteCustomBillById(int id)
        {
            int result = DonHang.DeleteCustomBillById(id);
            return result;
        }
        public BindingList<DonHang> FilterCustomBill(DateTime star, DateTime end)
        {
            BindingList<DonHang> result = DonHang.FilterCustomBill(star, end);

            return result;
        }
    }
}
