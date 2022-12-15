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
        private double saldoYAG2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoYAG2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadYAG2223) 
        {
            if (cantidadYAG2223 > 0 && saldoYAG2223 >=  cantidadYAG2223) {
                saldoYAG2223 -= cantidadYAG2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadYAG2223) {
            if (cantidadYAG2223 > 0)
                saldoYAG2223 += cantidadYAG2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadYAG223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadYAG223 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidadYAG223) ==false || saldoYAG2223 < 0  )  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(cantidadYAG223);
            txtSaldo.Text = saldoYAG2223.ToString();
        }
    }
}
