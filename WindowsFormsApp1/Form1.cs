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
        private double saldoEmm1DAW2022 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldoEmm1DAW2022.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadEmm1DAW2022) 
        {
            if (cantidadEmm1DAW2022 >= 0 && saldoEmm1DAW2022 > cantidadEmm1DAW2022) {
                saldoEmm1DAW2022 -= cantidadEmm1DAW2022;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadEmm1DAW2022) {


            if (cantidadEmm1DAW2022 >= 0)
                saldoEmm1DAW2022 += cantidadEmm1DAW2022;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            if (rbIngreso.Checked || rbReintegro.Checked)
            {

                double cantidadEmmdaw2022 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
                if (cantidadEmmdaw2022 < 0)
                {
                    MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
                }
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(cantidadEmmdaw2022) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                }
                else
                    realizarIngreso(cantidadEmmdaw2022);
                txtSaldo.Text = saldoEmm1DAW2022.ToString();

            }
            else
                MessageBox.Show("Error, tiene que marcar si quiere ingresar o reintrego");
            
        }
    }
}

