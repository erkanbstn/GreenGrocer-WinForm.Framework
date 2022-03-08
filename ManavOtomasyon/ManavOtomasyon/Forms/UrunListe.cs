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
    public partial class UrunListe : Form
    {
        public UrunListe()
        {
            InitializeComponent();
        }
        void Listele()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Exec UrunListesi", Baglanti.bgl);
                DataTable t = new DataTable();
                ad.Fill(t);
                dataGridView1.DataSource = t;


                SqlCommand komut = new SqlCommand("Select * from TKategoriler", Baglanti.bgl);
                SqlDataAdapter ad2 = new SqlDataAdapter(komut);
                DataTable t2 = new DataTable();
                ad2.Fill(t2);
                comboBox1.ValueMember = "KategoriID";
                comboBox1.DisplayMember = "Kategori";
                comboBox1.DataSource = t2;

                SqlCommand komut2 = new SqlCommand("Select * from TTedarikciler", Baglanti.bgl);
                SqlDataAdapter ad3 = new SqlDataAdapter(komut2);
                DataTable t3 = new DataTable();
                ad3.Fill(t3);
                comboBox2.ValueMember = "TedarikciID";
                comboBox2.DisplayMember = "Tedarikci";
                comboBox2.DataSource = t3;



            }
            catch (Exception)
            {

                MessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void UrunListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Insert into TUrunler values (@p1,@p2,@p3,@p4,@p5,@p6)", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                komut.Parameters.AddWithValue("@p3", textBox5.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(comboBox2.SelectedValue));
                komut.Parameters.AddWithValue("@p5", Convert.ToInt32(comboBox1.SelectedValue));
                komut.Parameters.AddWithValue("@p6", textBox7.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Ürün Ekleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Delete from TUrunler Where UrunID=@p1", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Ürün Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand komut = new SqlCommand("Update TUrunler Set Urun=@p1,Stok=@p2,Fiyat=@p3,Tedarikci=@p4,Kategori=@p5,AlisFiyat=@p6 Where UrunID=@p7", Baglanti.bgl);
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                komut.Parameters.AddWithValue("@p3", textBox5.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(comboBox2.SelectedValue));
                komut.Parameters.AddWithValue("@p5", Convert.ToInt32(comboBox1.SelectedValue));
                komut.Parameters.AddWithValue("@p6", textBox7.Text);
                komut.Parameters.AddWithValue("@p7", textBox1.Text);
                komut.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                Baglanti.bgl.Close();
                Listele();
                MessageBox.Show("Ürün Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
