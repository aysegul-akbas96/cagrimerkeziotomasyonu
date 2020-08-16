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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        public void Listele()
        {
            var görüntüle = baglanti.MusteriListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = görüntüle.ToList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string tür = comboBox2.Text;
            int telefon =Convert.ToInt32 (textBox4.Text);
            string adres = textBox2.Text;
            int puan = Convert.ToInt32(textBox3.Text);
            var ekle = baglanti.MusteriEkle(isim, tür, telefon, adres, puan);
            baglanti.SubmitChanges();
            Listele();
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["AdSoyad"].Value.ToString();
            textBox1.Tag = satir.Cells["MusteriNo"].Value;
            comboBox2.Text= satir.Cells["Türü"].Value.ToString();
            textBox4.Text=satir.Cells["Telefon"].Value.ToString();
            textBox2.Text = satir.Cells["Adres"].Value.ToString();
            textBox3.Text = satir.Cells["Puan"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            string isim = textBox1.Text;
            string tür = comboBox2.Text;
            int telefon = Convert.ToInt32(textBox4.Text);
            string adres = textBox2.Text;
            int puan = Convert.ToInt32(textBox3.Text);
            var yenile = baglanti.MusteriGüncelle(id,isim, tür, telefon, adres, puan);
            baglanti.SubmitChanges();
            Listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.MusteriSilme(id);
            Listele();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 git = new Form2();
            git.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox5.Text);
            baglanti.MüsteriArama(id);
            Listele();
        }
    }
}
