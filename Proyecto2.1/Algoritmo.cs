﻿using System;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool esOptimo = false, esUsadoR = false, esFifo = false, esSegundaVida = false, esReloj = false;
            //si cumple x
            //es optimo
            //sino si\
            MRU UsadoRecientemente = new MRU(referencias, marco1, marco2, marco3, marco4, resultados);
            esUsadoR = UsadoRecientemente.comprobarAlgoritmo();
            MessageBox.Show("Es usado " + esUsadoR);
            //sino si
            // es fifo
            //sino si
            // es fifo 2.0
            //sino si
            // es reloj
        }
    }
}
