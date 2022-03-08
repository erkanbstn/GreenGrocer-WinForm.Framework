using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace VeriErisimKatmani
{
    public class TOdemeDal
    {
        public static int OdemeEkle(TOdeme t)
        {
            SqlCommand komut = new SqlCommand("Insert into TOdemeler values (@p1)", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", t.OdemeTur);
            return komut.ExecuteNonQuery();
        }

        public static bool OdemeSil(int id)
        {
            SqlCommand komut = new SqlCommand("Delete from TOdemeler where OdemeIslem=@p1", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", id);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<TOdeme> OdemeListe()
        {
            List<TOdeme> listedegerleri = new List<TOdeme>();
            SqlCommand komut = new SqlCommand("Select * from TOdemeler", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TOdeme r = new TOdeme();
                r.OdemeIslem = Convert.ToInt32(dr[0]);
                r.OdemeTur = dr[1].ToString();
                listedegerleri.Add(r);
            }
            dr.Close();
            return listedegerleri;
        }

        public static bool OdemeGuncelle(TOdeme t)
        {
            SqlCommand komut = new SqlCommand("Update TOdemeler set OdemeTur=@p1 where OdemeIslem=@p2", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", t.OdemeTur);
            komut.Parameters.AddWithValue("@p2", t.OdemeIslem);
            return komut.ExecuteNonQuery() > 0;
        }
    }
}
