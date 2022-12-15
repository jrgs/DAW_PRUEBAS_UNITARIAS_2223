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
        private double saldoOFCB22_23 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoOFCB22_23.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadOFCB22_23) 
        {
            if (cantidadOFCB22_23 > 0 && saldoOFCB22_23 >= cantidadOFCB22_23) {
                saldoOFCB22_23 -= cantidadOFCB22_23;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadOFCB22_23) {
            if (cantidadOFCB22_23 > 0)
                saldoOFCB22_23 += cantidadOFCB22_23;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadOFCB22_23 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadOFCB22_23 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            else
            {
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(cantidadOFCB22_23) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        realizarIngreso(cantidadOFCB22_23);
                        txtSaldo.Text = saldoOFCB22_23.ToString();
                    }
                    else
                    {
                    MessageBox.Show("Se debe seleccionar una operación, ERROR");
                    }
                }
            }
        }
    }
}
