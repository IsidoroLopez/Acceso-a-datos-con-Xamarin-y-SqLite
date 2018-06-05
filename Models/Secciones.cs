using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    [Table("Secciones")]
    public class Secciones
    {
        [SQLite.PrimaryKey]
        public int Seccion { get; set; }
        public String Situacion { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        public int Telefono { get; set; }

    }
}
