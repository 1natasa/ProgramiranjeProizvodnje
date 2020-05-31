using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProgramiranjeProizvodnje
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder();
            ccnSb.DataSource = @"DESKTOP-GIM6L3G\SQLEXPRESS";
            ccnSb.InitialCatalog = @"ProgramiranjeProizvodnje";
            ccnSb.IntegratedSecurity = true;

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;

        }
    }
}
