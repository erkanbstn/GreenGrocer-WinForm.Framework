using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManavOtomasyon.Forms
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        KargoListe f;
        KategoriListe f2;
        OdemeListe f3;
        RutbeListe f4;
        TedarikciListe f5;
        SiparisBilgiListe f8;
        SiparisDetayListe f9;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f8 == null || f8.IsDisposed)
            {
                f8 = new SiparisBilgiListe();
                f8.MdiParent = this;
                f8.Show();
            }
            else
            {
                f8.Focus();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(f2==null || f2.IsDisposed)
            {
                f2 = new KategoriListe();
                f2.MdiParent= this;
                f2.Show();
            }
            else
            {
                f2.Focus();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f5 == null || f5.IsDisposed)
            {
                f5 = new TedarikciListe();
                f5.MdiParent = this;
                f5.Show();
            }
            else
            {
                f5.Focus();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f4 == null || f4.IsDisposed)
            {
                f4 = new RutbeListe();
                f4.MdiParent = this;
                f4.Show();
            }
            else
            {
                f4.Focus();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f3 == null || f3.IsDisposed)
            {
                f3 = new OdemeListe();
                f3.MdiParent = this;
                f3.Show();
            }
            else
            {
                f3.Focus();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f == null || f.IsDisposed)
            {
                f = new KargoListe();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Focus();
            }
        }
        MusteriListe f6;
        UrunListe f7;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f6 == null || f6.IsDisposed)
            {
                f6 = new MusteriListe();
                f6.MdiParent = this;
                f6.Show();
            }
            else
            {
                f6.Focus();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f7 == null || f7.IsDisposed)
            {
                f7 = new UrunListe();
                f7.MdiParent = this;
                f7.Show();
            }
            else
            {
                f7.Focus();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f9 == null || f9.IsDisposed)
            {
                f9 = new SiparisDetayListe();
                f9.MdiParent = this;
                f9.Show();
            }
            else
            {
                f9.Focus();
            }
        }
        CalisanListe f10;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f10 == null || f10.IsDisposed)
            {
                f10 = new CalisanListe();
                f10.MdiParent = this;
                f10.Show();
            }
            else
            {
                f10.Focus();
            }
        }
    }
}
