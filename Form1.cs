using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string sku = txtSku.Text;
            string marca = txtMarca.Text;
            string tipoProducto = txtTipoProducto.Text;
            string categoria = txtCategoria.Text;
            string color = txtColor.Text;
            string envase = txtEnvase.Text;
            double tamaño = double.Parse(txtTamaño.Text);
            double precio = double.Parse(txtPrecio.Text);
            int cantidad = int.Parse(txtCantidad.Text);
            
            string sql = "INSER INTO productos (sku, marca, tipoProducto, categoria, color, envase, tamaño, precio, cantidad) VALUES ('"+sku+ "','" + marca +"','" + tipoProducto+ "','" + categoria+ "','" + color + "','"+envase+"','" + tamaño + "','" + precio + "','" + cantidad + "')";

            MySqlConnection conexionBD = Conexion.conexion();

            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("error al guardar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }
    }
}
