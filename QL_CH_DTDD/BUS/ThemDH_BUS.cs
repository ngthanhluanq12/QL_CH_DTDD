using QL_CH_DTDD.DAO;
using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.BUS
{
   public class ThemDH_BUS
    {
        ThemDH_DAO ThemDH = new ThemDH_DAO();

        public int AddCustomBill(DonHang edited)
        {
            var result = ThemDH.AddCustomBill(edited);
            return result;
        }
        public int UpdateProductEndNum(int id, int num)
        {
            var result = ThemDH.UpdateProductEndNum(id, num);
            return result;
        }
    }
}
