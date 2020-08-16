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
    public partial class Trf : Form
    {
        public Trf()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        public void Listele()
        {
            var görüntüle = baglanti.TarifeListeleme();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = görüntüle.ToList();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 git = new Form2();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            int MusteriNo = Convert.ToInt32(comboBox2.SelectedValue);
            string TarifeAdı = textBox1.Text;
            string TarifeDurum = comboBox2.Text;
            decimal Ucret = Convert.ToDecimal(textBox2.Text);
            string BaşlangıçTarihi = dateTimePicker1.Text;
            string BitişTarihi = dateTimePicker2.Text;
            var ekle = baglanti.TarifeEkle(MusteriNo,TarifeAdı, TarifeDurum, Ucret, BaşlangıçTarihi, BitişTarihi);
            baglanti.SubmitChanges();
            Listele();
        }

        private void Trf_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = baglanti.Musterilers.ToList();
            comboBox2.ValueMember = "MusteriNo";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Tarifeno =Convert.ToInt32(textBox1.Tag);
            int MusteriNo = Convert.ToInt32(comboBox2.SelectedValue);
            string TarifeAdı = textBox1.Text;
            string TarifeDurum = comboBox2.Text;
            decimal Ucret = Convert.ToDecimal(textBox2.Text);
            string BaşlangıçTarihi = dateTimePicker1.Text;
            string BitişTarihi = dateTimePicker2.Text;
            var ekle = baglanti.TarifeGüncelleme(Tarifeno,MusteriNo, TarifeAdı, TarifeDurum, Ucret, BaşlangıçTarihi, BitişTarihi);
            baglanti.SubmitChanges();
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["TarifeAdı"].Value.ToString();
            textBox1.Tag = satir.Cells["TarifeNo"].Value;
            comboBox2.Text = satir.Cells["MusteriNo"].Value.ToString();
            comboBox1.Text = satir.Cells["TarifeDurum"].Value.ToString();
            textBox2.Text = satir.Cells["Ucret"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["BaşlangıçTarihi"].Value.ToString();
            dateTimePicker2.Text = satir.Cells["BitişTarihi"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id = (int)textBox1.Tag;
            baglanti.TarifeSil(id);
            Listele();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox3.Text);
            baglanti.tarifeArama(id);
            Listele();
        }
    }
}
