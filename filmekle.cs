using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaBiletOtomasyon
{
    public partial class filmekle : Form
    {
        public filmekle()
        {
            InitializeComponent();
        }

        // sinemaTableAdapters.filmbilgileriTableAdapter film = new sinemaTableAdapters.filmbilgileriTableAdapter();
        sinemaTableAdapters.filmbilgileriTableAdapter film = new sinemaTableAdapters.filmbilgileriTableAdapter();


        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               // film.FilmEkleme(comboBox1.Text, comboBox5.Text, comboBox4.Text, comboBox3.Text, dateTimePicker1.Text, comboBox2.Text, pictureBox1.ImageLocation);
               film.filmekleme(comboBox1.Text, comboBox5.Text, comboBox4.Text, comboBox3.Text, dateTimePicker1.Text, comboBox2.Text, pictureBox1.ImageLocation);
                MessageBox.Show("Film Bilgileri Eklendi!", "Kayıt");
            
            }
            catch (Exception)
            {

                MessageBox.Show("Bu filmi daha önce eklediniz !!", "Uyarı");
                throw;
            }



            
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            comboBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";

        }

        private void filmekle_Load(object sender, EventArgs e)
        {

        }
    }
}
