using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Enumerados;
using EntidadesDAO;



namespace Vista
{
    public partial class FrmMenuPrincipal : Form
    {

        private int contador;
        private List<Jugador> jugadores;
        int i = 0;
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            contador = 1;
            jugadores= new List<Jugador>();
            
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            Jugador jugadorUno = new Jugador();
            Jugador jugadorDos = new Jugador();
            try
            {
                jugadores = UsuarioAccesoDatos.TraerJugadoresADO();
                if (i < jugadores.Count -1)
                {
                    jugadorUno = jugadores[i];
                    jugadorDos = jugadores[i + 1];
                    i++;
                }
                else 
                {
                    i = 0;
                }
                

                if (jugadorUno is not null && jugadorDos is not null)
                {
                    Mesa mesa = new(this.contador, jugadorUno, jugadorDos);
                    FrmMesa frmMesa = new FrmMesa(mesa);
                    frmMesa.Show();
                    this.contador++;

                }

            }
            catch (ExceptionADO exADO) 
            {
                MessageBox.Show(exADO.Message, "Error");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");//lo uso para ver los errores
                MessageBox.Show("Error en el programa, llame al servicio tecnico", "Error");
            }
           
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try 
            { 
                FrmEstadisticas frmEstadisticas = new FrmEstadisticas();
                frmEstadisticas.ShowDialog();
            }
            catch (ExceptionADO exADO) 
            {
                MessageBox.Show(exADO.Message, "Error");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");//lo uso para ver los errores
                MessageBox.Show("Error en el programa, llame al servicio tecnico", "Error");
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAyuda frmAyuda = new FrmAyuda();
                frmAyuda.ShowDialog();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");//lo uso para ver los errores
                MessageBox.Show("Error en el programa, llame al servicio tecnico", "Error");
            }
           
        }

       
    }
}
