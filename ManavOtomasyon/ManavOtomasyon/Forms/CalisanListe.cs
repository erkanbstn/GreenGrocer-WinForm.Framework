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
    public partial class CalisanListe : Form
    {
        public CalisanListe()
        {
            InitializeComponent();
        }
        void Listele()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Exec CalisanListesi", Baglanti.bgl);
                DataTable t = new DataTable();
                ad.Fill(t);
                dataGridView1.DataSource = t;

                SqlCommand komut3 = new SqlCommand("Select * from TRutbeler", Baglanti.bgl);
                SqlDataAdapter ad4 = new SqlDataAdapter(komut3);
                DataTable t4 = new DataTable();
                ad4.Fill(t4);
                comboBox3.ValueMember = "RutbeID";
                comboBox3.DisplayMember = "Rutbe";
                comboBox3.DataSource = t4;



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
                SqlCommand komut = new SqlCommand("Insert into TCalisanlar values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1",textBox3.Text);
                komut.Parameters.AddWithValue("@p2",textBox4.Text);
                komut.Parameters.AddWithValue("@p3",maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p4",richTextBox1.Text);
                komut.Parameters.AddWithValue("@p5",maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@p6",maskedTextBox3.Text);
                komut.Parameters.AddWithValue("@p7",comboBox3.Text);
                komut.Parameters.AddWithValue("@p8",textBox5.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Çalışan Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Delete from TCalisanlar Where CalisanID=@p1", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Çalışan Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Update TCalisanlar Set Isim=@p1,Soyisim=@p2,TC=@p3,Adres=@p4,Telefon=@p5,IseGirisTarih=@p6,Rutbe=@p7,Maas=@p8 Where CalisanID=@p9", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox3.Text);
                komut.Parameters.AddWithValue("@p2", textBox4.Text);
                komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
                komut.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@p6", maskedTextBox3.Text);
                komut.Parameters.AddWithValue("@p7", comboBox3.Text);
                komut.Parameters.AddWithValue("@p8", textBox5.Text);
                komut.Parameters.AddWithValue("@p9", textBox1.Text);
                komut.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Çalışan Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CalisanListe_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
