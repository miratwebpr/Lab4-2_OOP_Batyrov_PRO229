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

namespace Lab4_2_OOP_Batyrov_PRO229
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observers += new System.EventHandler(this.UpdateFromModel);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.AsetValue(Decimal.ToInt32(numericUpDown1.Value));
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            model.AsetValue(trackBar1.Value);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
                model.AsetValue(Int32.Parse(textBox1.Text));

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.AgetValue().ToString();
            numericUpDown1.Value = model.AgetValue();
            trackBar1.Value = model.AgetValue();

            textBox2.Text = model.BgetValue().ToString();
            numericUpDown2.Value = model.BgetValue();
            trackBar2.Value = model.BgetValue();

            textBox3.Text = model.CgetValue().ToString();
            numericUpDown3.Value = model.CgetValue();
            trackBar3.Value = model.CgetValue();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.BsetValue(Decimal.ToInt32(numericUpDown2.Value));
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            model.BsetValue(trackBar2.Value);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox2.Text != "")
                model.BsetValue(Int32.Parse(textBox2.Text));
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.CsetValue(Decimal.ToInt32(numericUpDown3.Value));
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            model.CsetValue(trackBar3.Value);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox3.Text != "")
                model.CsetValue(Int32.Parse(textBox3.Text));
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists("text.txt"))
                File.Delete("Text.txt");
            StreamWriter sw = new StreamWriter("text.txt");
            sw.WriteLine(model.AgetValue().ToString());
            sw.WriteLine(model.BgetValue().ToString());
            sw.WriteLine(model.CgetValue().ToString());
            sw.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("text.txt"))
            {
                StreamReader sr = new StreamReader("text.txt");
                model.AsetValue(Convert.ToInt32(sr.ReadLine()));
                model.BsetValue(Convert.ToInt32(sr.ReadLine()));
                model.CsetValue(Convert.ToInt32(sr.ReadLine()));
                sr.Close();
            }
        }


    }
    public class Model
    {
        private int Avalue = 10;
        private int Bvalue = 50;
        private int Cvalue = 90;
        public System.EventHandler observers;
        public void AsetValue(int a)
        {
            if (a > 100)
                a = 100;
            if (a < 0)
                a = 0;
            if(a <= Bvalue && a <= Cvalue)
            {
                Avalue = a;
                observers.Invoke(this, null);
                return;
            }
            else if(a > Bvalue)
            {
                Avalue = a;
                BsetValue(a);
            }
            if(a > Cvalue)
            {
                Avalue = a;
                CsetValue(a);
            }
            observers.Invoke(this, null);
        }
        public void BsetValue(int b)
        {
            if (b > 100)
                b = 100;
            if (b < 0)
                b = 0;
            if (b >= Avalue && b <= Cvalue)
            {
                Bvalue = b;
                observers.Invoke(this, null);
                return;
            }
            else if(b < Avalue && b > Cvalue)
            {
                observers.Invoke(this, null);
            }
            observers.Invoke(this, null);
        }
        public void CsetValue(int c)
        {
            if (c > 100)
                c = 100;
            if (c < 0)
                c = 0;
            if (c >= Avalue && c >= Bvalue)
            {
                Cvalue = c;
                observers.Invoke(this, null);
                return;
            }
            else if(c < Bvalue)
            {
                Cvalue = c;
                BsetValue(c);
            }
            if(c < Avalue)
            {
                Cvalue = c;
                AsetValue(c);
            }
            observers.Invoke(this, null);
        }
        public int AgetValue()
        {
            return Avalue;
        }
        public int BgetValue()
        {
            return Bvalue;
        }
        public int CgetValue()
        {
            return Cvalue;
        }
    }
}
