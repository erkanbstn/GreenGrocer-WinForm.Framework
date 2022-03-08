using IsKatmani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarlikKatmani;

namespace ManavOtomasyon.Forms
{
    public partial class OdemeListe : Form
    {
        public OdemeListe()
        {
            InitializeComponent();
        }
        void Listele()
        {
            try
            {
                List<TOdeme> Odeme = TOdemeBll.OdemeListeBll();
                dataGridView1.DataSource = Odeme;
            }
            catch (Exception)
            {

                MessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TOdeme t = new TOdeme();
                t.OdemeTur = textBox2.Text;
                TOdemeBll.OdemeEkleBll(t);
                Listele();
                MessageBox.Show("Yöntem Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void OdemeListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                TOdemeBll.OdemeSilBll(id);
                Listele();
                MessageBox.Show("Yöntem Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TOdeme t = new TOdeme();
                t.OdemeTur = textBox2.Text;
                t.OdemeIslem = Convert.ToInt32(textBox1.Text);
                TOdemeBll.OdemeGuncelleBll(t);
                Listele();
                MessageBox.Show("Yöntem Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
