using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploT4
{
    public class Boleta
    {
        public string Codigo { get; set; }
        public Mascota Mascota { get; set; }
        public Servicio Servicio1 { get; set; }
        public Servicio Servicio2 { get; set; }
        public decimal Total { get; set; }

        public override string ToString()
        {
            string servicios = Servicio2 != null ? $"{Servicio1.Descripcion}, {Servicio2.Descripcion}" : $"{Servicio1.Descripcion}";
            return $"Código: {Codigo}, Mascota: {Mascota.Nombre}, Servicios: {servicios}, Total: ${Total}";
        }
    }
}
