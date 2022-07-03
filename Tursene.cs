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
    public partial class Tursene : Form
    {
        public Tursene()
        {
            InitializeComponent();
        }

        private void Tursene_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            StreamReader txt = new StreamReader("tursene.txt");
            string erso;
            while ((erso = txt.ReadLine()) != null) comboBox1.Items.Add(erso);
            txt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)

        {
              if (comboBox1.SelectedIndex == -1)
              {
                dataGridView1.Rows.Clear();
                MessageBox.Show("Не сте избрали критерий за търсене !");
                errorProvider1.SetError(comboBox1, "Изберете критерий");
                comboBox1.Focus();
                return;
              }
              errorProvider1.Clear();
              if (textBox1.Text == "")
              {
                dataGridView1.Rows.Clear();
                errorProvider1.SetError(textBox1, "Въведете данни");
                MessageBox.Show("Въведете данни !");
                textBox1.Focus();
                return;
              }
              errorProvider1.Clear();

                dataGridView1.Rows.Clear();
                FileStream emo = new FileStream("erso.dat", FileMode.Open);
                BinaryReader erso = new BinaryReader(emo);
                string erso1 = textBox1.Text.ToUpper();
                while (emo.Position < emo.Length)
                {
                    int dlujnosti; string ime; string egn; double cena_chas; int izraboteni_chasa; int dni;
                    dlujnosti = erso.ReadInt32();
                    ime = erso.ReadString();
                    egn = erso.ReadString();
                    cena_chas = erso.ReadDouble();
                    izraboteni_chasa = erso.ReadInt32();
                    dni = erso.ReadInt32();
                    string zap = String.Format("{0:C2}", cena_chas * izraboteni_chasa);
                    if (ime.ToUpper().StartsWith(erso1) || egn.ToString().StartsWith(erso1))
                        //if (comboBox1.SelectedIndex == 0 && textBox1.Text == ime || comboBox1.SelectedIndex==1 && textBox1.Text==egn.ToString())
                        dataGridView1.Rows.Add(ime, egn, zap);
                }
                emo.Close();
            
            if (dataGridView1.RowCount==0)
            {
                MessageBox.Show("Няма намерени данни !");
            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32) e.KeyChar = '\0';
            if (comboBox1.SelectedIndex==1 && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8) e.KeyChar = '\0';
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
