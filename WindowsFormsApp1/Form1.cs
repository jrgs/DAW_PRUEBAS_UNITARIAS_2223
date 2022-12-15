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
    {   //Incluyo mis iniciales y el curso
        private double saldoDAM2223 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {

            InitializeComponent();
            
            txtSaldo.Text = saldoDAM2223.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidadDAM2223) 
        {
            if (cantidadDAM2223 > 0 && saldoDAM2223 >= cantidadDAM2223) {
                saldoDAM2223 -= cantidadDAM2223;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidadDAM2223) {
            if (cantidadDAM2223 > 0)
                saldoDAM2223 += cantidadDAM2223;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidadDAM2223 = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidadDAM2223 < 0) {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if ((realizarReintegro(cantidadDAM2223) == false) && cantidadDAM2223 < 0) 
                    // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else if (rbIngreso.Checked){
                realizarIngreso(cantidadDAM2223);
            }
            else{
                MessageBox.Show("Indique que operación desea realizar", "ATENCIÓN");
            }
      
            txtSaldo.Text = saldoDAM2223.ToString();
        }
    }
}
