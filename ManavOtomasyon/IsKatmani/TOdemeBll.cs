using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;
using VeriErisimKatmani;

namespace IsKatmani
{
    public class TOdemeBll
    {
        public static int OdemeEkleBll(TOdeme t)
        {
            if (t.OdemeTur != "" && t.OdemeTur != null)
                return TOdemeDal.OdemeEkle(t);
            else
                return -1;
        }

        public static bool OdemeSilBll(int id)
        {
            if (id > 0)
                return TOdemeDal.OdemeSil(id);
            else
                return false;
        }
        public static bool OdemeGuncelleBll(TOdeme t)
        {
            if (t.OdemeTur != null && t.OdemeTur != "" && t.OdemeIslem > 0)
                return TOdemeDal.OdemeGuncelle(t);
            else
                return false;
        }
        public static List<TOdeme> OdemeListeBll()
        {
            return TOdemeDal.OdemeListe();
        }
    }
}
