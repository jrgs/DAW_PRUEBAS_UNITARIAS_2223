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
        private double dvsSaldo2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = dvsSaldo2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double dvsCantidad2223) 
        {
            if (dvsCantidad2223 > 0 && dvsSaldo2223 >= dvsCantidad2223) {
                dvsSaldo2223 -= dvsCantidad2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double dvsCantidad2223) {
            if (dvsCantidad2223 > 0)
                dvsSaldo2223 += dvsCantidad2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double dvsCantidad2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if ((rbReintegro.Checked || rbIngresoDVS2223.Checked) && dvsCantidad2223 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            else
            {
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(dvsCantidad2223) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                }
                else if (rbIngresoDVS2223.Checked)
                    realizarIngreso(dvsCantidad2223);
                txtSaldo.Text = dvsSaldo2223.ToString();
            }   
        }
    }
}
