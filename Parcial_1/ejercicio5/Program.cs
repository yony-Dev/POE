using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio5
{
    enum Dificultad { Facil = 1, Medio = 2, Dificil = 3 }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> puntuaciones = new List<int>();
            bool seguirJugando = true;

            while (seguirJugando)
            {
                // Selección de dificultad
                Console.WriteLine("Seleccione nivel del juego:");
                Console.WriteLine("1. Fácil (1-50)");
                Console.WriteLine("2. Medio (1-100)");
                Console.WriteLine("3. Difícil (1-200)");

                Dificultad nivel;
                if (!Enum.TryParse(Console.ReadLine(), out nivel))
                {
                    Console.WriteLine("Nivel no disponible. Se usará Medio.");
                    nivel = Dificultad.Medio;
                }

                int max = 100;
                switch (nivel)
                {
                    case Dificultad.Facil:
                        max = 50;
                        break;
                    case Dificultad.Medio:
                        max = 100;
                        break;
                    case Dificultad.Dificil:
                        max = 200;
                        break;
                    default:
                        max = 100;
                        break;
                }

                int numeroSecreto = random.Next(1, max + 1);
                int intentos = 0;
                bool adivinado = false;

                Console.WriteLine($"\nAdivina el numero entre 1 y {max}.");

                while (!adivinado)
                {
                    Console.Write("Ingresa tu número: ");
                    int intento;
                    if (int.TryParse(Console.ReadLine(), out intento))
                    {
                        intentos++;
                        int diferencia = Math.Abs(intento - numeroSecreto);

                        if (intento == numeroSecreto)
                        {
                            Console.WriteLine($" ¡Correcto! Lo adivinaste en {intentos} intentos.");
                            adivinado = true;
                            puntuaciones.Add(intentos);
                        }
                        else
                        {
                            string pista;
                            if (diferencia <= 5)
                                pista = " Muy cerca:)";
                            else if (diferencia <= 15)
                                pista = intento > numeroSecreto ? "Alto:(" : "Bajo:(";
                            else
                                pista = intento > numeroSecreto ? "Muy alto:(" : "Muy bajo:(";

                            Console.WriteLine(pista);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida, escribe un número.");
                    }
                }

                // Jugar otra vez
                Console.Write("\n¿Quieres jugar otra partida? (s/n): ");
                seguirJugando = Console.ReadLine()?.ToLower() == "s";
            }

            // Estadísticas finales
            if (puntuaciones.Any())
            {
                Console.WriteLine("\n Estadísticas Generales ");
                Console.WriteLine($"Partidas jugadas: {puntuaciones.Count}");
                Console.WriteLine($"Mejor puntuación (mínimo intentos): {puntuaciones.Min()}");
                Console.WriteLine($"Promedio de intentos: {puntuaciones.Average():F2}");
                Console.WriteLine("Puntuaciones ordenadas: " + string.Join(", ", puntuaciones.OrderBy(p => p)));
            }

            Console.WriteLine("\nVuelve pronto");
        }
    }
}
/*
1.  ¿Qué son las enumeraciones en C# y cuándo usarlas?
Una enumeración (enum) es un tipo de dato definido por el usuario que representa un conjunto de constantes
con nombre, normalmente valores enteros. Se usan cuando un valor puede estar dentro de un conjunto limitado y bien definido,
lo que mejora la legibilidad y reduce errores.
Ejemplo: como en mi caso en el juego de adivinar el número que lo use para los niveles de dificultad (Fácil, Medio, Difícil).
2.	¿Cuál es la diferencia entre switch statement tradicional y switch expression?
1. Switch Statement (El normal)
¿Cómo es? Es más largo, usa case, break, y a veces default. Cada "vía" puede tener muchas instrucciones.
¿Cuándo usarlo? Cuando para cada caso necesitas hacer varias líneas de código (como cálculos, llamar métodos, etc.).
2. Switch Expression (El nuevo)
¿Cómo es? Es mucho más compacto y directo. Cada "vía" devuelve un valor directamente. Se usa con => y no necesita break.
¿Cuándo usarlo? Es perfecto cuando lo único que quieres es asignar un valor o devolver un resultado basado en una condición.
Es ideal para inicializar variables.
En mi caso tuve que usar el switch Statement ya que el Expression requiere de C# 8.0 por que en esta versión fue introducido y yo tengo C# 7.3.
*/