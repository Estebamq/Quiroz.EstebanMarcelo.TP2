using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using Entidades.Enumerados;



namespace EntidadesDAO
{
    public static class UsuarioAccesoDatos
    {
        private static string connetionString;
        private static SqlConnection sqlConection;

        static UsuarioAccesoDatos() 
        {
            connetionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=truco_db;Integrated Security=True;";
            sqlConection = new SqlConnection(connetionString);
        }


        public static List<Jugador> TraerJugadoresADO() 
        {

            try
            {
                sqlConection.Open();
                string command = "SELECT * FROM Usuario";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Jugador> jugadores = new List<Jugador>();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    ETipoJugador tipo = (ETipoJugador)reader["tipo"];
                    string apodo = (string)reader["apodo"];
                    string apellido = (string)reader["apellido"];
                    string nombre = (string)reader["nombre"];
                    int edad = (int)reader["edad"];
                    int puntaje = (int)reader["puntaje"];

                    Jugador jugador = new Jugador(id, tipo, apodo, apellido, nombre, edad, puntaje);
                    jugadores.Add(jugador);
                }

                return jugadores;

            } 
            catch (Exception ex) 
            {
                throw new ExceptionADO("Error en la conexion con la base de datos");
            }
            finally
            {
                if (sqlConection.State != null &&
                    sqlConection.State == System.Data.ConnectionState.Open)
                {
                    sqlConection.Close();
                }

            }


        }



    }
}
