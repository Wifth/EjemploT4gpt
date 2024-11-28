using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploT4
{
    public class Servicio
    {
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"Descripción: {Descripcion}, Precio: ${Precio}";
        }
    }
}