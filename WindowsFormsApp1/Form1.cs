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
        private double saldoRIA2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoRIA2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadRIA2223) 
        {
            if (cantidadRIA2223 > 0 && saldoRIA2223 >= cantidadRIA2223) {
                saldoRIA2223 -= cantidadRIA2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadRIA2223) {
            if (cantidadRIA2223 > 0)
                saldoRIA2223 += cantidadRIA2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadRIA2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadRIA2223 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            else
            {
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(cantidadRIA2223) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                    else
                        txtSaldo.Text = saldoRIA2223.ToString();
                }
                else if (rbIngreso.Checked)
                {
                    realizarIngreso(cantidadRIA2223);
                    txtSaldo.Text = saldoRIA2223.ToString();
                }
                else
                {
                    MessageBox.Show("No se ha podido realizar la operación, seleccione reintegro o ingreso.");
                }
            }      
        }
    }
}
