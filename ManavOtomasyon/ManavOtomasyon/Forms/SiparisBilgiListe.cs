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
    public partial class SiparisBilgiListe : Form
    {
        public SiparisBilgiListe()
        {
            InitializeComponent();
        }
        void Listele()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select * from SiparisListesi", Baglanti.bgl);
                DataTable t = new DataTable();
                ad.Fill(t);
                dataGridView1.DataSource = t;


                SqlCommand komut = new SqlCommand("Select * from TCalisanlar", Baglanti.bgl);
                SqlDataAdapter ad2 = new SqlDataAdapter(komut);
                DataTable t2 = new DataTable();
                ad2.Fill(t2);
                comboBox2.ValueMember = "CalisanID";
                comboBox2.DisplayMember = "Isim";
                comboBox2.DataSource = t2;

                SqlCommand komut2 = new SqlCommand("Select * from TMusteriler", Baglanti.bgl);
                SqlDataAdapter ad3 = new SqlDataAdapter(komut2);
                DataTable t3 = new DataTable();
                ad3.Fill(t3);
                comboBox1.ValueMember = "MusteriID";
                comboBox1.DisplayMember = "Isim";
                comboBox1.DataSource = t3;

                SqlCommand komut3 = new SqlCommand("Select * from TKargolar", Baglanti.bgl);
                SqlDataAdapter ad4 = new SqlDataAdapter(komut3);
                DataTable t4 = new DataTable();
                ad4.Fill(t4);
                comboBox3.ValueMember = "KargoID";
                comboBox3.DisplayMember = "Kargo";
                comboBox3.DataSource = t4;



            }
            catch (Exception)
            {

                MessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void SiparisBilgiListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Insert into TSiparisler values (@p1,@p2,@p3,@p4)", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", Convert.ToInt32(comboBox1.SelectedValue));
                komut.Parameters.AddWithValue("@p2", Convert.ToInt32(comboBox2.SelectedValue));
                komut.Parameters.AddWithValue("@p3", Convert.ToInt32(comboBox3.SelectedValue));
                komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Sipariş Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Delete from TSiparisler Where SiparisID=@p1", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Sipariş Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Update TSiparisler Set Musteri=@p1,Calisan=@p2,Kargo=@p3,SiparisAdres=@p4 Where SiparisID=@p5", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", Convert.ToInt32(comboBox1.SelectedValue));
                komut.Parameters.AddWithValue("@p2", Convert.ToInt32(comboBox2.SelectedValue));
                komut.Parameters.AddWithValue("@p3", Convert.ToInt32(comboBox3.SelectedValue));
                komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
                komut.Parameters.AddWithValue("@p5", textBox1.Text);
                komut.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Sipariş Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
