using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2._1
{
    class MRU 
    {
        //arreglos en los que se guardaran los datos de los marcos
        private List<string> referencias;
        private List<string> marco1;
        private List<string> marco2;
        private List<string> marco3;
        private List<string> marco4;
        //arreglo que guarda los fallos y no fallos
        private List<string> resultados;

        //constructor
        public MRU(List<string> referencias, List<string> marco1, List<string> marco2, List<string> marco3, List<string> marco4, List<string> resultados)
        {
            this.referencias = referencias;
            this.marco1 = marco1;
            this.marco2 = marco2;
            this.marco3 = marco3;
            this.marco4 = marco4;
            this.resultados = resultados;
        }

        internal bool comprobarAlgoritmo()
        {
            //bool hayVacios = false; //nos dice si hay marcos vacios
            int marcoVacio; //se marca aqui el marco que esta vacio
            int marcoAsignado; //el marco que el algoritmo asigna
            bool yaAsignado; //verifica si ya esta asignada la referencia
            bool concuerda = false; //verifica si concuerda la asignacion del algoritmo con la plantilla
            string referenciaActual; //guarda la referencia actual
            for (int i = 1; i < 15; i++)
            {
                //obtener referencia
                referenciaActual = referencias[i];
                //comprobar si hay espacios en blacn en algun marco, devuelve 0 si no hay vacios
                marcoVacio = comprobarMarcoVacio(i-1);
                //comprobar si existe la referencia antes de la asignacion
                yaAsignado = comprobarSiExiste(i, referenciaActual);
                if (yaAsignado) //asigna y no da error
                {
                    concuerda = true;
                } else if (marcoVacio != 0) //si hay marco vacio entonces asignar y marcar error
                {
                    concuerda = comprobarAsignacion(marcoVacio, referenciaActual, i);
                    if (!concuerda) return false;
                } else //si no hay marcos vacios y no existe es porque toca asignar
                {
                    marcoAsignado = AplicarAlgoritmo(i,referenciaActual);
                    concuerda = comprobarAsignacion(marcoAsignado, referenciaActual, i);
                    if (!concuerda)
                    {
                        return false;
                    }
                }

            }
            return concuerda;
        }

        /// <summary>
        /// Comprueba si hay marcos vacios y lo devuelve
        /// </summary>
        private int comprobarMarcoVacio(int posicion)
        {
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
        /// <summary>
        /// Comprueba que la asignacion por el algortimo sea la misma asignada en la plantilla
        /// </summary>
        private bool comprobarAsignacion(int marco, string referenciaActual, int posicion)
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

        /// <summary>
        /// Comprueba si existe ya la asignacion para la referencia
        /// </summary>
        private bool comprobarSiExiste(int posicion, string referencia)
        {
            try
            {
                //si en la pocisiona anterior a la referencia ya existia un marco para esta entonces existe
                if (marco1[posicion-1] == referencia)
                {
                    return true;
                }
                if (marco2[posicion - 1] == referencia)
                {
                    return true;
                }
                if (marco3[posicion - 1] == referencia)
                {
                    return true;
                }
                if (marco4[posicion - 1] == referencia)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                //si da error es porque era la primera asignacion, por eso no existe
                return false;
                throw;
            }
        }
        private int AplicarAlgoritmo(int posicion, string referenciaActual)
        {
            int conteo1, conteo2, conteo3, conteo4, seleccionado;
            conteo1 = ConteoDeUsoReciente(referencias, posicion, marco1[posicion-1]);
            conteo2 = ConteoDeUsoReciente(referencias, posicion, marco2[posicion-1]);
            conteo3 = ConteoDeUsoReciente(referencias, posicion, marco3[posicion-1]);
            conteo4 = ConteoDeUsoReciente(referencias, posicion, marco4[posicion-1]);
            seleccionado = SelecionarMayorConteo(conteo1, conteo2, conteo3, conteo4);
            return seleccionado;            
        }

        /// <summary>
        /// cuenta la ultima vez que aparecio el numero
        /// </summary>        
        private int ConteoDeUsoReciente(List<string> referencias, int posicion, string valorActual)
        {
            if (referencias[posicion-1] == valorActual)
            {
                return 1;
            }
            return 1 + ConteoDeUsoReciente(referencias, posicion - 1, valorActual);
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
    }
}
