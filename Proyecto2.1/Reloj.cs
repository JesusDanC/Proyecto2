using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2._1
{
    class Reloj : Segundaoportunidad
    {
        //constructor
        public Reloj(List<string> referencias, List<string> marco1, List<string> marco2, List<string> marco3, List<string> marco4, List<string> bitsM1, List<string> bitsM2, List<string> bitsM3, List<string> bitsM4, int num) : base(referencias, marco1, marco2, marco3, marco4, bitsM1, bitsM2, bitsM3, bitsM4, num)
        {
            this.marco1 = marco1;
            this.marco2 = marco2;
            this.marco3 = marco3;
            this.marco4 = marco4;
            this.referencias = referencias;
            this.bitsM1 = bitsM1;
            this.bitsM2 = bitsM2;
            this.bitsM3 = bitsM3;
            this.bitsM4 = bitsM4;
            this.num_ref = num;
        }

        private int MarcoApuntado = 1;

        public override bool comprobarAlgoritmo()
        {
            int marcoVacio;
            int marcoAsignado;
            bool yaAsignado, segunda;
            bool concuerda = false;
            string referenciaActual;

            for (int i = 0; i < num_ref-1; i++)
            {
                referenciaActual = referencias[i];

                marcoVacio = comprobarMarcoVacio(i - 1);

                yaAsignado = comprobarSiExiste(i - 1, referenciaActual);

                //cuando ya este asignado
                if (yaAsignado)
                {
                    segunda = confirmarsegunda(i, referenciaActual);
                    if (segunda)
                    {
                        concuerda = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (marcoVacio != 0)
                {
                    concuerda = comprobarAsignacion(marcoVacio, referenciaActual, i);
                    MarcoApuntado++;
                    if (MarcoApuntado > 4) MarcoApuntado = 1;
                    if (!concuerda)
                    {
                        return false;
                    }
                }
                else
                {
                    marcoAsignado = AplicarAlgoritmo(i-1, referenciaActual, MarcoApuntado);
                    MarcoApuntado = marcoAsignado+1;
                    if (MarcoApuntado > 4) MarcoApuntado = 1;
                    concuerda = comprobarAsignacion(marcoAsignado, referenciaActual, i);
                    if (!concuerda) return false;
                }                
            }

            return true;
        }

        public int AplicarAlgoritmo(int posicion, string referenciaActual, int marcoEnMira)
        {
            int seleccionado = 0;
            switch (marcoEnMira)
            {
                case 1:
                    seleccionado = Matar(bitsM1, posicion, referenciaActual, 1);
                    if (seleccionado == 1)
                    {
                        seleccionado = 1;
                    }
                    else
                    {
                        return AplicarAlgoritmo(posicion,referenciaActual,seleccionado);
                    }
                    break;
                case 2:
                    seleccionado = Matar(bitsM2, posicion , referenciaActual, 2);
                    if (seleccionado == 2)
                    {
                        seleccionado = 2;
                    }
                    else
                    {
                        return AplicarAlgoritmo(posicion, referenciaActual, seleccionado);
                    }
                    break;
                case 3:
                    seleccionado = Matar(bitsM3, posicion , referenciaActual, 3);
                    if (seleccionado == 3)
                    {
                        seleccionado = 3;
                    }
                    else
                    {
                        return AplicarAlgoritmo(posicion, referenciaActual, seleccionado);
                    }
                    break;
                case 4:
                    seleccionado = Matar(bitsM4, posicion , referenciaActual, 4);
                    if (seleccionado == 4)
                    {
                        seleccionado = 4;
                    }
                    else
                    {
                        return AplicarAlgoritmo(posicion , referenciaActual, seleccionado);
                    }
                    break;
                default:
                    break;
            }
            return seleccionado;
        }

        private int Matar(List<string> bit, int posicion, string referencia, int posicionMarco)
        {
            if (bit[posicion] == "0") //si el bit es 0 entonces se retorna este marco, sino el siguiente
            {
                return posicionMarco;
            }
            else
            {
                if (posicionMarco == 4) //Si el marco es 4 entonces volver a 1
                {
                    posicionMarco = 1;
                }
                posicionMarco++; // sino sumar al siguiente marco
            }
            
            

            return posicionMarco;            
        }
    }
}
