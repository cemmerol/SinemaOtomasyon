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
    public partial class satıslisteleme : Form
    {
        public satıslisteleme()
        {
            InitializeComponent();
        }

        sinemaTableAdapters.satısbilgileriTableAdapter satıslitesi = new sinemaTableAdapters.satısbilgileriTableAdapter();

        private void satıslisteleme_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = satıslitesi.tarihegörelistele2(dateTimePicker1.Text);
            Toplamücrethesapla();

        }

        private void Toplamücrethesapla()
        {
            int ücrettoplam = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ücrettoplam += Convert.ToInt32(dataGridView1.Rows[i].Cells["ücret"].Value);

            }

            label1.Text = "Toplam Satış=" + ücrettoplam + "TL";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satıslitesi.satışlistesi2();
            Toplamücrethesapla();
        }
        // TARİHE GÖRE SATIŞLARI GÖSTERMEDE SIKINTI VAR!!
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satıslitesi.tarihegörelistele2(dateTimePicker1.Text);
            Toplamücrethesapla();
        }
    }
}
