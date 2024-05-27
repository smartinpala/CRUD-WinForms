using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EdicionNegocio
    {

        public List<Edicion> listar()
        {

            List<Edicion> lista = new List<Edicion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Edicion e = new Edicion();
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

    }
}
