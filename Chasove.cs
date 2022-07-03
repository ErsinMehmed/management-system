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
    public partial class Chasove : Form
    {
        public Chasove()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] er = new string[8];
            StreamReader emo = new StreamReader("rabota.txt");
            string a; int b = 0;
            while ((a = emo.ReadLine()) != null) er[b++] = a;
            emo.Close();
            FileStream erso = new FileStream("erso.dat", FileMode.Open, FileAccess.Read);
            BinaryReader erso1 = new BinaryReader(erso);
            int chas = -1; string name = "";
            while (erso.Position < erso.Length)
            {
                int dl = erso1.ReadInt32();
                string ime = erso1.ReadString();
                Int64 egn = erso1.ReadInt64();
                double cc = erso1.ReadDouble();
                int ic = erso1.ReadInt32();
                int dni = erso1.ReadInt32();
                if (chas < ic)
                {
                    chas = ic; name = ime;
                }
                label1.Text = "Име: " + name+" |" + " Длъжност: "+ er[dl]+" | "  + chas+ " часа";
            }
            erso.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
