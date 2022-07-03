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
    public partial class Spisak : Form
    {
        public Spisak()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] erso = new string[8];
            StreamReader emo= new StreamReader("rabota.txt");
            string a; int b = 0;
            while ((a= emo.ReadLine()) != null) erso[b++] = a;
            emo.Close();
            FileStream erso1 = new FileStream("erso.dat", FileMode.Open, FileAccess.Read);
            BinaryReader erso12 = new BinaryReader(erso1);
            int n = 1;
            while (erso1.Position < erso1.Length)
            {
                int dl = erso12.ReadInt32();
                string ime = erso12.ReadString();
                string egn = erso12.ReadString();
                double cc = erso12.ReadDouble();
                int ic = erso12.ReadInt32();
                int dni = erso12.ReadInt32();
                string chas_lv = String.Format("{0:C2}", cc);
                dataGridView1.Rows.Add(n++ +".", erso[dl], ime, egn, chas_lv, ic + " часа", dni + " дни");
            }
            erso1.Close();
            
        }

        private void Spisak_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
            
        }
    }
}
