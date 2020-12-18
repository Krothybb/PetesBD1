using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetesBD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Favor de insertar Usuario y Contraseña");
                return;
            }
            else if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                MessageBox.Show("Login exitoso");
                ReporteAnual f1 = new ReporteAnual();
                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ingrese usuario y contraseña correcto");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
