using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2._1
{
    public partial class Menu : Form
    {
        string direccion = "", num_ref="";
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string _direccion, string _ref)
        {
            InitializeComponent();
            direccion = _direccion;
            num_ref = _ref;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MMU frm = new MMU();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblDireccion.Text != "")
            {   
                Algoritmo frm = new Algoritmo(lblDireccion.Text, num_ref);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione una plantilla antes");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblDireccion.Text = direccion;
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}
