using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerados;

namespace Entidades
{
    public class Jugador
    {

        private int id;
        private ETipoJugador tipo;
        private string apodo;
        private string apellido;
        private string nombre;
        private int edad;
        private  int tantos;
        private List<Carta> tresCartas;


        public Jugador(int id, ETipoJugador tipo, string apodo, string apellido, string nombre, int edad)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Apodo = apodo;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Tantos = tantos;
            TresCartas = new List<Carta>();
            
        }

        public Jugador():this(0,ETipoJugador.Maquina,"sin apodo","sin apellido","sin nombre",0)
        {

        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public ETipoJugador Tipo
        {
            get
            {
                return tipo;
            }
            set
            { 
                tipo = value; 
            }
        }
        public string Apodo
        {
            get 
            { 
                return apodo; 
            }
            set 
            { 
                apodo = value; 
            }
        }
        public string Apellido
        { 
            get 
            { 
                return apellido; 
            } 
            set 
            { 
                apellido = value; 
            } 
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public int Edad
        {
            get 
            { 
                return edad; 
            }
            set 
            { 
                edad = value; 
            }
        }
        public int Tantos
        {
            get 
            { 
                return tantos; 
            }
            set 
            { 
                tantos = value; 
            }
        }

        public List<Carta> TresCartas 
        {
            get 
            { 
                return tresCartas; 
            }
            set 
            { 
                tresCartas = value; 
            } 
        }

        public static Jugador BuscarJugador(int id) 
        {

            return new Jugador();
        }



        private string Mostrar() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Apodo: {this.Apodo}");
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Edad: {this.Edad}");
            sb.AppendLine($"Tantos: {this.Tantos}");
            sb.AppendLine($"***********Mis Cartas**********");

            if (this.TresCartas is not null) 
            {
                foreach (Carta item in tresCartas)
                {
                    sb.AppendLine(item.ToString());
                }

            }
            

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

    }
}
