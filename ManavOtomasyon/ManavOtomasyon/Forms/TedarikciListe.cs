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
using VeriErisimKatmani;

namespace ManavOtomasyon.Forms
{
    public partial class TedarikciListe : Form
    {
        public TedarikciListe()
        {
            InitializeComponent();
        }
        void Listele()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Exec TedarikciListesi", Baglanti.bgl); // Procedure Oluşumu ve Kullanımı
                DataTable t = new DataTable();
                ad.Fill(t);
                dataGridView1.DataSource = t;
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

        private void TedarikciListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Insert into TTedarikciler values (@p1,@p2)", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Tedarikçi Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Delete from TTedarikciler Where TedarikciID=@p1", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Tedarikçi Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Update TTedarikciler Set Tedarikci=@p1,TedarikciNo=@p2 Where TedarikciID=@p3", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p3", textBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Tedarikçi Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
