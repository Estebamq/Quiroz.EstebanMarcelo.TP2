using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmAyuda : Form
    {
        /// <summary>
        /// Formulario para encontrar ayuda
        /// </summary>
        public FrmAyuda()
        {
            InitializeComponent();
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            this.rtbAyuda.Text = CargarInformacionAyuda();
        }

        private string CargarInformacionAyuda()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*********Bienvenidos al Simulador Trucazzo *********");
            sb.AppendLine("Para poder utilizar el presente programa puede ir presionando sobre las imagenes" +
                        "cada una de ellas lo llevaran a un formulario donde usted puede encontrar informacion util" +
                        "Por ejemplo: si necesita simular mesas presione varias veces el boton simular y podra observar distintas partidas" +
                        "Saludos");
            sb.AppendLine("\nAnte cualquier duda comunicarse al 0800-1234-Tecnico");
            return sb.ToString();
        }

        private void btnExportarTxt_Click(object sender, EventArgs e)
        {
            try
            {
                SerializarArchivoAyuda serializarArchivoAyuda = new SerializarArchivoAyuda();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ ayuda.txt";
                serializarArchivoAyuda.Escribir(CargarInformacionAyuda(), path);
                MessageBox.Show("Vea el archivo en el escritorio", "informacion");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al exportar el archivo en el escritorio", "Error");
                throw;
            }
            
        }
    }
}
