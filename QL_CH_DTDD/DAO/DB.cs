using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DAO
{
    public class DB
    {
        public static string ConnectionString()
        {
            string result = @"Data Source=LAPTOP_DELL\SQLEXPRESS;Initial Catalog=QL_DTDD_DB;Integrated Security=True;";
            return result;
        }

  

    }
}
