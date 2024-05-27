using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto1
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco nuevoDisco = new Disco();

            try
            {

                nuevoDisco.Titulo = txtTitulo.Text;
                nuevoDisco.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                nuevoDisco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                nuevoDisco.UrlImagen= txtUrlImagen.Text;
                //capturar los combobox

                nuevoDisco.Edicion = (Edicion)cboTipoEdicion.SelectedItem;
                nuevoDisco.Estilo = (Estilo)cboEstilo.SelectedItem;

                DiscoNegocio negocio = new DiscoNegocio();
                negocio.agregar(nuevoDisco); //llamo al metodo que inserta el elemento
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()+"puto");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            cargarImagen(" ");
            EstiloNegocio estilonegocio = new EstiloNegocio();
            EdicionNegocio edicionnegocio = new EdicionNegocio();
            
            try
            {
                cboEstilo.DataSource = estilonegocio.listar();
                cboTipoEdicion.DataSource = edicionnegocio.listar();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void cargarImagen(string direccion)
        {
            try
            {
                pictureBoxDiscoNuevo.Load(direccion);
            }
            catch (Exception)
            {
                //carga una imagen por defecto cuando el disco no tiene nignuna
                pictureBoxDiscoNuevo.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");

            }
        }
    }
}
