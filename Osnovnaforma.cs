using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсува_работа__АП__Ерсин_и_Емил_
{
    public partial class ОсновнаФорма : Form
    {
        public ОсновнаФорма()
        {
            InitializeComponent();
        }

        private void списъкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Spisak().Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void наймногоИзработениЧасовеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void изходToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show(this, "Сигурни ли сте ?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes) Close();
        }

        private void въвежданеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Vuvedi().Show();
        }

        private void търсенеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tursene().Show();
        }

        private void работнициToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Po_dlujnost().Show();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Otchet().Show();
        }

        private void работникСНаймногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void рабСНаймногоЧасовеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Chas().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd MM y");
            label4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ОсновнаФорма_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
