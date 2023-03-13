using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2._1
{
    class Segundaoportunidad
    {
        protected List<string> referencias;
        protected List<string> marco1;
        protected List<string> marco2;
        protected List<string> marco3;
        protected List<string> marco4;
        protected List<string> bitsM1;
        protected List<string> bitsM2;
        protected List<string> bitsM3;
        protected List<string> bitsM4;

        public Segundaoportunidad(List<string> referencias, List<string> marco1, List<string> marco2, List<string> marco3, List<string> marco4, List<string> bitsM1, List<string> bitsM2, List<string> bitsM3, List<string> bitsM4)
        {
            this.referencias = referencias;
            this.marco1 = marco1;
            this.marco2 = marco2;
            this.marco3 = marco3;
            this.marco4 = marco4;

            this.bitsM1 = bitsM1;
            this.bitsM2 = bitsM2;
            this.bitsM3 = bitsM3;
            this.bitsM4 = bitsM4;
        }

        public virtual bool comprobarAlgoritmo()
        {
            bool segunda;
            int marcoVacio; 
            int marcoAsignado; 
            bool yaAsignado;
            bool concuerda = false; 
            string referenciaActual; 
            for (int i = 1; i < 15; i++)
            {
                
                referenciaActual = referencias[i];
                
                marcoVacio = comprobarMarcoVacio(i - 1);
                
                yaAsignado = comprobarSiExiste(i-1, referenciaActual);

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
                    if (!concuerda) 
                    {
                        return false;
                    }
                }
                else 
                {
                    marcoAsignado = Algoritmo(i, referenciaActual);
                    concuerda = comprobarAsignacion(marcoAsignado, referenciaActual, i);
                    if (!concuerda)
                    {
                        return false;
                    }
                }

            }
            return concuerda;
        }

        protected int comprobarMarcoVacio(int posicion)
        {
            if (posicion == -1)
            {
                return 1;
            }
            if (marco1[posicion] == "")
            {
                return 1;
            }
            else if (marco2[posicion] == "")
            {
                return 2;
            }
            else if (marco3[posicion] == "")
            {
                return 3;
            }
            else if (marco4[posicion] == "")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
        
        protected bool comprobarAsignacion(int marco, string referenciaActual, int posicion)
        {
            switch (marco)
            {
                case 1:
                    if (marco1[posicion] == referenciaActual)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (marco2[posicion] == referenciaActual)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (marco3[posicion] == referenciaActual)
                    {
                        return true;
                    }
                    break;
                case 4:
                    if (marco4[posicion] == referenciaActual)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        protected bool comprobarSiExiste(int posicion, string referencia)
        {
            try
            {
               
                if (marco1[posicion] == referencia)
                {
                    return true;
                }
                if (marco2[posicion] == referencia)
                {
                    return true;
                }
                if (marco3[posicion] == referencia)
                {
                    return true;
                }
                if (marco4[posicion] == referencia)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                
                return false;
                throw;
            }
        }

        protected bool confirmarsegunda(int pos, string refe)
        {
            if (marco1[pos] == refe && bitsM1[pos]=="1")
            {
                return true;
            }
            else if (marco2[pos] == refe && bitsM2[pos] == "1")
            {
                return true;
            }
            else if (marco3[pos] == refe && bitsM3[pos] == "1")
            {
                return true;
            }
            else if (marco4[pos] == refe && bitsM4[pos] == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Algoritmo(int posicion, string referenciaActual)
        {
            if (bitsM1[posicion-1] == "1" && bitsM2[posicion-1] == "1" && bitsM3[posicion-1] == "1" && bitsM4[posicion-1] == "1")
            {
                int conteo1, conteo2, conteo3, conteo4, seleccionado;
                conteo1 = Conteo1(posicion);
                conteo2 = Conteo2(posicion);
                conteo3 = Conteo3(posicion);
                conteo4 = Conteo4(posicion);
                seleccionado = SelecionarMayorConteo(conteo1, conteo2, conteo3, conteo4);
                return seleccionado;
            }
            else
            {
                int conteo1, conteo2, conteo3, conteo4, seleccionado;
                conteo1 = Conteo1(posicion-1);
                conteo2 = Conteo2(posicion-1);
                conteo3 = Conteo3(posicion-1);
                conteo4 = Conteo4(posicion-1);
                if (bitsM1[posicion-1] == "1")
                {
                    conteo1 = 0;
                }
                if (bitsM2[posicion-1] == "1")
                {
                    conteo2 = 0;
                }
                if (bitsM3[posicion-1] == "1")
                {
                    conteo3 = 0;
                }
                if (bitsM4[posicion-1] == "1") 
                {
                    conteo4 = 0;
                }
                seleccionado = SelecionarMayorConteo(conteo1, conteo2, conteo3, conteo4);
                return seleccionado;
            }
        }

        private int SelecionarMayorConteo(int conteo1, int conteo2, int conteo3, int conteo4)
        {
            int mayor = conteo1;
            int marcoSeleccionado = 1;
            if (mayor < conteo2)
            {
                mayor = conteo2;
                marcoSeleccionado = 2;
            }
            if (mayor < conteo3)
            {
                mayor = conteo3;
                marcoSeleccionado = 3;
            }
            if (mayor < conteo4)
            {
                mayor = conteo4;
                marcoSeleccionado = 4;
            }

            return marcoSeleccionado;
        }

        private int Conteo1(int posicion)
        {
            if (posicion == 1)
            {
                return 2;
            }
            if (marco1[posicion-1] != marco1[posicion])
            {
                return 1;
            }
            return 1 + Conteo1(posicion - 1);
        }
        private int Conteo2(int posicion)
        {
            if (marco2[posicion - 1] != marco2[posicion])
            {
                return 1;
            }
            return 1 + Conteo2(posicion - 1);
        }
        private int Conteo3(int posicion)
        {
            if (marco3[posicion - 1] != marco3[posicion])
            {
                return 1;
            }
            return 1 + Conteo3(posicion - 1);
        }
        private int Conteo4(int posicion)
        {
            if (marco4[posicion - 1] != marco4[posicion])
            {
                return 1;
            }
            return 1 + Conteo4(posicion - 1);
        }
    }
}
