using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        private double saldo;  
        public const String ERR_CANTIDAD_NO_VALIDA = "Cantidad no valida CDJ2324";
        public const String ERR_SALDO_INSUFICIENTE = "Saldo insuficiente";

        public GestionBancariaApp(double saldo = 0)
        {
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = ObtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }

        public double ObtenerSaldo() { return saldo; }

        public int RealizarReintegro(double cantidad) 
        {
            if (cantidad <= 0)

                //return ERR_CANTIDAD_NO_VALIDA;
                //throw new ArgumentOutOfRangeException("la cantidad indicada no es válida");

                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);

            if (saldo < cantidad)

                //return ERR_SALDO_INSUFICIENTE;
                //throw new ArgumentOutOfRangeException("saldo insuficiente");

                throw new ArgumentOutOfRangeException(ERR_SALDO_INSUFICIENTE);

            saldo -= cantidad; //corrijo el error CDJ_2324
            return 0;
        }

        public int RealizarIngreso(double cantidad) {

            // if (cantidad > 0) return ERR_CANTIDAD_NO_VALIDA,
            // el error se debe ejecutar si la cantidad <= 0 CDJ2324

            if (cantidad <= 0)

                //return ERR_CANTIDAD_NO_VALIDA;
                //throw new ArgumentOutOfRangeException("la cantidad indicada no es válida");

                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);

            //saldo-=cantidad -> ERROR, la cantidad debe sumarse al saldo
            saldo += cantidad;
            return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (rbReintegro.Checked)
            {//CDJ2324
                try {
                    RealizarReintegro(cantidad);
                    MessageBox.Show("Transacción realizada.");
                } catch (Exception error){
                    if (error.Message.Contains(ERR_SALDO_INSUFICIENTE))
                        MessageBox.Show("No se ha podido realizar la operacion (¿Saldo insuficiente?)");
                    else
                        if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no valida, solo se admiten cantidades positivas");
                }
                    

            }
            else {
                try {
                    RealizarIngreso(cantidad);
                    MessageBox.Show("Transaccion realizada");
                }catch (Exception error)
                {
                    if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no valida, solo se admiten cantidades positivas.");
                }
            }
           txtSaldo.Text = ObtenerSaldo().ToString();
        }
    }
}
