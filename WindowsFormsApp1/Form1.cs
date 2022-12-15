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
        private double saldoMTB = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoMTB.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadMTB) 
        {
            if (cantidadMTB > 0 && saldoMTB > cantidadMTB) {
                saldoMTB -= cantidadMTB;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadMTB) {
            if (cantidadMTB > 0)
                saldoMTB += cantidadMTB;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadMTB = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadMTB < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            else if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidadMTB) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else if(rbIngreso.Checked)
                realizarIngreso(cantidadMTB);
            txtSaldo.Text = saldoMTB.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
