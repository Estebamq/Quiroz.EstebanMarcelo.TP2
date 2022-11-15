using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Mesa
    {
        private int numero;
        private static List<Carta> mazoDeCartas;
        private static Random rng;
        private Jugador jugadorUno;
        private Jugador jugadorDos;

       

        static Mesa()
        {
            rng = new Random();
            mazoDeCartas=new List<Carta>();
        }

        private Mesa() 
        {
            jugadorUno = new Jugador();
            jugadorDos = new Jugador();
        }

        public Mesa(int numero,Jugador jugadorUno,Jugador jugadorDos):this()
        {
            this.numero = numero;
            this.jugadorUno = jugadorUno;
            this.jugadorDos = jugadorDos;
        }

        public List<Carta> MazoDeCartas
        {
            get { return mazoDeCartas; }
        }
        //cargar cartas 
        public void CargarMazoMezclado()
        {

            int k;
            Carta value;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 1; i < 13; i++)
                {
                    if (i != 8 && i != 9)
                    {
                        Mesa.mazoDeCartas.Add(new Carta(i, (Enumerados.EPalo)j));
                    }
                }

            }

            int n = this.MazoDeCartas.Count;
            while (n > 1)
            {
                n--;
                k = rng.Next(n + 1);
                value = Mesa.mazoDeCartas[k];
                Mesa.mazoDeCartas[k] = Mesa.mazoDeCartas[n];
                Mesa.mazoDeCartas[n] = value;
            }

            
        }


        


        //Repartir
        public void RepartirCartas()
        {
            this.DarCartasJugador(this.jugadorUno);
            this.DarCartasJugador(this.jugadorDos);
            
        }

        private void DarCartasJugador(Jugador jugador) 
        {
            if (jugador is not null)
            {
                jugador.TresCartas = Carta.DarTresCartas(Mesa.mazoDeCartas);
                if (MazoDeCartas.Count != 0)
                {
                    Mesa.mazoDeCartas = this.EliminarCartas(jugador.TresCartas);
                }
            }

        }

        private List<Carta> EliminarCartas(List<Carta> tresCartas)
        {
            if (Mesa.mazoDeCartas is not null && tresCartas is not null)
            {
                foreach (Carta item in tresCartas)
                {
                    Mesa.mazoDeCartas -= item;
                }

            }

            return Mesa.mazoDeCartas;
        }

        //Comparar mesas 
        //-envido
        public void CantarEnvido(string respuestaQuiero)
        {
            int tantosUno=0;
            int tantosDos=0;

            if (respuestaQuiero == "Quiero")
            {
                tantosUno = Carta.DevolverTantosParaEnvido(this.jugadorUno.TresCartas);
                tantosDos = Carta.DevolverTantosParaEnvido(this.jugadorDos.TresCartas);


                if (tantosUno > tantosDos) 
                {
                    this.jugadorUno.Tantos += 2;
                }
                else if(tantosDos>tantosUno) 
                {
                    this.jugadorDos.Tantos += 2;
                }
                
            }

        }

        //-realenvido
        //-faltaEnvido
        //-truco
        public void CantarTruco(string respuestaQuiero)
        {
            List<Carta> cartasJugadorDos = this.jugadorDos.TresCartas;
            int i=0;
            int ronda;
            int rondaGanadaJugadorUno=0;
            int rondaGanadaJugadorDos=0;

            if (respuestaQuiero == "Quiero") 
            {
                foreach (Carta item in this.jugadorUno.TresCartas)
                {

                    ronda = item.DevolverTantosTruco(cartasJugadorDos[i]);
                    i++;
                    if (ronda == 1)
                    {
                        rondaGanadaJugadorUno += 1;
                    }
                    else
                    {
                        if (ronda == -1)
                        {
                            rondaGanadaJugadorDos += 1;
                        }
                    }
                }

                if (rondaGanadaJugadorUno > rondaGanadaJugadorDos)
                {
                    this.jugadorUno.Tantos += 2;
                }
                else if (rondaGanadaJugadorUno < rondaGanadaJugadorDos)
                {

                    this.jugadorDos.Tantos += 2;
                }
            }
            


        }

        //retruco
        //valecuatro


        //Sumar puntos

        //Mostrar resultados
        private string MostrarResultados()
        {
            StringBuilder sb = new StringBuilder();
            string ganador;

            sb.AppendLine($"Jugador Uno: \n Apodo:{this.jugadorUno.Apodo}\n Tantos:{this.jugadorUno.Tantos} ");
            sb.AppendLine($"Jugador Dos: \n Apodo:{this.jugadorDos.Apodo}\n Tantos:{this.jugadorDos.Tantos} ");
            if (jugadorUno.Tantos > jugadorDos.Tantos)
            {

                ganador = "Jugador Uno";
            }
            else
            {
                if (jugadorUno.Tantos == jugadorDos.Tantos)
                {
                    ganador = "Empate";
                }
                else
                {
                    ganador = "Jugador Dos";
                }

            }
            sb.AppendLine($"Ganador: {ganador}");


            return sb.ToString();

        }



        public override string ToString()
        {
            return MostrarResultados();
        }

    }
}
