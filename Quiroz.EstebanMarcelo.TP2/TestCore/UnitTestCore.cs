using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Entidades.Enumerados;
using System.Collections.Generic;

namespace TestCore
{
    [TestClass]
    public class UnitTestCore
    {
        /// <summary>
        /// Devuelve los tantos para el envido
        /// </summary>
        [TestMethod]
        public void ProbarTantosDeEnvido()
        {
            List<Carta> listCartas = new List<Carta>();
            listCartas.Add(new Carta(1, EPalo.Basto));
            listCartas.Add(new Carta(2, EPalo.Basto));
            listCartas.Add(new Carta(11, EPalo.Espada));

            
            int tantos = Carta.DevolverTantosParaEnvido(listCartas);


            Assert.AreEqual(23, tantos);

        }


        /// <summary>
        /// compara las cartas devolviendo, -1,1,0, dependiendo el caso, segun las reglas del truco
        /// </summary>
        [TestMethod]
        public void ProbarTantosDeTruco()
        {
            Carta cartaUno = new Carta(1, EPalo.Espada);
            Carta cartaDos = new Carta(1, EPalo.Basto);

            //si tanto truco es igual a -1 significa que la carta dos es menor a la carta uno
            int tantoTruco = cartaDos.DevolverTantosTruco(cartaUno);


            Assert.AreEqual(-1, tantoTruco);

        }


    }
}
