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
    public partial class CMerkez : Form
    {
        public CMerkez()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        public void listele()
        {
            var görüntüle = baglanti.CagrıListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = görüntüle.ToList();
        }
        private void CMerkez_Load(object sender, EventArgs e)
        {

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
            int id = (int)textBox1.Tag;
            baglanti.CagrıSil(id);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["AdıSoyadı"].Value.ToString();
            textBox1.Tag = satir.Cells["ÇNO"].Value;
            textBox2.Text = satir.Cells["Mezuniyet"].Value.ToString();
            textBox3.Text = satir.Cells["VardiyaDurumu"].Value.ToString();
            textBox4.Text = satir.Cells["HaftalıkÇalışmaPlanı"].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string adsoyad = textBox1.Text;
            string mezuniyet = textBox2.Text;
            string vardiyadurumu = textBox3.Text;
            string haftalıkplan = textBox4.Text;
            var ekle = baglanti.CagrıKaydet(adsoyad,mezuniyet,vardiyadurumu,haftalıkplan);
            baglanti.SubmitChanges();
            listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            string adsoyad = textBox1.Text;
            string mezuniyet = textBox2.Text;
            string vardiyadurumu = textBox3.Text;
            string haftalıkplan = textBox4.Text;
            var güncelle = baglanti.CagrıGüncelle(id,adsoyad, mezuniyet, vardiyadurumu, haftalıkplan);
            baglanti.SubmitChanges();
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox5.Text);
          
            var listele = baglanti.CagrıArama(id);
            dataGridView1.DataSource = listele.ToList();
           

        }
    }
}
