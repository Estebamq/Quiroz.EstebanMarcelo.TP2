using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static int numeroRonda;



        static Mesa()
        {
            rng = new Random();
            mazoDeCartas=new List<Carta>();
            numeroRonda = 1;
        }

        public Mesa(int numero,Jugador jugadorUno,Jugador jugadorDos)
        {
            this.numero = numero;
            numeroRonda = 1;
            this.jugadorUno = jugadorUno;
            this.jugadorDos = jugadorDos;
        }

        public List<Carta> MazoDeCartas
        {
            get 
            { 
                return mazoDeCartas; 
            }
        }

        public Jugador JugadorUno
        {
            get 
            { 
                return jugadorUno; 
            }
        }
        public Jugador JugadorDos
        {
            get 
            { 
                return jugadorDos; 
            }
        }

        public int Numero
        {
            get 
            {
                return numero; 
            } 
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
            this.DarCartasJugador(this.JugadorUno);
            this.DarCartasJugador(this.JugadorDos);
            
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
                tantosUno = Carta.DevolverTantosParaEnvido(this.JugadorUno.TresCartas);
                tantosDos = Carta.DevolverTantosParaEnvido(this.JugadorDos.TresCartas);


                if (tantosUno > tantosDos) 
                {
                    this.JugadorUno.Tantos += 2;
                }
                else if(tantosDos>tantosUno) 
                {
                    this.JugadorDos.Tantos += 2;
                }
                
            }

        }

        //-realenvido
        //-faltaEnvido
        //-truco
        public void CantarTruco(string respuestaQuiero)
        {
            List<Carta> cartasJugadorDos = this.JugadorDos.TresCartas;
            int i=0;
            int ronda;
            int rondaGanadaJugadorUno=0;
            int rondaGanadaJugadorDos=0;

            if (respuestaQuiero == "Quiero") 
            {
                foreach (Carta item in this.JugadorUno.TresCartas)
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
                    this.JugadorUno.Tantos += 2;
                }
                else if (rondaGanadaJugadorUno < rondaGanadaJugadorDos)
                {

                    this.JugadorDos.Tantos += 2;
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

            sb.AppendLine($"Jugador Uno: \n Apodo:{this.JugadorUno.Apodo}\n Tantos:{this.JugadorUno.Tantos} ");
            sb.AppendLine($"Jugador Dos: \n Apodo:{this.JugadorDos.Apodo}\n Tantos:{this.JugadorDos.Tantos} ");
            
            sb.AppendLine($"Ganador: {MostrarGanador()}");


            return sb.ToString();

        }

        public string MostrarGanador() 
        {
            string resultado;
            if (this.JugadorUno.Tantos > this.JugadorDos.Tantos)
            {

                resultado = "Jugador Uno";
            }
            else
            {
                if (this.JugadorUno.Tantos == this.JugadorDos.Tantos)
                {
                    resultado = "Empate";
                }
                else
                {
                    resultado = "Jugador Dos";
                }

            }

            return resultado;

        }



        public override string ToString()
        {
            return MostrarResultados();
        }



        //Delegados
        public static void CantarTrucoEnMesa(Action<string> cantoTruco, Action<string> cantoQuiero, Action<int> numeroRondas) 
        {
           
            Task.Run(()=> 
            {
                cantoTruco.Invoke("Truco");
                Thread.Sleep(2000);
                cantoQuiero.Invoke("Quiero");
                Thread.Sleep(2000);
                cantoTruco.Invoke(" ");
                cantoQuiero.Invoke(" ");
                numeroRondas.Invoke(numeroRonda++);
                
            });

        }

    }
}
