using AccesoDatos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AccesoDatos.Helpers
{
    public class HelperAutoescuelaSQLite
    {
        SQLite.SQLiteConnection cn;
        public HelperAutoescuelaSQLite()
        {
            cn = DependencyService.Get<IDataBase>().GetConexion();
        }

        public void CrearBBDD()
        {
            cn.DropTable<Secciones>();
            cn.CreateTable<Secciones>();
        }

        public List<Secciones> GetSecciones()
        {
            TableQuery<Secciones> consulta = from datos in cn.Table<Secciones>()
                                                select datos;
            List<Secciones> lista = new List<Secciones>();
            foreach (var seccion in consulta)
            {
                lista.Add(seccion);
            }
            return lista;
        }

        public Secciones BuscarSeccion(int numero)
        {

            TableQuery<Secciones> consulta = from datos in cn.Table<Secciones>()
                                                where datos.Seccion == numero
                                                select datos;
            return consulta.FirstOrDefault();
        }

        public int InsertarSeccion(Secciones seccion)
        {
            return cn.Insert(seccion);
        }

        public void EliminarSeccion(Secciones seccion)
        {
            cn.Delete(seccion);
        }

        public int ModificarSeccion(Secciones seccion)
        {
            return cn.Update(seccion);
        }
    }

}
