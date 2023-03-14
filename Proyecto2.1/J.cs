using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace J
{
    public partial class J : Form
    {
        

        int velocidad = 10;
        int contador = 0; //medir el puntaje para velocidad
        int puntaje = 0;

        bool Arriba;
        bool Izquierda;










        private void J_Load(object sender, EventArgs e)
        {


            this.Text = "Puntaje 0";
            Random aleatorio = new Random();
            pelota.Location = new Point(0, aleatorio.Next(this.Height));
            Arriba = true;
            Izquierda = true;
            timer1.Enabled = true;
            puntaje = 0;


        }

        private void J_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            if (pelota.Left > pictureBox2.Left)
            {
                timer1.Enabled = false;
                MessageBox.Show("Puntaje: " + puntaje.ToString() + "veces!");
                puntaje = 0;
                velocidad = 10;
                contador = 0;

            }
            if (pelota.Left + pelota.Width >= pictureBox2.Left && 
               pelota.Left + pelota.Width <= pictureBox2.Left + pictureBox2.Width &&
               pelota.Top + pelota.Height >= pictureBox2.Top &&
               pelota.Top + pelota.Height <= pictureBox2.Top + pictureBox2.Height)
            {
                Izquierda = false;
                puntaje += 1;
                this.Text = "Puntuacion: " + puntaje.ToString() + "";
                contador += 1;
                if (contador > 5)
                {
                    velocidad += 1;
                    contador = 0;
                }
            }





            #region   Movimiento de la pelota
            if (Izquierda)
            {
                pelota.Left += velocidad;
            }
            else
            {
                pelota.Left -= velocidad;
            }

            if (Arriba)
            {
                pelota.Top += velocidad;
            }
            else
            {
                pelota.Top -= velocidad;
            }

            if (pelota.Top >= this.Height - 60)
            {
                Arriba = false;
            }

            if (pelota.Top <= 0)
            {
                Arriba = true;

            }

            if (pelota.Left <= 0)
            {
                Izquierda = true;
            }

            #endregion






        }

        private void ping_pong_game_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Top = e.Y;
        }

        private void ping_pong_game_Click(object sender, EventArgs e)
        {

        }

        private void ping_pong_game_Load(object sender, MouseEventArgs e)
        {

        }

        private void ping_pong_game_Load_1(object sender, EventArgs e)
        {

        }
    }
}
