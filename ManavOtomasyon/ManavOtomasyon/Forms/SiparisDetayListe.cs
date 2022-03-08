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
    public partial class SiparisDetayListe : Form
    {
        public SiparisDetayListe()
        {
            InitializeComponent();
        }


        void Listele()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Exec SiparisDetayListesi", Baglanti.bgl);
                DataTable t = new DataTable();
                ad.Fill(t);
                dataGridView1.DataSource = t;


                SqlCommand komut = new SqlCommand("Select * from TUrunler", Baglanti.bgl);
                SqlDataAdapter ad2 = new SqlDataAdapter(komut);
                DataTable t2 = new DataTable();
                ad2.Fill(t2);
                comboBox1.ValueMember = "UrunID";
                comboBox1.DisplayMember = "Urun";
                comboBox1.DataSource = t2;

                SqlCommand komut2 = new SqlCommand("Select * from TSiparisler", Baglanti.bgl);
                SqlDataAdapter ad3 = new SqlDataAdapter(komut2);
                DataTable t3 = new DataTable();
                ad3.Fill(t3);
                comboBox4.ValueMember = "SiparisID";
                comboBox4.DisplayMember = "SiparisAdres";
                comboBox4.DataSource = t3;

                SqlCommand komut3 = new SqlCommand("Select * from TOdemeler", Baglanti.bgl);
                SqlDataAdapter ad4 = new SqlDataAdapter(komut3);
                DataTable t4 = new DataTable();
                ad4.Fill(t4);
                comboBox3.ValueMember = "OdemeIslem";
                comboBox3.DisplayMember = "OdemeTur";
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
                SqlCommand komut = new SqlCommand("Insert into TSiparisDetaylar values (@p1,@p2,@p3,@p4)", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", Convert.ToInt32(comboBox4.SelectedValue));
                komut.Parameters.AddWithValue("@p2", Convert.ToInt32(comboBox1.SelectedValue));
                komut.Parameters.AddWithValue("@p3", textBox2.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(comboBox3.SelectedValue));
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Sipariş Detay Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Delete from TSiparisDetaylar Where SiparisDetayID=@p1", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Sipariş Detay Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Update TSiparisDetaylar Set Siparis=@p1,Urun=@p2,Adet=@p3,OdemeTuru=@p4 Where SiparisDetayID=@p5", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", Convert.ToInt32(comboBox4.SelectedValue));
                komut.Parameters.AddWithValue("@p2", Convert.ToInt32(comboBox1.SelectedValue));
                komut.Parameters.AddWithValue("@p3", textBox2.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(comboBox3.SelectedValue));
                komut.Parameters.AddWithValue("@p5", textBox1.Text);
                komut.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Sipariş Detay Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void SiparisDetayListe_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
