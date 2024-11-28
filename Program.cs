using System;
using System.Collections.Generic;
using EjemploT4; // Importa el namespace donde están las clases

namespace EjemploT4
{
    class Program
    {
        static List<Mascota> mascotas = new List<Mascota>();
        static List<Servicio> servicios = new List<Servicio>();
        static List<Boleta> boletas = new List<Boleta>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n   Menú de opciones:");
                Console.WriteLine("\n******* Mascotas *******\n");
                Console.WriteLine("1. Crear mascota");
                Console.WriteLine("2. Eliminar mascota");
                Console.WriteLine("3. Listar mascotas");
                Console.WriteLine("\n******* Servicios *******\n");
                Console.WriteLine("4. Crear servicio");
                Console.WriteLine("5. Eliminar servicio");
                Console.WriteLine("6. Listar servicios");
                Console.WriteLine("\n******** Boleta ********\n");
                Console.WriteLine("7. Crear boleta");
                Console.WriteLine("8. Listar boletas");
                Console.WriteLine("9. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearMascota();
                        break;
                    case "2":
                        EliminarMascota();
                        break;
                    case "3":
                        ListarMascotas();
                        break;
                    case "4":
                        CrearServicio();
                        break;
                    case "5":
                        EliminarServicio();
                        break;
                    case "6":
                        ListarServicios();
                        break;
                    case "7":
                        CrearBoleta();
                        break;
                    case "8":
                        ListarBoletas();
                        break;
                    case "9":
                        Console.WriteLine("Saliendo del programa.");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        // Métodos Crear, Eliminar, Listar (idénticos al ejemplo anterior)
        // ...
        static void CrearMascota()
        {
            Console.Write("\n\nIngrese el nombre de la mascota: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la edad de la mascota: ");
            int edad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la especie de la mascota: ");
            string especie = Console.ReadLine();

            mascotas.Add(new Mascota { Nombre = nombre, Edad = edad, Especie = especie });
            Console.WriteLine("Mascota creada con éxito.");
        }
        static void EliminarMascota()
        {
            ListarMascotas();
            Console.Write("\n\nIngrese el índice de la mascota a eliminar: ");
            int index = int.Parse(Console.ReadLine());
            if (index >= 0 && index < mascotas.Count)
            {
                mascotas.RemoveAt(index);
                Console.WriteLine("Mascota eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }
        static void ListarMascotas()
        {
            if (mascotas.Count == 0)
            {
                Console.WriteLine("\n\nNo hay mascotas registradas.");
            }
            else
            {
                Console.WriteLine("\n\nMascotas:");
                for (int i = 0; i < mascotas.Count; i++)
                {
                    Console.WriteLine($"{i}: {mascotas[i]}");
                }
            }
        }
        static void CrearServicio()
        {
            Console.Write("\n\nIngrese la descripción del servicio: ");
            string descripcion = Console.ReadLine();
            Console.Write("Ingrese el precio del servicio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            servicios.Add(new Servicio { Descripcion = descripcion, Precio = precio });
            Console.WriteLine("Servicio creado con éxito.");
        }

        static void EliminarServicio()
        {
            ListarServicios();
            Console.Write("\n\nIngrese el índice del servicio a eliminar: ");
            int index = int.Parse(Console.ReadLine());
            if (index >= 0 && index < servicios.Count)
            {
                servicios.RemoveAt(index);
                Console.WriteLine("Servicio eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("\n\nÍndice inválido.");
            }
        }

        static void ListarServicios()
        {
            if (servicios.Count == 0)
            {
                Console.WriteLine("\n\nNo hay servicios registrados.");
            }
            else
            {
                Console.WriteLine("\n\nServicios:");
                for (int i = 0; i < servicios.Count; i++)
                {
                    Console.WriteLine($"{i}: {servicios[i]}");
                }
            }
        }

        static void CrearBoleta()
        {
            if (mascotas.Count == 0)
            {
                Console.WriteLine("\n\nNo hay mascotas registradas.");
                return;
            }
            if (servicios.Count == 0)
            {
                Console.WriteLine("\n\nNo hay servicios registrados.");
                return;
            }

            ListarMascotas();
            Console.Write("\nSeleccione el índice de la mascota: ");
            int mascotaIndex = int.Parse(Console.ReadLine());
            if (mascotaIndex < 0 || mascotaIndex >= mascotas.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            ListarServicios();
            Console.Write("\nSeleccione el índice del primer servicio: ");
            int servicio1Index = int.Parse(Console.ReadLine());
            if (servicio1Index < 0 || servicio1Index >= servicios.Count)
            {
                Console.WriteLine("\nÍndice inválido.");
                return;
            }

            Console.Write("\nSeleccione el índice del segundo servicio (opcional, presione Enter para omitir): ");
            string servicio2Input = Console.ReadLine();
            Servicio servicio2 = null;
            if (!string.IsNullOrEmpty(servicio2Input))
            {
                int servicio2Index = int.Parse(servicio2Input);
                if (servicio2Index >= 0 && servicio2Index < servicios.Count)
                {
                    servicio2 = servicios[servicio2Index];
                }
                else
                {
                    Console.WriteLine("\nÍndice inválido.");
                    return;
                }
            }

            string codigo = $"BOL - {boletas.Count + 1}";
            boletas.Add(new Boleta
            {
                Codigo = codigo,
                Mascota = mascotas[mascotaIndex],
                Servicio1 = servicios[servicio1Index],
                Servicio2 = servicio2,
                Total = servicios[servicio1Index].Precio + (servicio2?.Precio ?? 0)
            });

            Console.WriteLine("\nBoleta creada con éxito.");
        }

        static void ListarBoletas()
        {
            if (boletas.Count == 0)
            {
                Console.WriteLine("\n\nNo hay boletas registradas.");
            }
            else
            {
                Console.WriteLine("\n\nBoletas:");
                foreach (var boleta in boletas)
                {
                    Console.WriteLine(boleta);
                }
            }
        }
    }
}