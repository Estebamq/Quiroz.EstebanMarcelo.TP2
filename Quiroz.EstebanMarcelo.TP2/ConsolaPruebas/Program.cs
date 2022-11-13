using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Enumerados;


namespace ConsolaPruebas
{
    class Program
    {
        static void Main(string[] args)
        {

            int cont = 0;
            string ganador;
            

            Jugador jugadorUno = new Jugador(1,ETipoJugador.Maquina,"Lolo","Marquez","Luis",23);
            Jugador jugadorDos = new Jugador(2,ETipoJugador.Maquina,"Pepe","Vazquez","Raul",20);
            Mesa mesa = new(1,jugadorUno,jugadorDos);
            mesa.CargarMazoMezclado();

            Console.WriteLine(".............Primera Ronda.........");
            mesa.RepartirCartas();
            mesa.RepartirCartas();
            Console.WriteLine(".................Canto Envido.................\n");
            mesa.CantarEnvido("Quiero");


            Console.WriteLine("********** Jugador Uno***********");
            Console.WriteLine(jugadorUno.ToString());
            Console.WriteLine("********** Jugador Dos***********");
            Console.WriteLine(jugadorDos.ToString());

            Console.WriteLine(".................Canto Truco.................\n");
            mesa.CantarTruco("Quiero");
            Console.WriteLine("********** Jugador Uno***********");
            Console.WriteLine(jugadorUno.ToString());
            Console.WriteLine("********** Jugador Dos***********");
            Console.WriteLine(jugadorDos.ToString());

            /*
            Console.WriteLine(".............Segunda Ronda.........");
            mesa.RepartirCartas(jugadorUno);
            mesa.RepartirCartas(jugadorDos);
            mesa.CantarTruco(jugadorUno, jugadorDos);
            
            //carta tantos

            
            Console.WriteLine("********** Jugador Uno***********");
            Console.WriteLine(jugadorUno.ToString());
            Console.WriteLine("********** Jugador Dos***********");
            Console.WriteLine(jugadorDos.ToString());

            Console.WriteLine("..................................\n");


            Console.WriteLine(".............Tercera Ronda.........");
            mesa.RepartirCartas(jugadorUno);
            mesa.RepartirCartas(jugadorDos);
            mesa.CantarTruco(jugadorUno, jugadorDos);


            Console.WriteLine("********** Jugador Uno***********");
            Console.WriteLine(jugadorUno.ToString());
            Console.WriteLine("********** Jugador Dos***********");
            Console.WriteLine(jugadorDos.ToString());

            Console.WriteLine("..................................\n");
            
            Console.WriteLine(".............Cuarta Ronda.........");
            mesa.RepartirCartas(jugadorUno);
            mesa.RepartirCartas(jugadorDos);
            mesa.CantarTruco(jugadorUno, jugadorDos);


            Console.WriteLine("********** Jugador Uno***********");
            Console.WriteLine(jugadorUno.ToString());
            Console.WriteLine("********** Jugador Dos***********");
            Console.WriteLine(jugadorDos.ToString());

            Console.WriteLine("..................................\n");

            
            */

            Console.WriteLine(".............Ganador.........");
            if (jugadorUno.Tantos>jugadorDos.Tantos) 
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

            Console.WriteLine(ganador);
            Console.WriteLine("..................................\n");
            Console.WriteLine("**********Mazo Restante***********");
            foreach (Carta item in mesa.MazoDeCartas)
            {
                Console.WriteLine(item.ToString());
                cont++;
            }
            Console.WriteLine("*************************");
            Console.WriteLine($"Cantidad de cartas restantes: {cont}");
           
            Console.ReadKey();

           
        }
    }
}
