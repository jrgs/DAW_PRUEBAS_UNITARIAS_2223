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
        private double S_CGG2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = S_CGG2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double C_CGG2223) 
        {
            if (C_CGG2223 > 0 && S_CGG2223 >= C_CGG2223) {
                S_CGG2223 -= C_CGG2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double C_CGG2223) {
            if (C_CGG2223 > 0)
                S_CGG2223 += C_CGG2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double C_CGG2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (C_CGG2223 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades negativas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(C_CGG2223) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            if (Ingreso.Checked)
                realizarIngreso(C_CGG2223);
            txtSaldo.Text = S_CGG2223.ToString();
           
       }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
