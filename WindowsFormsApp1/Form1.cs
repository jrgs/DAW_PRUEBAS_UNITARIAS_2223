using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private 
        double  Dcc=1000;  // Saldo inicial de la cuenta, 1000€
        double curso2223;


        public Form1()
        {
        InitializeComponent();
            txtDcc.Text = Dcc.ToString();
            txtCurso2223.Text = curso2223.ToString();
        }

        private bool realizarReintegro(double curso2223) 
        {
            if (curso2223 > 0 && Dcc > curso2223)
            {
                Dcc -= curso2223;
                return true;
            }

            else {
                return false;
            } 
        }

        private void realizarIngreso(double cantidad) {
            if (cantidad > 0)
                Dcc += cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCurso2223.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidad < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidad) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(cantidad);
            txtDcc.Text = Dcc.ToString();
        }
    }
}
