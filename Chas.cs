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
    public partial class Chas : Form
    {
        public Chas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string[] erso2 = new string[8];
            StreamReader emo = new StreamReader("rabota.txt");
            string a; int b = 0;
            while ((a = emo.ReadLine()) != null) erso2[b++] = a;
            FileStream erso = new FileStream("erso.dat", FileMode.Open, FileAccess.Read);
            BinaryReader erso1 = new BinaryReader(erso);
            int chas = -1; string name = "";
            while (erso.Position < erso.Length)
            {
                int dl = erso1.ReadInt32();
                string ime = erso1.ReadString();
                string egn = erso1.ReadString();
                double cc = erso1.ReadDouble();
                int ic = erso1.ReadInt32();
                int dni = erso1.ReadInt32();
                if (chas < ic)
                {
                    chas = ic; name = ime;
                }
                label4.Text = "Име: " + name;
                label2.Text = "Часове: " + chas+" часа";
                label3.Text = "Длъжност: " + erso2[dl];

        }   }

        private void Chas_Load(object sender, EventArgs e)
        {

        }
    }
}
