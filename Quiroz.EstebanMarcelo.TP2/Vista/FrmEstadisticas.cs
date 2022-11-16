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
using EntidadesDAO;

namespace Vista
{
    public partial class FrmEstadisticas : Form
    {
        private List<Jugador> jugadores;
        public FrmEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void ActualizarDatos() 
        {

            try
            {

                jugadores = UsuarioAccesoDatos.TraerJugadoresADO();
                dgvEstadisticas.DataSource = jugadores;

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
    }
}
