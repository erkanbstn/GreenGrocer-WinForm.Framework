using IsKatmani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarlikKatmani;

namespace ManavOtomasyon.Forms
{
    public partial class KategoriListe : Form
    {
        public KategoriListe()
        {
            InitializeComponent();
        }

        void Listele()
        {
            try
            {
                List<TKategori> kategori = TKategoriBll.KategoriListeBll();
                dataGridView1.DataSource = kategori;
            }
            catch (Exception)
            {

                MessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void KategoriListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TKategori t = new TKategori();
                t.Kategori = textBox2.Text;
                TKategoriBll.KategoriEkleBll(t);
                Listele();
                MessageBox.Show("Kategori Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                TKategoriBll.KategoriSilBll(id);
                Listele();
                MessageBox.Show("Kategori Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("İlişkili Değerleri Silmeye Çalışıyorsunuz Bunu Yapamazsınız.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                TKategori t = new TKategori();
                t.Kategori = textBox2.Text;
                t.KategoriID = Convert.ToInt32(textBox1.Text);
                TKategoriBll.KategoriGuncelleBll(t);
                Listele();
                MessageBox.Show("Kategori Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
