using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class tangma
    {
        string connect = @"Data Source=LONGHOANG\LONGHOANG;Initial Catalog=BANDICHVU;Integrated Security=True";
        public string matutang()
        {
            string sql = "select * from hoadon";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string code = "";
            if (dt.Rows.Count <= 0)
            {
                code = "HD001";
            }
            else
            {
                int k;
                code = "HD";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count-1][0].ToString().Substring(2,3));
                k = k + 1;
                if (k < 10)
                {
                    code = code + "00";
                }
                else if(k<100)
                {
                    code = code + "0";
                }
                code = code + k.ToString();
            }
            return code;
        }
    }
}
