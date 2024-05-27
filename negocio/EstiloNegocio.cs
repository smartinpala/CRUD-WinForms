using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class EstiloNegocio
    {

        public List<Estilo> listar() {

            List<Estilo> lista = new List<Estilo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, Descripcion from ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo e = new Estilo();
                    e.Id = (int)datos.Lector["Id"];
                    e.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    lista.Add(e);
                }

                return lista;
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

        public List<Estilo> ListarAloBruto()
        {
            List<Estilo> lista = new List<Estilo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security = true";
                comando.CommandType=System.Data.CommandType.Text;
                comando.CommandText = "select Id, Descripcion from ESTILOS";
                comando.Connection= conexion;
                conexion.Open();
                lector=comando.ExecuteReader();

                while(lector.Read())
                {
                    Estilo e = new Estilo();
                    e.Id = (int)lector["Id"];
                    e.Descripcion = (string)lector["Descripcion"];  
                    lista.Add(e);
                }
                conexion.Close();   
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
