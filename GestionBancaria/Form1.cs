namespace GestionBancaria
{
    public partial class Form1 : Form
    {
        private double saldo = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldo.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidad)
        {
            if (cantidad > 0 && saldo > cantidad)
            {
                saldo -= cantidad;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidad)
        {
            if (cantidad > 0)
                saldo += cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidad < 0)
            {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }
            if (rbReintegro.Checked)
            {
                if (realizarReintegro(cantidad) == false)  // No se ha podido completar la operación, saldo insuficiente?
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
            }
            else
                realizarIngreso(cantidad);
            txtSaldo.Text = saldo.ToString();
        }
    }
}