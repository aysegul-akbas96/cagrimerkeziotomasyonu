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
    public partial class Kmpny : Form
    {
        public Kmpny()
        {
            InitializeComponent();
        }
        CagrıMerkeziUygulamasıDataContext baglanti = new CagrıMerkeziUygulamasıDataContext();
        public void Listele()
        {
            var görüntüle = baglanti.KampanyaListele();
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

        private void Kmpny_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Tarifes.ToList();
            comboBox1.ValueMember = "TarifeNo";
        }

        private void button2_Click(object sender, EventArgs e)
        {

           int TarifeNo = Convert.ToInt32(comboBox1.SelectedValue);

            string kadi = textBox1.Text;
            int kampanyasüresi = Convert.ToInt32(textBox2.Text);
            decimal Ucret = Convert.ToDecimal(textBox2.Text);
          
            var ekle = baglanti.KampanyaEkle(TarifeNo, kadi, kampanyasüresi, Ucret);
            baglanti.SubmitChanges();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["KAdı"].Value.ToString();
            textBox1.Tag = satir.Cells["KNo"].Value;
            comboBox1.Text= satir.Cells["TarifeNo"].Value.ToString();
            textBox2.Text= satir.Cells["KSüresi"].Value.ToString();
            textBox3.Text = satir.Cells["KUcreti"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.KampanyaSil(id);
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int KNo = Convert.ToInt32(textBox1.Tag);
            string kadi = textBox1.Text;
            int TarifeNo = Convert.ToInt32(comboBox1.SelectedValue);
            int Ksüresi = Convert.ToInt32(textBox2.Text);
            decimal Kücret = Convert.ToDecimal(textBox3.Text);


            var ekle = baglanti.KampanyaGüncelle(KNo, TarifeNo, kadi, Ksüresi, Kücret);
            baglanti.SubmitChanges();
            Listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(textBox4.Text);
            baglanti.KampanyaArama(id);
            Listele();
        }
    }
}
