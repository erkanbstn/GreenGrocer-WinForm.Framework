using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;
using System.Data.SqlClient;
using System.Data;
namespace VeriErisimKatmani
{
    public class TRutbeDal
    {
        public static int RutbeEkle(TRutbe t)
        {
            SqlCommand komut = new SqlCommand("Insert into TRutbeler values (@p1)", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", t.Rutbe);
            return komut.ExecuteNonQuery();
        }

        public static bool RutbeSil(int id)
        {
            SqlCommand komut = new SqlCommand("Delete from TRutbeler where RutbeID=@p1", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", id);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<TRutbe> RutbeListe()
        {
            List<TRutbe> listedegerleri = new List<TRutbe>();
            SqlCommand komut = new SqlCommand("Select * from TRutbeler", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TRutbe r = new TRutbe();
                r.RutbeID = Convert.ToInt32(dr[0]);
                r.Rutbe = dr[1].ToString();
                listedegerleri.Add(r);
            }
            dr.Close();
            return listedegerleri;
        }

        public static bool RutbeGuncelle(TRutbe t)
        {
            SqlCommand komut = new SqlCommand("Update TRutbeler set Rutbe=@p1 where RutbeID=@p2", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", t.Rutbe);
            komut.Parameters.AddWithValue("@p2", t.RutbeID);
            return komut.ExecuteNonQuery() > 0;
        }
    }
}
