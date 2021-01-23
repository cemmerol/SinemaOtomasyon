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
    public partial class SALONEKLE : Form
    {
        public SALONEKLE()
        {
            InitializeComponent();
        }

        private void SALONEKLE_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.ShowDialog();
        }

        sinemaTableAdapters.salonbilgileriTableAdapter salon = new sinemaTableAdapters.salonbilgileriTableAdapter();


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                salon.salonekleme(comboBox1.Text);
                MessageBox.Show("Salon Eklendi", "Kayıt");
            }
            catch (Exception)
            {

                MessageBox.Show("Aynı Salonu Daha Önce Eklediniz!!", "Uyarı");
            }
            comboBox1.Text = "";
        }
    }
}
