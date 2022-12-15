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
        private double saldoFJRM1DAW = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoFJRM1DAW.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadFJRM1DAW) 
        {
            if (cantidadFJRM1DAW > 0 && saldoFJRM1DAW >= cantidadFJRM1DAW) {
                saldoFJRM1DAW -= cantidadFJRM1DAW;
                return true;
                
            }
            return false;
        }

        private void realizarIngreso(double cantidadFJRM1DAW) {
            if (cantidadFJRM1DAW > 0)
                saldoFJRM1DAW += cantidadFJRM1DAW;
            else
                saldoFJRM1DAW -= cantidadFJRM1DAW;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadFJRM1DAW = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadFJRM1DAW < 0) || (cantidadFJRM1DAW > 0) && (realizarReintegro == false) {
                MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidadFJRM1DAW) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                else 
                    txtSaldo.Text = saldoFJRM1DAW.ToString();
            }
            else
                if (rbIngreso.Checked)
            {
                realizarIngreso(cantidadFJRM1DAW);
                txtSaldo.Text = saldoFJRM1DAW.ToString();
            }
            else
                MessageBox.Show("Seleccione Ingreso o Reintegro");

    }
    }
}
