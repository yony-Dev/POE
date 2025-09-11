using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arreglos con los nombres de los números
            string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] numerosEspeciales = { "diez", "once", "doce", "trece", "catorce", "quince",
                                           "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
            string[] decenas = { "", "", "veinte", "treinta", "cuarenta", "cincuenta",
                                 "sesenta", "setenta", "ochenta", "noventa" };
            string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos",
                                  "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            int numeroIngresado;

            // Bucle principal del programa
            do
            {
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("   COVERTIR NÚMEROS A PALABRAS");
                Console.WriteLine("═══════════════════════════════════════");
                Console.Write("Ingrese un número (1-999) o 0 para terminar: ");

                string entradaUsuario = Console.ReadLine();

                // Validación de la entrada del usuario
                if (!int.TryParse(entradaUsuario, out numeroIngresado))
                {
                    Console.WriteLine(" Error: Debe ingresar un número válido\n");
                    continue;
                }

                // Salir del programa si se ingresa 0
                if (numeroIngresado == 0)
                {
                    Console.WriteLine(" Programa finalizado. ¡Hasta pronto!");
                    break;
                }

                // Verificar que el número esté en el rango permitido
                if (numeroIngresado < 1 || numeroIngresado > 999)
                {
                    Console.WriteLine("  El número debe estar entre 1 y 999\n");
                    continue;
                }

                // Convertir el número a palabras y mostrar el resultado
                string resultadoEnPalabras = ConvertirNumeroATexto(numeroIngresado, unidades, numerosEspeciales, decenas, centenas);
                Console.WriteLine($"\n {numeroIngresado} = \"{resultadoEnPalabras}\"\n");

            } while (numeroIngresado != 0);

            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Console.ReadKey();
        }

        // Función que convierte un número a palabra
        static string ConvertirNumeroATexto(int numero, string[] unidades, string[] especiales, string[] decenas, string[] centenas)
        {
            // Descomponer el número en centenas, decenas y unidades
            int centena = numero / 100;
            int resto = numero % 100;
            int decena = resto / 10;
            int unidad = resto % 10;

            string textoResultante = "";

            // Caso cuando se ingrese 100
            if (numero == 100)
            {
                return "cien";
            }

            // aqui se procesan las centenas
            if (centena > 0)
            {
                textoResultante += centenas[centena];
                if (resto > 0)
                    textoResultante += " ";
            }

            // aqui se procesan los números especiales (10-19)
            if (resto >= 10 && resto <= 19)
            {
                textoResultante += especiales[resto - 10];
            }
            // aqui se procesan los numeros de (20-29)
            else if (resto >= 20 && resto <= 29)
            {
                if (resto == 20)
                {
                    textoResultante += "veinte";
                }
                else
                {
                    textoResultante += "veinti" + unidades[unidad];
                }
            }
            // aqui se procesan las decenas con unidades (30-99)
            else if (resto >= 30)
            {
                textoResultante += decenas[decena];
                if (unidad > 0)
                    textoResultante += " y " + unidades[unidad];
            }
            // aqui se procesan las unidades simples (1-9)
            else if (resto > 0)
            {
                textoResultante += unidades[unidad];
            }

            return textoResultante.Trim();
        }
    }
}

/*
 ¿Cómo funciona el operador módulo en C#?
Básicamente te da lo que sobra cuando divides un número entre otro.
Como en la escuela: 7 dividido entre 3 son 2 y sobra 1 → pues 7 % 3 = 1

¿Por qué es útil para separar unidades, decenas y centenas? 
Es útil para descomponer números.
Si tienes 157:
157 / 100 = 1 (centena)
157 % 100 = 57 (lo que sobra)
57 / 10 = 5 (decena)
57 % 10 = 7 (unidad)

Así puedes agarrarr cada parte y ponerla en palabras.

Describa el algoritmo usado para convertir 157 a "ciento cincuenta y siete"
Pues vas por partes:
La centena (1) es "ciento"
La decena (5) es "cincuenta"
La unidad (7) es "siete"
Y lo juntas: "ciento cincuenta y siete"

 ¿Qué otros problemas se pueden resolver usando aritmética modular?
para saber si un número es par: numero % 2 == 0
Ver si es múltiplo de 5: numero % 5 == 0
Para relojes: si son las 22 y sumas 5 horas, (22+5)%24 = 3 (las 3 de la mañana)
Para ciclos que se repiten, como un carrusel de imágenes
Es una operación super útil que parece simple pero se usa en muchas cosas importantes.
 */