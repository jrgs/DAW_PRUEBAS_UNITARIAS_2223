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
        private double saldo_OskBorr = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldo_OskBorr.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidad_OskBorr) 
        {
            if (cantidad_OskBorr > 0 && saldo_OskBorr >= cantidad_OskBorr) {
                saldo_OskBorr -= cantidad_OskBorr;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidad_OskBorr) {
            if (cantidad_OskBorr > 0)
                saldo_OskBorr += cantidad_OskBorr;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad_OskBorr = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidad_OskBorr < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            else
            {   if (rbReintegro.Checked)
                {
                    if (realizarReintegro(cantidad_OskBorr) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
               
                    else
                        realizarIngreso(cantidad_OskBorr);
                    txtSaldo.Text = saldo_OskBorr.ToString();
            }
            MessageBox.Show("No se ha podido realizar la operación (¿ingreso o reintegro?)");
        }
    }
}
