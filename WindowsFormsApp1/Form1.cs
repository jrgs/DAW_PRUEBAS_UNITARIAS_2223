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
        private double saldoAZH2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoAZH2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadAZH2223) 
        {
            if (cantidadAZH2223 > 0 && saldoAZH2223 >= cantidadAZH2223) {
                saldoAZH2223 -= cantidadAZH2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadAZH2223) {
            if (cantidadAZH2223 > 0)
                saldoAZH2223 += cantidadAZH2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadAZH2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadAZH2223 < 0) 
            {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidadAZH2223) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else            
                realizarIngreso(cantidadAZH2223);

                txtSaldo.Text = saldoAZH2223.ToString();  
        }
    }
}
