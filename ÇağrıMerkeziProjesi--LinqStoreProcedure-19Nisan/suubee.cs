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
    public partial class suubee : Form
    {
        public suubee()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        public void listele()
        {
            var görüntüle = baglanti.ŞubeListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = görüntüle.ToList();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MusteriTemsilciBilgileri git = new MusteriTemsilciBilgileri();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var id =(int) textBox1.Tag;
            baglanti.ŞubeSil(id);
            listele();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["ŞubeAdı"].Value.ToString();
            textBox1.Tag = satir.Cells["ŞubeNo"].Value;
            textBox2.Text = satir.Cells["Şubeİlçe"].Value.ToString();
            textBox3.Text = satir.Cells["ŞubeYetkilisi"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string ilçe =textBox2.Text;
            string yetkili = textBox3.Text;
           
            var ekle = baglanti.ŞubeEkle(ad, ilçe, yetkili);
            baglanti.SubmitChanges();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            string ad = textBox1.Text;
            string ilçe = textBox2.Text;
            string yetkili = textBox3.Text;

            var ekle = baglanti.ŞubeGüncelle(id,ad, ilçe, yetkili);
            baglanti.SubmitChanges();
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(textBox5.Text);

            var listele = baglanti.ŞubeArama(id);
            dataGridView1.DataSource = listele.ToList();
        }

        private void suubee_Load(object sender, EventArgs e)
        {

        }
    }
}
