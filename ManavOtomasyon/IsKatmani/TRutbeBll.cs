using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;
using VeriErisimKatmani;

namespace IsKatmani
{
    public class TRutbeBll
    {
        public static int RutbeEkleBll(TRutbe t)
        {
            if (t.Rutbe != "" && t.Rutbe != null)
                return TRutbeDal.RutbeEkle(t);
            else
                return -1;
        }

        public static bool RutbeSilBll(int id)
        {
            if (id > 0)
                return TRutbeDal.RutbeSil(id);
            else
                return false;
        }
        public static bool RutbeGuncelleBll(TRutbe t)
        {
            if (t.Rutbe != null && t.Rutbe != "" && t.RutbeID > 0)
                return TRutbeDal.RutbeGuncelle(t);
            else
                return false;
        }
        public static List<TRutbe> RutbeListeBll()
        {
            return TRutbeDal.RutbeListe();
        }
    }
}
