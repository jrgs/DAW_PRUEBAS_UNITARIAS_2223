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
        private double saldoJPS2223 = 1000;  // saldoJPS2223 inicial de la cuenta, 1000€

        public Form1()
        {
            
            InitializeComponent();
            double saldoJPS2223 = 1000;
            txtSaldo.Text = saldoJPS2223.ToString();
            txtCantidad.Text = "0";
            
        }

        private bool realizarReintegro(double cantidadJPS2223) 
        {

            if (cantidadJPS2223 > 0 && saldoJPS2223 >= cantidadJPS2223) {
                saldoJPS2223 -= cantidadJPS2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadJPS2223) {
            if (cantidadJPS2223 > 0)
                saldoJPS2223 += cantidadJPS2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadJPS2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadJPS2223 < 0) {
                MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
            }
            else if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidadJPS2223) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿saldo insuficiente?)");
            }
            else
                realizarIngreso(cantidadJPS2223);
            txtSaldo.Text = saldoJPS2223.ToString();
        }
    }
}
