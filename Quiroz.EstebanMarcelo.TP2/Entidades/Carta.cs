using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerados;

namespace Entidades
{

    
    public class Carta
    {
        private int numero;
        private EPalo ePalo;

        public Carta(int numero, EPalo ePalo)
        {
            this.numero = numero;
            this.ePalo = ePalo;
        }


        //propiedades
        public int Numero { get => numero; set => numero = value; }
        public EPalo EPalo { get => ePalo; set => ePalo = value; }

        //

        //mezclar carta

        //dar tres cartas
        public static List<Carta> DarTresCartas(List<Carta> mazo)
        {
            List<Carta> tresCartas = new List<Carta>();

            if (mazo is not null)
            {
                foreach (Carta item in mazo)
                {
                    if (tresCartas.Count < 3)
                    {
                        tresCartas.Add(item);
                    }

                }
            }

            return tresCartas;
        }

        //Eliminar cartas del Mazo


        public static List<Carta> operator -(List<Carta> mazo, Carta carta)
        {
            if (mazo == carta)
            {
                mazo.Remove(carta);
            }
            return mazo;

        }

        public static bool operator ==(List<Carta> mazo, Carta carta)
        {
            bool retorno = false;
            if (mazo is not null && carta is not null)
            {
                foreach (Carta item in mazo)
                {
                    if (item.EPalo == carta.EPalo && item.Numero == carta.Numero)
                    {
                        retorno = true;
                    }
                }
            }

            return retorno;

        }

        public static bool operator !=(List<Carta> mazo, Carta carta)
        {
            return !(mazo == carta);
        }


