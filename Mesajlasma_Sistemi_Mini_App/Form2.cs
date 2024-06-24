using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mesajlasma_Sistemi_Mini_App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3JI920O\SQLEXPRESS;Initial Catalog=DbMesajlasmaSistemi;Integrated Security=True");

        void gelenKutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select GONDEREN,BASLIK,ICERIK from TBLMESAJLAR where ALICI=" + numara, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvGelen.DataSource = dt1;
        }
    
        void gidenKutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select ALICI,BASLIK,ICERIK from TBLMESAJLAR where GONDEREN=" + numara, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvGiden.DataSource = dt2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblNum.Text = numara;
            gelenKutusu();
            gidenKutusu();

            // Ad ve Soyad Çekme
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select AD,SOYAD from TBLKISILER where NUMARA=" + numara, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLMESAJLAR (GONDEREN,ALICI,BASLIK,ICERIK) values (@p1,@p2,@p3,@p4)", conn);
            cmd.Parameters.AddWithValue("@p1", numara);
            cmd.Parameters.AddWithValue("@p2", mskAlici.Text);
            cmd.Parameters.AddWithValue("@p3", txtBaslik.Text);
            cmd.Parameters.AddWithValue("@p4", rtxtMesaj.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Mesajınız Gönderildi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon
                .Information);
            gidenKutusu();
        }
    }
}
