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
    public partial class Vuvedi : Form
    {
        public Vuvedi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show ("Сигурни ли сте ?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes) Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я')&& e.KeyChar!=8 && e.KeyChar!=32 ) e.KeyChar = '\0'; //Keys enum
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 ) e.KeyChar = '\0';
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar!=',' && e.KeyChar!='.') e.KeyChar = '\0';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            double chasasum = double.Parse(textBox3.Text);
            int izraboteni_chasove = int.Parse(textBox4.Text);
            int rab_dni = (int)(numericUpDown1.Value);
            double zaplata = chasasum * izraboteni_chasove;
            label8.Text = String.Format("Заплата: {0:C2}", zaplata);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) 
            {
                MessageBox.Show("Изберете длъжност !");
                errorProvider1.SetError(comboBox1, "Изберете длъжност");
                comboBox1.Focus();
                return;
            }
            errorProvider1.Clear();
            if (textBox1.Text=="" )
            {
                MessageBox.Show("Въведете име !");
                errorProvider1.SetError(textBox1, "Въведете име");
                textBox1.Focus();
                return;
            }
            errorProvider1.Clear();
            if (textBox2.Text=="" )
            {
                MessageBox.Show("Въведете ЕГН !");
                errorProvider1.SetError(textBox2, "Въведете ЕГН");
                textBox2.Focus();
                return;
            }
            errorProvider1.Clear();
            if (textBox3.Text=="")
            {
                MessageBox.Show("Не сте въвели цена за час !");
                errorProvider1.SetError(textBox3, "Въведете цена");
                textBox3.Focus();
                return;
            }
            errorProvider1.Clear();
            if (textBox4.Text=="")
            {
                MessageBox.Show("Не сте въвели изработени часове !");
                errorProvider1.SetError(textBox4, "Въведете часове");
                textBox4.Focus();
                return;
            }
            errorProvider1.Clear();
            int dlujnost = comboBox1.SelectedIndex;
            string ime = textBox1.Text;
            string egn = textBox2.Text;
            double cena_chas = double.Parse(textBox3.Text);
            int izraboteni_chasa = int.Parse(textBox4.Text);
            int dni = (int)(numericUpDown1.Value);
            FileStream w=new FileStream("erso.dat", FileMode.OpenOrCreate, FileAccess.Write);
            w.Seek(0, SeekOrigin.End);
            BinaryWriter q = new BinaryWriter(w);
            q.Write(dlujnost); q.Write(ime); q.Write(egn);q.Write(cena_chas);q.Write(izraboteni_chasa);q.Write(dni);
            w.Close();
                MessageBox.Show("Данните са записани !");
            Close();
            
        }

        private void Vuvedi_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            StreamReader txt = new StreamReader("rabota.txt");
            string erso;
            while ((erso = txt.ReadLine()) != null) comboBox1.Items.Add(erso);
            txt.Close(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 ) e.KeyChar = '\0';
        }
    }
}
        
    