        //modificar
        public override bool Equals(object obj)
        {
            return (obj is not null) && (obj is Carta);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        //comparar cartas
        /// <summary>
        /// Devuelve 1 si gano la carta que comparo, 0 si son iguales, -1 si perdio
        /// </summary>
        /// <param name="carta"></param>
        /// <returns></returns>
        public int DevolverTantosTruco(Carta carta){

            int respuesta=0;

            switch (carta.Numero) 
            {
                case 1:
                    switch (carta.EPalo) 
                    {
                        case EPalo.Espada:

                            respuesta = -1;
                        break;

                        case EPalo.Basto:
                            if (this.EPalo != EPalo.Espada)
                            {
                                respuesta = -1;
                            }
                        break;
                        default:
                            if (this.Numero == 1) 
                            {
                                respuesta = 0;
                            }
                            else 
                            {
                                if (this.Numero>3 && this.Numero <13) 
                                {
                                    if (this.Numero == 7 && this.EPalo == EPalo.Espada || this.Numero == 7 && this.EPalo == EPalo.Oro) 
                                    {
                                        respuesta = 1;
                                    }
                                    else 
                                    {
                                        respuesta = -1;
                                    }
                                }
                                else 
                                {
                                    respuesta = 1;
                                }
                            }
                        break;

                      }
                    break;
                case 2:
                    if (this.Numero > 3 && this.Numero < 13)
                    {
                        if (this.Numero == 7 && this.EPalo == EPalo.Espada || this.Numero == 7 && this.EPalo == EPalo.Oro)
                        {
                            respuesta = 1;
                        }
                        else
                        {
                            respuesta = -1;
                        }
                    }
                    else
                    {
                        if (this.Numero == 2) 
                        {
                            respuesta = 0;
                        }
                        else 
                        {
                            respuesta = -1;
                        }
                        
                    }
                    break;
                case 3:
                    if (this.Numero > 3 && this.Numero < 13)
                    {
                        if (this.Numero == 7 && this.EPalo == EPalo.Espada || this.Numero == 7 && this.EPalo == EPalo.Oro)
                        {
                            respuesta = 1;
                        }
                        else
                        {
                            respuesta = -1;
                        }
                    }
                    else
                    {
                        if (this.Numero == 3)
                        {
                            respuesta = 0;
                        }
                        else
                        {
                            if (this.Numero == 1 && this.EPalo == EPalo.Espada || this.Numero == 1 && this.EPalo == EPalo.Basto)
                            {
                                respuesta = 1;
                            }
                            else 
                            {
                                respuesta = -1;
                            }
                            
                        }

                    }

                    break;
                case 4:
                    if (this.Numero==4) 
                    {
                        respuesta = 0;
                    }
                    else 
                    {
                        respuesta = 1;
                    }

                    break;
                case 5:
                    if (this.Numero == 4)
                    {
                        respuesta = -1;
                    }
                    else
                    {
                        if(this.Numero == 5) 
                        {
                            respuesta = 0;
                        }
                        else 
                        {
                            respuesta = 1;
                        }
                       
                    }
                    break;
                case 6:
                    if (this.Numero < 6 && this.numero >3)
                    {
                        respuesta = -1;
                    }
                    else
                    {
                        if (this.Numero == 6)
                        {
                            respuesta = 0;
                        }
                        else
                        {
                            respuesta = 1;
                        }

                    }
                break;
                case 7:
                    switch (carta.EPalo) 
                    {
                        case EPalo.Espada:
                            if (this.Numero==1 && this.EPalo==EPalo.Espada || this.Numero == 1 && this.EPalo == EPalo.Basto) 
                            {
                                respuesta = 1;
                            }
                            else 
                            {
                               respuesta = -1;
                               
                            }
                        break;

                        case EPalo.Oro:
                            if (this.Numero == 1 && this.EPalo == EPalo.Espada || this.Numero == 1 && this.EPalo == EPalo.Basto)
                            {
                                respuesta = 1;
                            }
                            else
                            {
                                if (this.Numero == 7 && this.EPalo == EPalo.Espada)
                                {
                                    respuesta = 1;
                                }
                                else
                                {
                                    respuesta = -1;
                                }
                            }
                            break;
                        default:
                            if (this.Numero>3 && this.Numero<7) 
                            {
                                respuesta = -1;
                            }
                            else 
                            {
                                if (this.Numero == 7 && this.EPalo != EPalo.Espada || this.Numero == 7 && this.EPalo != EPalo.Oro)
                                {
                                    respuesta = 0;
                                }
                                else 
                                {
                                    respuesta = 1;
                                }
                            }

                        break;
                    }
                    break;
                case 10:
                    if (this.Numero > 3 && this.Numero < 7)
                    {
                        if (this.Numero == 7 && this.EPalo == EPalo.Espada || this.Numero == 7 && this.EPalo == EPalo.Oro)
                        {
                            respuesta = 1;
                        }
                        else
                        {
                            respuesta = -1;
                        }
                    }
                    else
                    {
                        if (this.Numero == 10) 
                        {
                            respuesta = 0;
                        }
                        else 
                        {
                            respuesta = 1;
                        }
                    }
                    break;
                case 11:
                    if (this.Numero > 3 && this.Numero < 11)
                    {
                        if (this.Numero == 7 && this.EPalo == EPalo.Espada || this.Numero == 7 && this.EPalo == EPalo.Oro)
                        {
                            respuesta = 1;
                        }
                        else
                        {
                            respuesta = -1;
                        }
                    }
                    else
                    {
                        if (this.Numero == 11)
                        {
                            respuesta = 0;
                        }
                        else
                        {
                            respuesta = 1;
                        }
                    }
                    break;
                case 12:

                    if (this.Numero > 3 && this.Numero < 12)
                    {
                        if (this.Numero == 7 && this.EPalo == EPalo.Espada || this.Numero == 7 && this.EPalo == EPalo.Oro)
                        {
                            respuesta = 1;
                        }
                        else
                        {
                            respuesta = -1;
                        }
                    }
                    else
                    {
                        if (this.Numero == 12)
                        {
                            respuesta = 0;
                        }
                        else
                        {
                            respuesta = 1;
                        }
                    }
                    break;

            }

            return respuesta;

        }

        //envido
        public static int DevolverTantosParaEnvido(List<Carta> cartasEnvido)
        {
            int tantos=0;
            int contarTantos = 0;
            List<Carta> cartasTantos = new List<Carta>();
            List<Carta> cartasTantosAux = new List<Carta>();


            if (cartasEnvido is not null)
            {
               


                for (int i = 0; i < 4; i++)
                {
                    cartasTantosAux = cartasEnvido.FindAll(carta => carta.EPalo == (EPalo)i);

                    if (cartasTantosAux.Count ==3) 
                    {
                        cartasTantos = cartasTantosAux;
                        break;
                    }
                    else if (cartasTantosAux.Count > 1) 
                    {
                        cartasTantos = cartasTantosAux;
                    }
                }

                //determino el valor de los tantos
                if (cartasTantos.Count > 1) 
                {
                    foreach  (Carta carta in cartasTantos)
                    {
                        if(carta.Numero>0 && carta.Numero<8)
                        { 
                            contarTantos += carta.Numero;
                        }

                    }

                    if (contarTantos != 0) 
                    {
                        tantos = contarTantos + 20; 
                    }
                    else 
                    {
                        tantos = 20;
                    }
                }
               

            }


            return tantos;
        }

        


        //mostrar carta
        private string MostrarCarta() 
        {
            return $"numero: {this.Numero} \n palo:{this.EPalo.ToString()} ";
        }


        public override string ToString()
        {
            return MostrarCarta();
        }


    }
}
