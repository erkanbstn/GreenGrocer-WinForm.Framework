using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public static class Baglanti
    {
        public static SqlConnection bgl = new SqlConnection("Data Source=GEOPC\\SQLEXPRESS;Initial Catalog=ManavDB;Integrated Security=True;MultipleActiveResultSets=True;");
    }
}
