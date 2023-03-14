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

namespace Proyecto2._1
{
    public partial class MMU : Form
    {
        public MMU()
        {
            InitializeComponent();
        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Buscar plantilla xls",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "xlsx files(*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblSeleccionar.Text = openFileDialog1.FileName;
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu(lblSeleccionar.Text, lblref.Text);
            frm.Show();
            this.Close();
        }

        private void MMU_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lblref.Text = numericUpDown1.Value.ToString();
        }
    }
}
