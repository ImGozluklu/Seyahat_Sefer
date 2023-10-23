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

namespace Seyahat_Sefer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-SP67UG4\SQLEXPRESS;Initial Catalog=TestYolcuBilet;Integrated Security=True");

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLYOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl);
            komut.Parameters.AddWithValue("@p1", mskad.Text);
            komut.Parameters.AddWithValue("@p2", msksoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", mskmail.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Yolcu Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        }

        private void btnkaptan_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into tblkaptan (kaptanno,adsoyad, telefon) values(@p1, @p2, @p3)", bgl);
            komut.Parameters.AddWithValue("@p1", txtkaptanno.Text);
            komut.Parameters.AddWithValue("@p2", txtkaptanad.Text);
            komut.Parameters.AddWithValue("@p3", mskkaptantel.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERBILGI (KALKIS, VARIS, TARIH, SAAT ,KAPTAN, FIYAT) values (@p1, @p2, @p3, @p4, @p5, @p6)", bgl);
            komut.Parameters.AddWithValue("@p1", txtkalkis.Text);
            komut.Parameters.AddWithValue("@p2", txtvaris.Text);
            komut.Parameters.AddWithValue("@p3", msktarih.Text);
            komut.Parameters.AddWithValue("@p4", msksaat.Text);
            komut.Parameters.AddWithValue("@p5", mskkaptan.Text);
            komut.Parameters.AddWithValue("@p6", mskfiyat.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }
        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLSEFERBILGI",bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void rezervasyonlistele()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("select * from TBLSEFERDETAY", bgl);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
            rezervasyonlistele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtsefernumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "9";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values (@p1,@p2,@p3)",bgl);
            komut.Parameters.AddWithValue("@p1", txtsefernumara.Text);
            komut.Parameters.AddWithValue("@p2", mskyolcutc.Text);
            komut.Parameters.AddWithValue("@p3", txtkoltukno.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Rezervasyon başarıyla yapıldı.");
            rezervasyonlistele();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
