using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Enumerados;

namespace Vista
{
    
    
    public partial class FrmMesa : Form
    {

        private Mesa mesa;
        private bool seCantoTruco;
       
        private List<Carta> cartasUno;
        private List<Carta> cartasDos;
        

        public FrmMesa()
        {
            InitializeComponent();
            this.cartasUno = new List<Carta>();
            this.cartasDos = new List<Carta>();
            seCantoTruco=false;
           
        }

        public FrmMesa(Mesa mesa) : this()
        {
            this.mesa = mesa;
        }

        private void FrmMesa_Load(object sender, EventArgs e)
        {
            this.Text = $"Mesa Nº {this.mesa.Numero}";
            this.lblCantaJ1.Hide();
            this.lblCantaJ2.Hide();
            this.lblGanador.Hide();
            this.lblNumeroRonda.Hide();
            this.lblApodoJugadorUno.Text = mesa.JugadorUno.Apodo;
            this.lblApodoJugadorDos.Text = mesa.JugadorDos.Apodo;
            //cargo el mazo
            this.mesa.CargarMazoMezclado();
            mesa.RepartirCartas();

        }


        //truco
        private void btnCantarTruco_Click(object sender, EventArgs e)
        {

            
                
                this.mesa.CantarTruco("Quiero");
                this.cartasUno = mesa.JugadorUno.TresCartas;
                this.cartasDos = mesa.JugadorDos.TresCartas;

                Mesa.CantarTrucoEnMesa(CantarTruco, CantarQuiero, AumentarRonda);

                Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    TirarUno();
                    Thread.Sleep(2000);
                    TirarDos();
                    Thread.Sleep(2000);
                    TirarDos();
                    ActualizaTantos();

                });
            if (cartasUno.Count != 0) 
            {
                mesa.RepartirCartas();
            }
            
           
           
        }

        private void CantarTruco(string cTruco) 
        {
            if(lblCantaJ1.InvokeRequired ) 
            {
                this.lblCantaJ1.BeginInvoke((MethodInvoker)delegate()
                {
                    this.lblCantaJ1.Show();
                    this.lblCantaJ1.Text = cTruco;

                });

            }
           
        }
        private void CantarQuiero(string cQuiero)
        {
            if (lblCantaJ2.InvokeRequired)
            {
                this.lblCantaJ2.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblCantaJ2.Show();
                    this.lblCantaJ2.Text = cQuiero;
                });

            }
            
        }
        private void AumentarRonda(int numeroDeRondas)
        {
            if (lblNumeroRonda.InvokeRequired)
            {
                this.lblCantaJ1.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroRonda.Show();
                    this.lblNumeroRonda.Text = numeroDeRondas.ToString();
   

                });

            }

        }

        private void TirarUno()
        {
            if (lblNumeroJ1CartaUno.InvokeRequired && lblNumeroJ2CartaUno.InvokeRequired && lblNumeroJ1CartaDos.InvokeRequired)
            {
                this.lblNumeroJ1CartaUno.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroJ1CartaUno.Text = cartasUno[0].Numero.ToString();
                    this.lblPaloJ1CartaUno.Text = cartasUno[0].EPalo.ToString();
                });

                this.lblNumeroJ2CartaUno.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroJ2CartaUno.Text = cartasDos[0].Numero.ToString();
                    this.lblPaloJ2CartaUno.Text = cartasDos[0].EPalo.ToString();

                });

                this.lblNumeroJ1CartaDos.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroJ1CartaDos.Text = cartasUno[1].Numero.ToString();
                    this.lblPaloJ1CartaDos.Text = cartasUno[1].EPalo.ToString();
                });

            }
        }


        private void TirarDos()
        {
            if (lblNumeroJ2CartaDos.InvokeRequired && lblNumeroJ1CartaTres.InvokeRequired && lblNumeroJ2CartaTres.InvokeRequired)
            {
                this.lblNumeroJ2CartaDos.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroJ2CartaDos.Text = cartasDos[1].Numero.ToString();
                    this.lblPaloJ2CartaDos.Text = cartasDos[1].EPalo.ToString();
                });

                this.lblNumeroJ1CartaTres.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroJ1CartaTres.Text = cartasUno[2].Numero.ToString();
                    this.lblPaloJ1CartaTres.Text = cartasUno[2].EPalo.ToString();

                });

                this.lblNumeroJ2CartaTres.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNumeroJ2CartaTres.Text = cartasDos[2].Numero.ToString();
                    this.lblPaloJ2CartaTres.Text = cartasDos[2].EPalo.ToString();
                });

                Thread.Sleep(1000);
                this.lblGanador.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblGanador.Show();
                    this.lblGanador.Text = mesa.MostrarGanador();
                    

                });
               
            }
            
        }

        private void btnEnvido_Click(object sender, EventArgs e)
        {
            int tantosJugadorUno = Carta.DevolverTantosParaEnvido(mesa.JugadorUno.TresCartas);
            int tantosJugadorDos = Carta.DevolverTantosParaEnvido(mesa.JugadorDos.TresCartas);
            mesa.CantarEnvido("Quiero");

            MessageBox.Show($"tantos jugador uno: {tantosJugadorUno} \ntantos jugador dos:{tantosJugadorDos}","Envido");
        }

        private void ActualizaTantos()
        {
            if (lblTantosJ1.InvokeRequired && lblTantosJ2.InvokeRequired)
            {
                this.lblTantosJ1.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblTantosJ1.Text = mesa.JugadorUno.Tantos.ToString();
                });

                this.lblTantosJ2.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblTantosJ2.Text = mesa.JugadorDos.Tantos.ToString();


                });

            }
        }


        //Envido






    }
}
