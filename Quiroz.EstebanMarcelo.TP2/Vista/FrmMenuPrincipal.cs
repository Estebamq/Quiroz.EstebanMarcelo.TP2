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



namespace Vista
{
    public partial class FrmMenuPrincipal : Form
    {

        private int contador;
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            contador = 1;
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            Jugador jugadorUno = new Jugador(1, ETipoJugador.Maquina, "Lolo", "Marquez", "Luis", 23);
            Jugador jugadorDos = new Jugador(2, ETipoJugador.Maquina, "Pepe", "Vazquez", "Raul", 20);
            Mesa mesa = new(this.contador, jugadorUno, jugadorDos);
            FrmMesa frmMesa = new FrmMesa(mesa);
            frmMesa.Show();
            this.contador++;
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas frmEstadisticas = new FrmEstadisticas();
            frmEstadisticas.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            FrmAyuda frmAyuda = new FrmAyuda();
            frmAyuda.ShowDialog();
        }

       
    }
}
