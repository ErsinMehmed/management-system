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
    public partial class Otchet : Form
    {
        public Otchet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            StreamReader tekst = new StreamReader("otchet.txt");
            while (!tekst.EndOfStream)
            {
                string emo = tekst.ReadLine();
                listBox1.Items.Add(emo);
            }
            tekst.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Otchet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamWriter erso = new StreamWriter("otchet.txt");
            string up = textBox1.Text;
            erso.WriteLine(" МЕТАЛ АД" + "\tУПРАВИТЕЛ:" + up+"\n");
            erso.WriteLine(" МЕСЕЧЕН ОТЧЕТ ЗА ВСИЧКИ РАБОТНИЦИ (ЗА ИЗМИНАЛИЯ МЕСЕЦ)");
            erso.WriteLine("|-----------------------------------------------------------------------------------------------------------|");
            erso.WriteLine("| Име            | ЕГН      | Длъжност | Изработени часа | Изработени дни | Заплата    | Средно израб. часa |");
            string[] q = new string[8];
            StreamReader r = new StreamReader("rabota.txt");
            string a; int b = 0;
            while ((a = r.ReadLine()) != null) q[b++] = a;
            r.Close();
            FileStream er = new FileStream("erso.dat", FileMode.Open, FileAccess.Read);
            BinaryReader em = new BinaryReader(er);
            double pari = 0;
            while (er.Position < er.Length)
            {
                int dlujnosti; string ime; string egn; double cena_chas; int izraboteni_chasa; int dni;
                dlujnosti = em.ReadInt32();
                ime = em.ReadString();
                egn = em.ReadString();
                cena_chas = em.ReadDouble();
                izraboteni_chasa = em.ReadInt32();
                dni = em.ReadInt32();
                double zaplata = cena_chas * izraboteni_chasa;
                string zap = String.Format("{0:C2}", cena_chas * izraboteni_chasa);
                double average = izraboteni_chasa / dni;
                string otchet = String.Format("|{0,-16}|{1,-10}|{2,-10}|{3,-17}|{4,-16}|{5,12:C2}|{6,-20}|", ime, egn, q[dlujnosti],
                    izraboteni_chasa + " часа", dni + " дни", zap, average + " часа");
                erso.WriteLine(otchet);
                pari += zaplata;
            }
            double osigurovki = pari * 0.1378;
            double ddfl = (pari - osigurovki) * 0.1;
            double DOO = pari * 0.1672; //Държавно обеществено осигуряване
            double DZPO = pari * 0.12; //Допълнително задължително пенсионно осигуряване 
            double TZPB = pari * 0.004; //Трудова злополука и професионална болест
            double ZO = pari * 0.048; //Здравено осигуряване
            double os = DOO + DZPO + TZPB + ZO;
            erso.WriteLine("|===========================================================================================================|");
            erso.WriteLine("|                                       ОБЩО НАЧИСЛЕНИ ЗАПЛАТИ ЗА МЕСЕЦА: |{0,12:C2}|", pari);
            erso.WriteLine("|===========================================================================================================|");
            erso.WriteLine("| ОБЩО НАЧИСЛЕНИ ОСИГУРОВКИ (РАБОТОДАТЕЛ): {0,0:C2}", os);
            erso.WriteLine("| ОБЩО НАЧИСЛЕНИ ОСИГУРОВКИ (РАБОТНИК): {0,0:C2}", osigurovki);
            erso.WriteLine("| OБЩО ДДФЛ: {0,0:C2}", ddfl);
            erso.WriteLine("| ОБЩО ДЪЛЖИМА СУМА С УДЪРЖАНИ ОСИГУРОВКИ: {0,0:C2}\n", pari - osigurovki - ddfl);
            erso.WriteLine("| Дата: " + DateTime.Now.ToString() + "\tПодпис: ..........");
            er.Close(); erso.Close();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не сте въвели управител !");
                textBox1.Focus();
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32) e.KeyChar = '\0';
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
