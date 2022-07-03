using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Курсува_работа__АП__Ерсин_и_Емил_
{
    public partial class Po_dlujnost : Form
    {
        public Po_dlujnost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FileStream er = new FileStream("erso.dat",FileMode.Open);
            BinaryReader em = new BinaryReader(er);
            int num = 0;
            while (er.Position<er.Length)
            {
                int dlujnosti; string ime; string egn; double cena_chas; int izraboteni_chasa; int dni;
                dlujnosti = em.ReadInt32();
                ime = em.ReadString();
                egn = em.ReadString();
                cena_chas = em.ReadDouble();
                izraboteni_chasa = em.ReadInt32();
                dni = em.ReadInt32();
                string zap = String.Format("{0:C2}", cena_chas * izraboteni_chasa);
                string price = String.Format("{0:C2}", cena_chas);
                if (comboBox1.SelectedIndex==dlujnosti)
                dataGridView1.Rows.Add(++num+".",ime, egn,izraboteni_chasa + " часа",price, zap);
            }
            er.Close();
            if (num == 0) MessageBox.Show("Няма намерени данни !");


        }

        private void Po_dlujnost_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            StreamReader txt = new StreamReader("rabota.txt");
            string erso;
            while ((erso = txt.ReadLine()) != null) comboBox1.Items.Add(erso);
            txt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
