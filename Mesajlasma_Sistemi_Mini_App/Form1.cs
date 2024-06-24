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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3JI920O\SQLEXPRESS;Initial Catalog=DbMesajlasmaSistemi;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBLKISILER where NUMARA=@p1 and SIFRE=@p2", conn);
            cmd.Parameters.AddWithValue("@p1", mskNumara.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 fr = new Form2();
                fr.numara = mskNumara.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
            conn.Close();
        }
    }
}
