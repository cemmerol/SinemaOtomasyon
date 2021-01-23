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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-KF846PE\\SQLEXPRESS;Initial Catalog=sinema_bileti;Integrated Security=True");



        int sayac = 0;

        private void filmvesalongetir(ComboBox combo,string sql1,string sql2)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand(sql1,baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                combo.Items.Add(read[sql2].ToString());

            }
            baglantı.Close();
        }

        private void filmafişigöster()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from filmbilgileri where FilmAdı='"+comboBox1.SelectedItem+"'",baglantı);
            SqlDataReader read = komut.ExecuteReader();
             while (read.Read())
            {
                pictureBox1.ImageLocation = read["resim"].ToString();


            }
            baglantı.Close();
        }

        private void combodolukoltuklar()
        {
            comboBox9.Items.Clear();
            comboBox9.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor==Color.Red)
                    {
                        comboBox9.Items.Add(item.Text);
                    }

                }
            }



        }



        private void yenidenrenklendir()
        {

            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;

                }
            }

        }
        private void dolukoltuklar()
        {

            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from satısbilgileri where filmadı='" + comboBox1.SelectedItem + "' and salonadı='"+comboBox2.Text+"' and tarih='"+comboBox8.SelectedItem+"'and saat='"+comboBox7.SelectedItem+"'",baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (read["koltukno"].ToString() == item.Text)
                        {
                            item.BackColor = Color.Red;
                        }
                       
                    }
                }
            }
            baglantı.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            boşkoltuklar();

            filmvesalongetir(comboBox1,"select*from filmbilgileri","FilmAdı");
            filmvesalongetir(comboBox2, "select*from salonbilgileri", "salonadı");
            
        }

        private void boşkoltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }



                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;



                }

            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == Color.White)
            {
                comboBox6.Text = b.Text;

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SALONEKLE ekle = new SALONEKLE();
            ekle.Show();
            this.Hide();
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            filmekle ekle = new filmekle();
            ekle.ShowDialog();
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            seansekleme ekle = new seansekleme();
            ekle.ShowDialog();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            satıslisteleme satis = new satıslisteleme();
            satis.ShowDialog();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SEANSLİSTELE liste = new SEANSLİSTELE();
            liste.ShowDialog();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox2.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";

            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
 
            filmafişigöster();
            yenidenrenklendir();
            combodolukoltuklar();
           
        }

        private void Filmtarihigetir()
        {
            comboBox8.Text = "";
            comboBox7.Text = "";
            comboBox8.Items.Clear();
            comboBox7.Items.Clear();

            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from seansbilgileri where filmadı='" + comboBox1.SelectedItem + "'and salonadı='" + comboBox2.SelectedItem + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                if (DateTime.Parse(read["tarih"].ToString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (!comboBox1.Items.Contains(read["tarih"].ToString()))
                    {
                        comboBox8.Items.Add(read["tarih"].ToString());
                    }
                    

                }
            }
            baglantı.Close();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filmtarihigetir();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
        sinemaTableAdapters.satısbilgileriTableAdapter satis = new sinemaTableAdapters.satısbilgileriTableAdapter();
       
        
        private void button8_Click(object sender, EventArgs e)
        {

            
            if (comboBox6.Text!="")
            {
                try
                {
                    satis.satısyap(comboBox6.Text, comboBox2.Text, comboBox1.Text, comboBox8.Text, comboBox7.Text, comboBox5.Text, comboBox4.Text, comboBox3.Text, DateTime.Now.ToString());
                    foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                    yenidenrenklendir();
                    dolukoltuklar();
                    combodolukoltuklar();
                    MessageBox.Show("Bilet Satıldı!!");
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata Oluştu !!!"+hata.Message, "Uyarı");
                } 
            }
            else 
            {
                MessageBox.Show("Koltuk Seçimi Yapmadınız !!", "Uyarı");

            }
            
        }
        private void Filmseansıgetir()
        {

            comboBox7.Text = "";
            comboBox7.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from seansbilgileri where filmadı='" + comboBox1.SelectedItem + "'and salonadı='" + comboBox2.SelectedItem + "'and tarih='"+comboBox8.SelectedItem+"'", baglantı);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                if (DateTime.Parse(read["tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {

                    if (DateTime.Parse(read["seans"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                    {
                        comboBox7.Items.Add(read["seans"].ToString());
                    }
                     
                }
                else if (DateTime.Parse(read["tarih"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    
                        comboBox7.Items.Add(read["seans"].ToString());
                    


                }
            }
            baglantı.Close();


        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filmseansıgetir();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            yenidenrenklendir();
            dolukoltuklar();
            combodolukoltuklar();

        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox9.Text!="")
            {
                try
                {
                    satis.satısiptal(comboBox1.Text, comboBox2.Text, comboBox8.Text, comboBox7.Text, comboBox9.Text);
                    yenidenrenklendir();
                    dolukoltuklar();
                    combodolukoltuklar();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata Oluştu!!"+hata.Message, "Uyarı");

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Henüz Koltuk Seçimi Yapmadınız!!","Uyarı");
            }       
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
