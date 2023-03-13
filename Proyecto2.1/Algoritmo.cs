using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Proyecto2._1
{
    public partial class Algoritmo : System.Windows.Forms.Form
    {
        //arreglos en los que se guardaran los datos de los marcos
        private static List<string> referencias;
        private static List<string> marco1;
        private static List<string> marco2;
        private static List<string> marco3;
        private static List<string> marco4;
        //arreglo que guarda los fallos y no fallos
        private static List<string> resultados;

        //arreglos para los bits
        private static List<string> bitsM1;
        private static List<string> bitsM2;
        private static List<string> bitsM3;
        private static List<string> bitsM4;

        private String direccion;
        public Algoritmo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor sobrecargado con la direccion
        /// </summary>       
        public Algoritmo(string direccion)
        {
            InitializeComponent();
            this.direccion = direccion;
        }

        private void Algoritmo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu frm = new Menu();
            frm.Visible = true;
        }

        private void Algoritmo_Load(object sender, EventArgs e)
        {
            referencias = ExcelLecturas.TraerDatos(2, 2, direccion);
            marco1 = ExcelLecturas.TraerDatos(3, 2, direccion);
            marco2 = ExcelLecturas.TraerDatos(4, 2, direccion);
            marco3 = ExcelLecturas.TraerDatos(5, 2, direccion);
            marco4 = ExcelLecturas.TraerDatos(6, 2, direccion);
            resultados = ExcelLecturas.TraerDatos(7, 2, direccion);
            //leer bits
            bitsM1 = ExcelLecturas.TraerDatos(10, 2, direccion);
            bitsM2 = ExcelLecturas.TraerDatos(11, 2, direccion);
            bitsM3 = ExcelLecturas.TraerDatos(12, 2, direccion);
            bitsM4 = ExcelLecturas.TraerDatos(13, 2, direccion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool esOptimo = false, esUsadoR = false, esFifo = false, esSegundaVida = false, esReloj = false;

            FIFO Fifo = new FIFO(referencias, marco1, marco2, marco3, marco4);
            MRU UsadoRecientemente = new MRU(referencias, marco1, marco2, marco3, marco4, resultados);
            Segundaoportunidad Segunda = new Segundaoportunidad(referencias, marco1, marco2, marco3, marco4, bitsM1, bitsM2, bitsM3, bitsM4);
            Reloj reloj = new Reloj(referencias, marco1, marco2, marco3, marco4, bitsM1, bitsM2, bitsM3, bitsM4);

            esFifo = Fifo.comprobarAlgoritmo();
            esUsadoR = UsadoRecientemente.comprobarAlgoritmo();
            esReloj = reloj.comprobarAlgoritmo();

            //si cumple x
            //es optimo
            //sino si\
            if (esUsadoR == true)
            {
                MessageBox.Show("Es MRU");
                label6.Text = "Algoritmo utilizado: Usado recientemente";
            }
            //sino si
            if (esFifo == true)
            {
                MessageBox.Show("Es FIFO");
                label6.Text = "Algoritmo utilizado: Fifo";
            }
            // es fifo
            //sino si
            esSegundaVida = Segunda.comprobarAlgoritmo();
            if(esSegundaVida == true)
            {
                MessageBox.Show("Es Segunda Oportunidad");
                label6.Text = "Algoritmo utilizado: Segunda oportunidad";
            }
            else if (esReloj)
            {
                MessageBox.Show("Es Algoritmo Reloj");
                label6.Text = "Algoritmo utilizado: Reloj";
            }
                //sino si
                // es reloj

                CalcularFallosyFrecuencia();
            //Cantidad de fallos         
        }

        private void CalcularFallosyFrecuencia()
        {
            double fallos = 0;
            for (int i = 0; i < 15; i++)
            {
                if (resultados[i] == "f")
                {
                    fallos++;
                }
            }
            label3.Text = "Cantidad de fallos: " + fallos;
            //Rendimiento y frecuencia
            double fre = 0, ren = 0;
            fre = (fallos/15);
            ren = 1 - fre;
            label4.Text = "Rendimiento: " + ren;
            label5.Text = "Frecuencia: " + fre;
        }
    }
}
