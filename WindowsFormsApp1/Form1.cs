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
        private double saldoGP2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoGP2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadGP2223) 
        {
            if (cantidadGP2223 > 0 && saldoGP2223 >= cantidadGP2223) {
              
                saldoGP2223 -= cantidadGP2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidad) {
            if (cantidad > 0 && radioButton1.Checked) //! Añado comprobación del Check
                saldoGP2223 += cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidadGP2223 del TextBox y la pasamos a número
            if (cantidad < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked && cantidad > 0)
            {
                if (realizarReintegro(cantidad) == false)  // No se ha podido completar la operación, saldoGP2223 insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(cantidad);
            txtSaldo.Text = saldoGP2223.ToString();
        }
    }
}
