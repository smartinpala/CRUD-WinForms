using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Collections;

namespace negocio
{
    public class DiscoNegocio
    {


        public List<Disco> listar()
        {
            List<Disco> discos= new List<Disco>();
            AccesoDatos datos = new AccesoDatos();  

            try
            {
                //datos.setearConsulta("select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, Descripcion Genero from DISCOS, ESTILOS E where E.Id = IdEstilo");
                datos.setearConsulta("select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Edicion from DISCOS, ESTILOS E, TIPOSEDICION T where E.Id = IdEstilo and IdTipoEdicion=T.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    
                    if(!(datos.Lector["UrlImagenTapa"] is DBNull))
                    aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];

                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)datos.Lector["Genero"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Descripcion = (string)datos.Lector["Edicion"];

                    discos.Add(aux);
                }


                return discos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }
        

        public List<Disco> listarEnfierrao()
        {
            List<Disco> lista = new List<Disco>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, Descripcion Genero from DISCOS, ESTILOS E where E.Id=IdEstilo";
                //comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa from DISCOS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagen = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)lector["Genero"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            //aqui creo un string con un formato de fecha conveniente
            //string fechaposta = nuevo.FechaLanzamiento.Year.ToString() + "-" + nuevo.FechaLanzamiento.Month.ToString() + "-" + nuevo.FechaLanzamiento.Day.ToString() + " " + nuevo.FechaLanzamiento.Hour.ToString() + ":" + nuevo.FechaLanzamiento.Minute.ToString();
            //modifique para que solo inserte el año/mes/dia y no los minutos y hora
            string fechaposta = nuevo.FechaLanzamiento.Year.ToString() + "-" + nuevo.FechaLanzamiento.Month.ToString() + "-" + nuevo.FechaLanzamiento.Day.ToString();
            try
            {
                //datos.setearConsulta("insert into DISCOS (Titulo,FechaLanzamiento,CantidadCanciones) values ('"+nuevo.Titulo+"',"+nuevo.FechaLanzamiento+","+nuevo.CantidadCanciones+")");
                //datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion) values ('" + nuevo.Titulo + "','"+ fechaposta +"',");
                //datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion) values ('" + nuevo.Titulo + "','" + fechaposta + "',"+nuevo.CantidadCanciones+",@idEstilo,@idTipoEdicion)");
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa ,IdEstilo, IdTipoEdicion) values (@Titulo,@fechaPosta,@cantidadCanciones, @UrlImagenTapa, @idEstilo,@idTipoEdicion)");
                
                datos.setearParametros("@Titulo", nuevo.Titulo);
                datos.setearParametros("@fechaPosta", fechaposta);
                datos.setearParametros("@cantidadCanciones", nuevo.CantidadCanciones);
                datos.setearParametros("@UrlImagenTapa", nuevo.UrlImagen);
                datos.setearParametros("@idEstilo", nuevo.Estilo.Id);
                datos.setearParametros("@idTipoEdicion", nuevo.Edicion.Id);
                
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void modificar(Disco modificar)
        {

        }


    }

}
