using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2._1
{
    class ExcelLecturas
    {
        /// <summary>
        /// funcion que trae cualquier rango de datos en el documento
        /// </summary>
        
        internal static List<string> TraerDatos(int fila, int columna, string direccion)
        {
            //traer el documento
            SLDocument documento = new SLDocument(direccion);
            List<string> datos = new List<string>();

            //nuestra plantilla se encuentra en las primeras 16 columnas
            for (int i =columna ; i <= 16; i++)
            {
                //agregamos al arreglo todos los valores de esa fila y la columna que se esta corriendo
                datos.Add(documento.GetCellValueAsString(fila, i));
            }

            return datos;
        }
    }
}
