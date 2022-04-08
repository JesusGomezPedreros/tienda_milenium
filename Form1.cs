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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sku = txtSku.Text;
                string marca = txtMarca.Text;
                string tipoProducto = txtTipoProducto.Text;
                string categoria = txtCategoria.Text;
                string color = txtColor.Text;
                string envase = txtEnvase.Text;
                string tamano = txtTamaño.Text;
                double precio = double.Parse(txtPrecio.Text);
                int cantidad = int.Parse(txtCantidad.Text);

                if (sku != "" && marca != "" && tipoProducto != "" && categoria != "" && color != "" && envase != "" && tamano != "" && precio > 0 && cantidad >= 0)
                {



                    string sql = "INSERT INTO productos (sku, marca, tipoProducto, categoria, color, envase, tamano, precio, cantidad) VALUES ('" + sku + "','" + marca + "','" + tipoProducto + "','" + categoria + "','" + color + "','" + envase + "','" + tamano + "','" + precio + "','" + cantidad + "')";

                    MySqlConnection conexionBD = Conexion.conexion();

                    conexionBD.Open();
                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro guardado");
                        limpiar();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos (el valor debe ser mayor a 0)");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos Incorrectos: " + fex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sku = txtSku.Text;

            MySqlDataReader reader = null;

            string sql = "SELECT idproductos, sku, marca, tipoProducto, categoria, color, envase, tamano, precio, cantidad FROM productos WHERE sku LIKE '"+sku+"' LIMIT 1";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        txtCodigo.Text = reader.GetString(0);
                        txtMarca.Text = reader.GetString(2);
                        txtTipoProducto.Text = reader.GetString(3);
                        txtCategoria.Text = reader.GetString(4);
                        txtColor.Text = reader.GetString(5);
                        txtEnvase.Text = reader.GetString(6);
                        txtTamaño.Text = reader.GetString(7);
                        txtPrecio.Text = reader.GetString(8);
                        txtCantidad.Text = reader.GetString(9);
                    }
                }else
                {
                    MessageBox.Show("no se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("error al buscar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }


        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtCodigo.Text;
                string sku = txtSku.Text;
                string marca = txtMarca.Text;
                string tipoProducto = txtTipoProducto.Text;
                string categoria = txtCategoria.Text;
                string color = txtColor.Text;
                string envase = txtEnvase.Text;
                string tamano = txtTamaño.Text;
                double precio = double.Parse(txtPrecio.Text);
                int cantidad = int.Parse(txtCantidad.Text);
            


                string sql = "UPDATE productos SET sku='"+sku+"', marca='"+marca+ "',tipoProducto='"+tipoProducto+"',categoria='"+categoria+"',color='"+color+"',envase='"+envase+"',tamano='"+tamano+"',precio='"+precio+"',cantidad='"+cantidad+"' WHERE idproductos='"+id+"'";
                MySqlConnection conexionBD = Conexion.conexion();

                conexionBD.Open();
                try
                {
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro Modificado");
                    limpiar();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("error al modificar: " + ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }

            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos" + fex.Message);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtCodigo.Text;
            

            string sql = "DELETE FROM productos WHERE idproductos='"+ id +"'";
            MySqlConnection conexionBD = Conexion.conexion();

            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Eliminado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtSku.Text = "";
            txtMarca.Text = "";
            txtTipoProducto.Text = "";
            txtCategoria.Text = "";
            txtColor.Text = "";
            txtEnvase.Text = "";
            txtTamaño.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }
    }
}
