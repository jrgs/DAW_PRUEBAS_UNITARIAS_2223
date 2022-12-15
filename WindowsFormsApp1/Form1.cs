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
        private double saldosbp22 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldosbp22.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadsbp22) 
        {
            if (cantidadsbp22 > 0 && saldosbp22 >= cantidadsbp22) {
                saldosbp22 -= cantidadsbp22;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadsbp22) {
            if (cantidadsbp22 > 0)
                saldosbp22 += cantidadsbp22;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadsbp22 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadsbp22 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidadsbp22) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(cantidadsbp22);
            txtSaldo.Text = saldosbp22.ToString();
        }
    }
}
