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
    public partial class Brm : Form
    {
        public Brm()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        private void button5_Click(object sender, EventArgs e)
        {
            MusteriTemsilciBilgileri git = new MusteriTemsilciBilgileri();
            git.Show();
            this.Hide();
        }
        public void listele()
        {
            var görüntüle = baglanti.BirimListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = görüntüle.ToList();
        }
        private void Brm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Şubelers.ToList();
            comboBox1.ValueMember = "ŞubeNo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string müdür = textBox2.Text;
            int no = Convert.ToInt32(comboBox1.Text);

            var ekle = baglanti.BirimEkle(ad, müdür, no); ;
            baglanti.SubmitChanges();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = (int)textBox1.Tag;
            baglanti.BirimSilme(id);
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            string ad = textBox1.Text;
            string müdür = textBox2.Text;
            int şubeno =Convert.ToInt32(comboBox1.Text);

            var güncelle= baglanti.BirimGüncelle(id, ad, müdür, şubeno);
            baglanti.SubmitChanges();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["BirimAdı"].Value.ToString();
            textBox1.Tag = satir.Cells["BirimNo"].Value;
            textBox2.Text = satir.Cells["BirimMüdürü"].Value.ToString();
            comboBox1.Text = satir.Cells["ŞubeNo"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox5.Text);

            var listele = baglanti.BRMArama(id);
            dataGridView1.DataSource = listele.ToList();
        }
    }
}
