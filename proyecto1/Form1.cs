using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace proyecto1
{
    public partial class Form1 : Form
    {
        private List<Disco> listaDiscos;
        private List<Estilo> listaEstilos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cargar();

            //EstiloNegocio estilos = new EstiloNegocio();
            //List<string> strings= new List<string>();   

            //listaEstilos = estilos.listar();

            //foreach (Estilo item in listaEstilos)
            //{
            //    comboBox1.Items.Add(item.Descripcion);
            //}



        }

        private void cargar()
        {
            DiscoNegocio discos = new DiscoNegocio();

            try
            {

                listaDiscos = discos.listar();
                dataGridView1.DataSource = listaDiscos;
                dataGridView1.Columns["UrlImagen"].Visible = false; //que oculte la columna url
                cargarImagen(listaDiscos[0].UrlImagen); //cargue la imagen de la primera fila


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Disco discoSeleccionado = (Disco)dataGridView1.CurrentRow.DataBoundItem;
            cargarImagen(discoSeleccionado.UrlImagen);
        }

        private void cargarImagen(string direccion)
        {
            try
            {
                pictureBoxDiscos.Load(direccion);
            }
            catch (Exception)
            {
                //carga una imagen por defecto cuando el disco no tiene nignuna
                pictureBoxDiscos.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
                
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar pantallaAgregar = new frmAgregar();
            pantallaAgregar.ShowDialog();
            cargar();
        }
    }
}
