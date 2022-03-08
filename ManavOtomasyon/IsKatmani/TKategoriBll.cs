using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;
using VeriErisimKatmani;

namespace IsKatmani
{
    public class TKategoriBll
    {
        public static int KategoriEkleBll(TKategori t)
        {
            if (t.Kategori != "" && t.Kategori != null)
                return TKategoriDal.KategoriEkle(t);
            else
                return -1;
        }
        public static bool KategoriSilBll(int id)
        {
            if (id > 0)
                return TKategoriDal.KategoriSil(id);
            else
                return false;
        }
        public static bool KategoriGuncelleBll(TKategori t)
        {
            if (t.Kategori != null && t.Kategori != "" && t.KategoriID > 0)
                return TKategoriDal.KategoriGuncelle(t);
            else
                return false;
        }
        public static List<TKategori> KategoriListeBll()
        {
            return TKategoriDal.KategoriListe();
        }


    }
}
