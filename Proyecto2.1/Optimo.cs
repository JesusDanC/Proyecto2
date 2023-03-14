using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2._1
{
    class Optimo : MRU
    {
        public Optimo(List<string> referencias, List<string> marco1, List<string> marco2, List<string> marco3, List<string> marco4, List<string> resultados, int num) : base(referencias, marco1, marco2, marco3, marco4, resultados, num)
        {
            this.referencias = referencias;
            this.marco1 = marco1;
            this.marco2 = marco2;
            this.marco3 = marco3;
            this.marco4 = marco4;
            this.resultados = resultados;
            this.num_ref = num;
        }

        public override bool comprobarAlgoritmo()
        {
            int marcoVacio;
            int marcoAsignado;
            bool yaAsignado;
            bool concuerda = true;
            string referenciaActual;

            for (int i = 0; i < referencias.Count-1; i++)
            {
                referenciaActual = referencias[i];

                marcoVacio = comprobarMarcoVacio(i - 1);

                yaAsignado = comprobarSiExiste(i, referenciaActual);

                //cuando ya este asignado
                if (yaAsignado)
                {
                    concuerda = true;
                    //hacer nada
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
                    marcoAsignado = AplicarAlgoritmo(i, referenciaActual);
                    concuerda = comprobarAsignacion(marcoAsignado, referenciaActual, i);
                    if (!concuerda)
                    {
                        return false;
                    }

                }
            }

            return concuerda;
        }
        public override int AplicarAlgoritmo(int posicion, string referenciaActual)
        {
            int conteo1, conteo2, conteo3, conteo4, seleccionado;
            conteo1 = ConteoDeUsoFuturo(referencias, posicion, marco1[posicion - 1]);
            conteo2 = ConteoDeUsoFuturo(referencias, posicion, marco2[posicion - 1]);
            conteo3 = ConteoDeUsoFuturo(referencias, posicion, marco3[posicion - 1]);
            conteo4 = ConteoDeUsoFuturo(referencias, posicion, marco4[posicion - 1]);
            seleccionado = SelecionarMayorConteo(conteo1, conteo2, conteo3, conteo4);
            return seleccionado;
        }

        private int ConteoDeUsoFuturo(List<string> referencias, int posicion, string valorActual)
        {
            if ((posicion + 1) == num_ref)
            {
                return 1;
            }
            if (referencias[posicion] == valorActual )
            {
                return 1;
            }
            return 1 + ConteoDeUsoFuturo(referencias, posicion + 1, valorActual);
        }
    }
}
