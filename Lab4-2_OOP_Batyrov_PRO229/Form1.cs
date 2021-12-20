using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_2_OOP_Batyrov_PRO229
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
    public class Model
    {
        private int Avalue;
        private int Bvalue;
        private int Cvalue;
        public System.EventHandler observers;
        public void setValue()
        {

            observers.Invoke(this, null);
        }
        public int getValue()
        {
            return Avalue;
        }
    }
}
