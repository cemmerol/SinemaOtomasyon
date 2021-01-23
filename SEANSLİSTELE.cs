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

namespace SinemaBiletOtomasyon
{
    public partial class SEANSLİSTELE : Form
    {


        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-KF846PE\\SQLEXPRESS;Initial Catalog=sinema_bileti;Integrated Security=True");
        DataTable tablo = new DataTable();
        
        private void seanslistesi(string sql)
        {
            baglantı.Open();

            SqlDataAdapter adtr = new SqlDataAdapter(sql,baglantı);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }
        public SEANSLİSTELE()
        {
            InitializeComponent();
        }

        
        // SEÇİLİ TARİHTEKİ SEANSLARI GÖSTERMEDE SORUN VAR!!!!!!!!!!!!!!!!!//
        private void SEANSLİSTELE_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            seanslistesi("select*from seansbilgileri where tarih like '"+ dateTimePicker1.Text +"'"); 


        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            seanslistesi("select*from seansbilgileri where tarih like '" + dateTimePicker1.Text + "'");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            seanslistesi("select*from seansbilgileri");

        }
    }
}
