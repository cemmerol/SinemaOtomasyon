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
    public partial class seansekleme : Form
    {
        public seansekleme()
        {
            InitializeComponent();
        }

        string seans = "";

        private void seçilibuton()
        {
              if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if (radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if(radioButton6.Checked == true) seans = radioButton6.Text;
            else if(radioButton7.Checked == true) seans = radioButton7.Text;
            else if(radioButton8.Checked == true) seans = radioButton8.Text;
            else if(radioButton9.Checked == true) seans = radioButton9.Text;
            else if(radioButton10.Checked == true) seans = radioButton10.Text;
            else if(radioButton11.Checked == true) seans = radioButton11.Text;
            else if(radioButton12.Checked == true) seans = radioButton12.Text;
           

        }




        private void button1_Click(object sender, EventArgs e)
        {

            seçilibuton();
            if (seans!= "")
            {

                seçilibuton();
                filmseansı.seansekleme(comboBox1.Text, comboBox3.Text, dateTimePicker1.Text, seans);
                MessageBox.Show("Seans Ekleme İşemi Gerçekleştirildi.", "Kayıt");

            }
            else if (seans == "")
            {
                MessageBox.Show("Seçim Yapmadınız!", "Uyarı!");

            }
            comboBox1.Text="";
            comboBox3.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString();
        }


        sinemaTableAdapters.seansbilgileriTableAdapter filmseansı = new sinemaTableAdapters.seansbilgileriTableAdapter();

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-KF846PE\\SQLEXPRESS;Initial Catalog=sinema_bileti;Integrated Security=True");

        private void filmvesalongöster(ComboBox combo,string sql,string sql2)
        {

            baglantı.Open();
            SqlCommand komut = new SqlCommand(sql, baglantı);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read()==true)
            {
                combo.Items.Add(read[sql2].ToString());



            }
            baglantı.Close();
        }
        
        
        private void seansekleme_Load(object sender, EventArgs e)
        {
            filmvesalongöster(comboBox1, "select*from filmbilgileri", "filmAdı");
            filmvesalongöster(comboBox3, "select*from salonbilgileri", "salonadı");


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;


            }

            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni == bugün)
            {

             tarihkarşılaştır();

            }

            else if(yeni>bugün){ tarihkarşılaştır(); }
            else if (yeni < bugün) { MessageBox.Show("Geçmiş Tarih İle İşem yapamazsınız!!", "Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }



        }

        private void tarihkarşılaştır()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select*from seansbilgileri where salonadı='" + comboBox3.Text + "'and tarih='" + dateTimePicker1.Text + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {

                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;

                    }

                }


            }
            baglantı.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
