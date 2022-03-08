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
    public partial class RutbeListe : Form
    {
        public RutbeListe()
        {
            InitializeComponent();
        }
        void Listele()
        {
            try
            {
                List<TRutbe> rutbe = TRutbeBll.RutbeListeBll();
                dataGridView1.DataSource = rutbe;
            }
            catch (Exception)
            {

                MessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void RutbeListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TRutbe t = new TRutbe();
                t.Rutbe = textBox2.Text;
                TRutbeBll.RutbeEkleBll(t);
                Listele();
                MessageBox.Show("Rütbe Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TRutbeBll.RutbeSilBll(id);
                Listele();
                MessageBox.Show("Rütbe Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TRutbe t = new TRutbe();
                t.Rutbe = textBox2.Text;
                t.RutbeID = Convert.ToInt32(textBox1.Text);
                TRutbeBll.RutbeGuncelleBll(t);
                Listele();
                MessageBox.Show("Rütbe Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
