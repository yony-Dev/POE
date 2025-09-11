using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ejercicio_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionSeleccionada = 0;
            bool ejecutarPrograma = true;

            // Bucle principal que mantiene el programa en ejecución
            while (ejecutarPrograma)
            {
                // Interfaz de menú 
                Console.WriteLine("MENU");
                Console.Write("Seleccione una opción (1-2): ");
                Console.WriteLine("\n1. Calcular promedio de calificaciones");
                Console.WriteLine("2. Salir");


                // Validación  de la entrada del usuario
                bool entradaCorrecta = int.TryParse(Console.ReadLine(), out opcionSeleccionada);

                if (!entradaCorrecta)
                {
                    Console.WriteLine("\n Error: Debe ingresar un numero válido");
                    continue;
                }

                // Procesamiento de la opción seleccionada
                if (opcionSeleccionada == 1)
                {
                    // Solicitud de cantidad de calificaciones
                    int cantidadCalificaciones;
                    Console.Write("\n Ingrese la cantidad de calificaciones que decea calcular: ");

                    // Validación estricta para números positivos
                    while (!int.TryParse(Console.ReadLine(), out cantidadCalificaciones) || cantidadCalificaciones <= 0)
                    {
                        Console.WriteLine("  Atención: Debe ingresar un número mayor a cero");
                        Console.Write(" Ingrese la cantidad de calificaciones a procesar: ");
                    }

                    // Inicialización del arreglo para almacenar calificaciones
                    double[] listaCalificaciones = new double[cantidadCalificaciones];
                    double totalCalificaciones = 0;

                    // Captura de calificaciones con validación exhaustiva
                    Console.WriteLine("\nIngreso de calificaciones entre 0-10");

                    for (int indice = 0; indice < listaCalificaciones.Length; indice++)
                    {
                        double calificacionActual;
                        bool calificacionValida = false;

                        while (!calificacionValida)
                        {
                            Console.Write($"Ingrese la {indice + 1}ª calificacion: "); //ª simbolo para ordenarlos y se vea mas bonito
                            string entradaUsuario = Console.ReadLine();

                            // Validación completa: número + rango permitido
                            if (double.TryParse(entradaUsuario, out calificacionActual) &&
                                calificacionActual >= 0 && calificacionActual <= 10)
                            {
                                listaCalificaciones[indice] = calificacionActual;
                                totalCalificaciones += calificacionActual;
                                calificacionValida = true;
                            }
                            else
                            {
                                Console.WriteLine(" Error: Ingrese un numero entre 0 y 10");
                            }
                        }
                    }

                    // Procesamiento y presentación de resultados
                    if (listaCalificaciones.Length > 0)
                    {
                        double promedioFinal = totalCalificaciones / cantidadCalificaciones;
                        double maximaCalificacion = listaCalificaciones.Max();
                        double minimaCalificacion = listaCalificaciones.Min();

                        // Presentación detallada de resultados
                        Console.WriteLine("RESULTADOS OBTENIDOS");

                        if (promedioFinal >= 7)
                        {
                            Console.WriteLine(" ESTADO: APROBADO");
                            Console.WriteLine($" Promedio obtenido: {promedioFinal:F3}");
                        }
                        else
                        {
                            Console.WriteLine(" ESTADO: REPROBADO");
                            Console.WriteLine($" Promedio obtenido: {promedioFinal:F2}");
                        }

                        Console.WriteLine($" Mejor calificación: {maximaCalificacion}");
                        Console.WriteLine($" Peor calificación: {minimaCalificacion}");

                        if (promedioFinal < 7)
                        {
                            Console.WriteLine(" Requiere un promedio mínimo de 7.0 para aprobar");
                        }
                    }
                }
                else if (opcionSeleccionada == 2)
                {
                    ejecutarPrograma = false;
                    Console.WriteLine("\n Ha salido del programa.");
                }
                else
                {
                    Console.WriteLine("\n  Opción no válida. Por favor seleccione 1 o 2");
                }
            }

        }
    }
}
/*
int.Parse() es como un profesor estricto: si le das un texto que no es un número válido,
el programa se detiene inmediatamente con un error. Por ejemplo, si intentas convertir 
"abc" con int.Parse("abc"), el programa crashea.

int.TryParse() es como un amigo comprensivo: intenta convertir el texto y si falla, 
simplemente te avisa sin que el programa se cierre. Devuelve true o false indicando si pudo convertir,
y si no pudo, el valor resultante es 0. Es mucho más seguro para validar entradas de usuario.

TryParse() es el concepto general que aplica
para distintos tipos de datos (double.TryParse, decimal.TryParse, etc.), no solo para enteros.

Recomendable:
Para validar entrada del usuario, int.TryParse() es el más recomendable porque evita que el programa se cierre inesperadamente
cuando el usuario comete errores al escribir. Te permite manejar los valores incorrectos de forma elegante y darle al usuario
la oportunidad de corregir su entrada sin interrumpir el flujo del programa.
*/