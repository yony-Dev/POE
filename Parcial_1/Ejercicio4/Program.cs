using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un texto:");
            string texto = Console.ReadLine();

            // Normalizamos para analisis
            string textoSinPuntuacion = Regex.Replace(texto, @"[^\w\s]", ""); // quitar signos de puntuación

            // Total de caracteres con y sin espacios
            int totalCaracteresConEspacios = texto.Length;
            int totalCaracteresSinEspacios = texto.Replace(" ", "").Length;

            // Número total de plabras
            string[] palabras = textoSinPuntuacion
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int totalPalabras = palabras.Length;

            // Número de oraciones 
            int totalOraciones = Regex.Split(texto, @"[.!?]").Where(s => !string.IsNullOrWhiteSpace(s)).Count();

            // Palabra más larga y más corta
            string palabraMasLarga = palabras.OrderByDescending(p => p.Length).FirstOrDefault();
            string palabraMasCorta = palabras.OrderBy(p => p.Length).FirstOrDefault();

            // Frecuencia de vocales
            var vocales = "aeiou";
            var frecuenciaVocales = vocales.ToDictionary(
                v => v,
                v => texto.ToLower().Count(c => c == v)
            );

            // Conteo de palabras que comienzan con cada letra
            var conteoPorLetra = palabras
                .GroupBy(p => char.ToLower(p[0]))
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            //  RESULTADOS 
            Console.WriteLine("\n ESTADÍSTICAS DEL TEXTO ");
            Console.WriteLine($"Total Caracteres con espacios: {totalCaracteresConEspacios}");
            Console.WriteLine($"Total Caracteres sin espacios: {totalCaracteresSinEspacios}");
            Console.WriteLine($"Número de palabras: {totalPalabras}");
            Console.WriteLine($"Número de oraciones: {totalOraciones}");
            Console.WriteLine($"Palabra más larga: {palabraMasLarga}");
            Console.WriteLine($"Palabra más corta: {palabraMasCorta}");

            Console.WriteLine("\nFrecuencia de vocales:");
            foreach (var frecuencia in frecuenciaVocales)
                Console.WriteLine($"{frecuencia.Key}: {frecuencia.Value}");

            Console.WriteLine("\nConteo de palabras por letra inicial:");
            foreach (var frecuencia in conteoPorLetra)
                Console.WriteLine($"{frecuencia.Key}: {frecuencia.Value}");
        }
    }
}

//1.  ¿Cuál es la diferencia entre tipos por valor y tipos por referencia?
//•	Tipos por valor (como int, bool o los struct): Son como una fotocopia. Cuando los copias (por ejemplo, int a = b;), obtienes una copia nueva e independiente del valor original. Si cambias la copia, el original no se afecta. Estos se guardan directamente en la "memoria rápida" (stack).
//•	Tipos por referencia (como class, string o los array): Son como un archivo compartido en la nube (Google Drive, Dropbox). La variable no guarda el archivo en sí, sino un enlace o URL a él. Cuando copias la variable (MiClase obj2 = obj1;), solo copias el enlace, no el archivo. Así, ambos enlaces apuntan al mismo archivo. Si alguien lo modifica usando su enlace, el otro también verá los cambios porque es el mismo objeto. El "archivo" real vive en una "memoria grande" (heap).
//2.	¿Por qué usar decimal para precios en lugar de double?
//El double es muy rápido, pero a veces tiene pequeños errores de redondeo porque trabaja en base 2 (binario), igual que la calculadora de tu computadora. Esto puede hacer que una simple operación como 0.1 + 0.2 no dé exactamente 0.3, lo que es un problema enorme para el dinero.
//El decimal es más lento, pero es preciso para cálculos decimales (base 10), como los que hacemos los humanos con dinero. No tiene esos errores de redondeo, por lo que es la opción correcta para precios, salarios, impuestos, etc., donde cada centavo debe contar exactamente.
//3.	¿Qué sucede en memoria cuando se crea un array de 1000 elementos?
//Cuando creas un array tan grande, sucede esto:
//1)	Primero, el programa busca un espacio libre y contiguo (seguido) en la "memoria grande" (heap) para guardar los 1000 elementos juntos.
//2)	Luego, llena todas esas 1000 posiciones con el valor por defecto (ceros si es de números, false si es de booleanos, null o "vacío" si es de objetos).
//3)	Finalmente, en tu variable local (que está en la "memoria rápida" o stack) no se guardan los 1000 elementos, sino solo una dirección o "mapa" que le indica al programa dónde encontrarlos en la memoria grande.
//4.	¿Cuándo se libera la memoria ocupada por las variables locales?
//1)	Para variables locales normales (números, booleanos, structs): La memoria se libera al instante y automáticamente cuando el método termina de ejecutarse. Es como si se borraran solas.
//2)	Para objetos y arrays (los que están en el heap): Aquí es diferente. Cuando el método termina, solo se borra la variable que tenía la "dirección" o enlace (la referencia). El objeto en sí permanece en la memoria grande hasta que el "recolector de basura" (Garbage Collector) del programa pase y se dé cuenta de que ese objeto ya no tiene ningún enlace que apunte a él. En ese momento, lo borra para liberar espacio. Esto no es inmediato, pasa de vez en cuando.
