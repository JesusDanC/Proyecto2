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

        private String direccion,  num_ref;
        public Algoritmo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor sobrecargado con la direccion
        /// </summary>       
        public Algoritmo(string direccion, string _ref)
        {
            InitializeComponent();
            this.direccion = direccion;
            this.num_ref = _ref;
        }

        private void Algoritmo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu frm = new Menu();
            frm.Visible = true;
        }

        private void Algoritmo_Load(object sender, EventArgs e)
        {
            Int32.TryParse(num_ref, out int num);
            label1.Text = "Referencias a usar: " + num;
            referencias = ExcelLecturas.TraerDatos(2, 2, direccion, num);
            marco1 = ExcelLecturas.TraerDatos(3, 2, direccion, num);
            marco2 = ExcelLecturas.TraerDatos(4, 2, direccion, num);
            marco3 = ExcelLecturas.TraerDatos(5, 2, direccion, num);
            marco4 = ExcelLecturas.TraerDatos(6, 2, direccion, num);
            resultados = ExcelLecturas.TraerDatos(7, 2, direccion, num);
            //leer bits
            bitsM1 = ExcelLecturas.TraerDatos(10, 2, direccion, num);
            bitsM2 = ExcelLecturas.TraerDatos(11, 2, direccion, num);
            bitsM3 = ExcelLecturas.TraerDatos(12, 2, direccion, num);
            bitsM4 = ExcelLecturas.TraerDatos(13, 2, direccion, num);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(num_ref, out int num);
            bool esOptimo = false, esUsadoR = false, esFifo = false, esSegundaVida = false, esReloj = false;

            FIFO Fifo = new FIFO(referencias, marco1, marco2, marco3, marco4, num);
            MRU UsadoRecientemente = new MRU(referencias, marco1, marco2, marco3, marco4, resultados, num);
            Segundaoportunidad Segunda = new Segundaoportunidad(referencias, marco1, marco2, marco3, marco4, bitsM1, bitsM2, bitsM3, bitsM4, num);
            Reloj reloj = new Reloj(referencias, marco1, marco2, marco3, marco4, bitsM1, bitsM2, bitsM3, bitsM4, num);


            esFifo = Fifo.comprobarAlgoritmo();
            esUsadoR = UsadoRecientemente.comprobarAlgoritmo();
            esReloj = reloj.comprobarAlgoritmo();
            esOptimo = optimo.comprobarAlgoritmo();
            esSegundaVida = Segunda.comprobarAlgoritmo();

            if (esUsadoR == true)
            {
                MessageBox.Show("Es MRU");
                label6.Text = "Algoritmo utilizado: Usado recientemente";
            }else if (esOptimo)
            {
                MessageBox.Show("Es Optimo");
                label6.Text = "Algoritmo utilizado: Optimo";
            }else if (esFifo == true)
            {
                MessageBox.Show("Es FIFO");
                label6.Text = "Algoritmo utilizado: Fifo";
            }else if(esSegundaVida == true)
            {
                MessageBox.Show("Es Segunda Oportunidad");
                label6.Text = "Algoritmo utilizado: Segunda oportunidad";
            }
            else if (esReloj)
            {
                MessageBox.Show("Es Algoritmo Reloj");
                label6.Text = "Algoritmo utilizado: Reloj";
            }else
            {
                MessageBox.Show("Tu plantilla no concuerda con ningun algoritmo");
                label6.Text = "Algoritmo utilizado: no coincide ningun algoritmo";

            }

            //Cantidad de fallos         
            CalcularFallosyFrecuencia();
        }

        private void CalcularFallosyFrecuencia()
        {
            Int32.TryParse(num_ref, out int num);
            double fallos = 0;
            for (int i = 0; i < num-1; i++)
            {
                if (resultados[i] == "f"|| resultados[i] == "F")
                {
                    fallos++;
                }
            }
            label3.Text = "Cantidad de fallos: " + fallos;
            //Rendimiento y frecuencia
            double fre = 0, ren = 0;
            fre = (fallos/num);
            ren = 1 - fre;
            label4.Text = "Rendimiento: " + ren;
            label5.Text = "Frecuencia: " + fre;
            label1.Text = "Referencias a usar: " + num;
        }
    }
}
