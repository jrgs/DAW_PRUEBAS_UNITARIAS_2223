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
    {//!? Cambio el nombre de la variable saldo
        private double AERG2223saldo = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = AERG2223saldo.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double AERG2223cantidad) 
        {
            if (AERG2223cantidad > 0 && AERG2223saldo > AERG2223cantidad) {
                AERG2223saldo -= AERG2223cantidad;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double AERG2223cantidad) {
            if (AERG2223cantidad > 0)
                AERG2223saldo += AERG2223cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
            //!?Cambio nombre a variable Cantidad
        {
            double AERG2223cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (AERG2223cantidad < 0)
            {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");

            }//Añado un if para la cantidad mayor a 0
            else if (AERG2223cantidad > 0)
            {
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(AERG2223cantidad) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                }
               /* else
                    if (rbIngreso.Checked)
                {
                    if(realizarIngreso(AERG2223cantidad) >=0)
                }*/

                txtSaldo.Text = AERG2223saldo.ToString();
                }
            }
        }
    }

