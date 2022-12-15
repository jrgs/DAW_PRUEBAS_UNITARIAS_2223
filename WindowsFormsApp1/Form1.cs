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
       

        private double saldoREF1DAWY = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoREF1DAWY.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double CantidadREF1DAWY) 
        {
            if (CantidadREF1DAWY > 0 && saldoREF1DAWY > CantidadREF1DAWY) {
                saldoREF1DAWY = saldoREF1DAWY - CantidadREF1DAWY;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double CantidadREF1DAWY) {
            if (CantidadREF1DAWY > 0)
                saldoREF1DAWY += CantidadREF1DAWY;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double CantidadREF1DAWY = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (CantidadREF1DAWY < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(CantidadREF1DAWY) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(CantidadREF1DAWY);
            txtSaldo.Text = saldoREF1DAWY.ToString();
        }
    }
}
