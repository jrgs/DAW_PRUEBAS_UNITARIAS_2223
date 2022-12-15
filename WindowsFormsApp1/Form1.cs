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
        private double angelTomas = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = angelTomas.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidad) 
        {
            if (cantidad >= 0 && angelTomas >= cantidad) {
                angelTomas -= cantidad;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidad) {
            if (cantidad > 0)
                angelTomas += cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double daw1z = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (daw1z < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            //En el evento click del botón Operar NO se comprueba qué operación si se ha elegido alguna operación
            if ((rbReintegro.Checked==false) && (radioButton1.Checked==false))
            {
                MessageBox.Show("Elija su operación");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(daw1z) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(daw1z);
            txtSaldo.Text = angelTomas.ToString();
        }
    }
}
