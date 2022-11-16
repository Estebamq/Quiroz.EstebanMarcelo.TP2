using System;
using System.Data.SqlClient;

namespace EntidadesDAO
{
    public static class UsuarioAccesoDatos
    {
        private static string connetionString;
        private static SqlCommand command;

        static UsuarioAccesoDatos() 
        {
            connetionString = @"Data Source=.;Initial Catalog=truco_db;Integrated Security=True;";
        }

    }
}
