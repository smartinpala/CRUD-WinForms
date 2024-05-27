using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        [DisplayName ("Título")]
        public string Titulo { get; set; }
        [DisplayName("Cantidad de canciones")]
        public int CantidadCanciones { get; set; }
        [DisplayName("Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        public string UrlImagen { get; set; }
        [DisplayName("Genero")]
        public Estilo Estilo { get; set; }
        [DisplayName("Formato")]
        public Edicion Edicion { get; set; }

    }
}
