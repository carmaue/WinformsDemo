using System;
using System.Windows.Forms;

namespace WinformsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test hola");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test hola 1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test hola 2");
        }
    }
}
