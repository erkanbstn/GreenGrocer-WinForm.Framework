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
    public class TKategoriDal
    {
        public static int KategoriEkle(TKategori t)
        {
            SqlCommand komut = new SqlCommand("Insert into TKategoriler values (@p1)", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", t.Kategori);
            return komut.ExecuteNonQuery();
        }

        public static bool KategoriSil(int id)
        {
            SqlCommand komut = new SqlCommand("Delete from TKategoriler where KategoriID=@p1", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", id);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<TKategori> KategoriListe()
        {
            List<TKategori> listedegerleri = new List<TKategori>();
            SqlCommand komut = new SqlCommand("Select * from TKategoriler", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TKategori r = new TKategori();
                r.KategoriID = Convert.ToInt32(dr[0]);
                r.Kategori = dr[1].ToString();
                listedegerleri.Add(r);
            }
            dr.Close();
            return listedegerleri;
        }

        public static bool KategoriGuncelle(TKategori t)
        {
            SqlCommand komut = new SqlCommand("Update TKategoriler set Kategori=@p1 where KategoriID=@p2", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
                komut.Connection.Open();
            komut.Parameters.AddWithValue("@p1", t.Kategori);
            komut.Parameters.AddWithValue("@p2", t.KategoriID);
            return komut.ExecuteNonQuery() > 0;
        }
    }
}
