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
    public partial class MusteriTemsilciBilgileri : Form
    {
        public MusteriTemsilciBilgileri()
        {
            InitializeComponent();
        }

        private void çağrıMerkeziGörevliBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMerkez git = new CMerkez();
            git.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 git = new Form2();
            git.Show();
            this.Hide();

        }

        private void şubelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            suubee git = new suubee();
            git.Show();
            this.Hide();
        }

        private void birimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brm git = new Brm();
            git.Show();
            this.Hide();
        }
    }
}
