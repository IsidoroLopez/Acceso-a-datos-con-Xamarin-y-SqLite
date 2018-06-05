using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Helpers
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConexion();
    }

}
