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
        private double saldoAJPP22 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoAJPP22.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadAJPP22) 
        {
            if (cantidadAJPP22 > 0 && saldoAJPP22 >= cantidadAJPP22) {
                saldoAJPP22 -= cantidadAJPP22;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadAJPP22) {
            if (cantidadAJPP22 > 0)
                saldoAJPP22 += cantidadAJPP22;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadAJPP22 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadAJPP22 < 0) {
                MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
            } else
            {
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(cantidadAJPP22) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                }
                else if (rbIngreso.Checked)
                {
                    realizarIngreso(cantidadAJPP22);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una opción");
                }
                txtSaldo.Text = saldoAJPP22.ToString();
            }
        }
    }
}
