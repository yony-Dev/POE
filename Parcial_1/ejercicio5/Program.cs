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
////////////////////////////////////////////////////////////////
//PREGUNTAS FINALES

/*
   1.¿Cuál es la diferencia entre tipos por valor y tipos por referencia?
•	Tipos por valor (como int, bool o los struct): Son como una fotocopia. Cuando los copias (por ejemplo, int a = b;),
obtienes una copia nueva e independiente del valor original. Si cambias la copia, el original no se afecta.
Estos se guardan directamente en la "memoria rápida" (stack).
•	Tipos por referencia (como class, string o los array): Son como un archivo compartido en la nube (Google Drive, Dropbox).
La variable no guarda el archivo en sí, sino un enlace o URL a él.
Cuando copias la variable (MiClase obj2 = obj1;), solo copias el enlace, no el archivo.
Así, ambos enlaces apuntan al mismo archivo. Si alguien lo modifica usando su enlace,
el otro también verá los cambios porque es el mismo objeto. El "archivo" real vive en una "memoria grande" (heap).


   2. ¿Por qué usar decimal para precios en lugar de double?
El double es muy rápido, pero a veces tiene pequeños errores de redondeo porque trabaja en base 2 (binario),
igual que la calculadora de tu computadora. Esto puede hacer que una simple operación como 0.1 + 0.2 no dé exactamente 0.3,
lo que es un problema enorme para el dinero.
El decimal es más lento, pero es preciso para cálculos decimales (base 10),
como los que hacemos los humanos con dinero. No tiene esos errores de redondeo,
por lo que es la opción correcta para precios, salarios, impuestos, etc., donde cada centavo debe contar exactamente.


   3. ¿Qué sucede en memoria cuando se crea un array de 1000 elementos?
Cuando creas un array tan grande, sucede esto:
1)	Primero, el programa busca un espacio libre y contiguo (seguido) en la "memoria grande"
(heap) para guardar los 1000 elementos juntos.
2)	Luego, llena todas esas 1000 posiciones con el valor por defecto
(ceros si es de números, false si es de booleanos, null o "vacío" si es de objetos).
3)	Finalmente, en tu variable local (que está en la "memoria rápida" o stack)
no se guardan los 1000 elementos, sino solo una dirección o "mapa" que le indica al programa dónde encontrarlos en la memoria grande.


    4. ¿Cuándo se libera la memoria ocupada por las variables locales?
1)	Para variables locales normales (números, booleanos, structs): La memoria se libera al instante y automáticamente
cuando el método termina de ejecutarse. Es como si se borraran solas.
2)	Para objetos y arrays (los que están en el heap): Aquí es diferente.
Cuando el método termina, solo se borra la variable que tenía la "dirección" o enlace (la referencia).
El objeto en sí permanece en la memoria grande hasta que el "recolector de basura" (Garbage Collector)
del programa pase y se dé cuenta de que ese objeto ya no tiene ningún enlace que apunte a él. En ese momento,
lo borra para liberar espacio. Esto no es inmediato, pasa de vez en cuando.


   5. ¿Qué significa que un método sea estático?
significa que pertenece a la clase en lugar de a una instancia. Se llama directamente con la clase, sin necesidad de crear un objeto:
Math.Sqrt(25); // Método estático de la clase Math

   6. ¿Cuándo es apropiado usar métodos estáticos vs. métodos de instancia?
Métodos estáticos: Para funcionalidades que no dependen del estado de un objeto (ejemplo enlos  cálculos matemáticos).
Métodos de instancia: Cuando necesitas acceder a campos o propiedades de un objeto específico (ejemplo: producto.CalcularPrecio()).

   7. ¿Por qué Main() debe ser estático?
Porque es el punto de entrada del programa. Se ejecuta antes de que exista cualquier objeto, por lo que debe poder llamarse sin instanciar la clase.

   8. ¿Qué limitaciones tienen los métodos estáticos?

No pueden acceder a campos o métodos de instancia (solo a otros estáticos).
No pueden usar this.
No pueden ser sobrescritos (override).
No pueden implementar interfaces de forma implícita.
Ejemplo:
class Producto {
    public double Precio { get; set; }
    
    // Método de instancia
    public double CalcularIVA() => Precio * 0.21; 
    
    // Método estático
    public sta
 */