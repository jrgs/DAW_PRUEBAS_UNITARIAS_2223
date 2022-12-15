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
        private double saldo_gag2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldo_gag2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidad_gag2223)
        {
            if (cantidad_gag2223 > 0 && saldo_gag2223 >= cantidad_gag2223) {
                saldo_gag2223 -= cantidad_gag2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidad_gag2223) {
            if (cantidad_gag2223 > 0)
                saldo_gag2223 += cantidad_gag2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad_gag2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidad_gag2223 < 0) {
                MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidad_gag2223) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                else
                {
                    txtSaldo.Text = saldo_gag2223.ToString();
                }
            }
            else if (radioButton1.Checked)
            {
                realizarIngreso(cantidad_gag2223);
                txtSaldo.Text = saldo_gag2223.ToString();
            }
            else
            {
                MessageBox.Show("Debes seleccionar 'Ingreso' o 'Reintegro' para continuar.");
            }
        }
    }
}