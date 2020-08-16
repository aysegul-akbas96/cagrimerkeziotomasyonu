using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÇağrıMerkeziProjesi__LinqStoreProcedure_19Nisan
{
    public partial class Ödm : Form
    {
        public Ödm()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        public void listele()
        {
            var götütüle = baglanti.ÖdemeListeleme();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = götütüle.ToList();
        }
        private void button5_Click(object sender, EventArgs e)
        {

            Form2 Git = new Form2();
            Git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Ödm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Musterilers.ToList();
            comboBox1.ValueMember = "MusteriNo";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Musterino =Convert.ToInt32(comboBox1.Text);
            string tip = textBox2.Text;
            string tarih = dateTimePicker1.Text;
            decimal tutar = Convert.ToDecimal(textBox3.Text);
            int gecikme = Convert.ToInt32(textBox4.Text);
            int faiz = Convert.ToInt32(textBox5.Text);

            var ekle = baglanti.OdemeEkleme(Musterino,tip,tarih,tutar,gecikme,faiz);
            baglanti.SubmitChanges();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(textBox1.Text);
            baglanti.ÖdemeSil(id);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["Ödemeno"].Value.ToString();
            comboBox1.Text = satir.Cells["MusteriNo"].Value.ToString();
            textBox2.Text = satir.Cells["Tipi"].Value.ToString();
            textBox3.Text = satir.Cells["ÖdemeTutarı"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["ÖdemeTarihi"].Value.ToString();
            textBox4.Text = satir.Cells["ÖdemeGecikmeDurumu"].Value.ToString();
            textBox5.Text = satir.Cells["ÖdemeGecikmeFaizi"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Öno = Convert.ToInt32(textBox1.Text);
            int Musterino = Convert.ToInt32(comboBox1.Text);
            string tip = textBox2.Text;
            string tarih = dateTimePicker1.Text;
            decimal tutar = Convert.ToDecimal(textBox3.Text);
            int gecikme = Convert.ToInt32(textBox4.Text);
            int faiz = Convert.ToInt32(textBox5.Text);

            var ekle = baglanti.ÖdemeGüncelle(Öno,Musterino, tip, tarih, tutar, gecikme, faiz);
            baglanti.SubmitChanges();
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox6.Text);
            baglanti.ÖdemeArama(id);
            listele();
        }
    }
}
