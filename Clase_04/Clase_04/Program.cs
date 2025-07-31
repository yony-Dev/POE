using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            //    int opcion = 0;
            //    bool continuar = true;

            //    while (continuar)
            //    {
            //        Console.WriteLine("Menú:");
            //        Console.WriteLine("Opción 1: Suma");
            //        Console.WriteLine("Opción 2: Resta");
            //        Console.WriteLine("Opción 3: Salir");
            //        Console.WriteLine("Ingrese una opción:");

            //        bool esValido = int.TryParse(Console.ReadLine(), out opcion);

            //        if (!esValido)
            //        {
            //            Console.WriteLine("Por favor ingrese un número válido.");
            //            continue;
            //        }

            //        if (opcion == 1 || opcion == 2)
            //        {
            //            Console.WriteLine("Ingrese el primer número:");
            //            if (!double.TryParse(Console.ReadLine(), out double numero1))
            //            {
            //                Console.WriteLine("Número inválido. Intente nuevamente.");
            //                continue;
            //            }

            //            Console.WriteLine("Ingrese el segundo número:");
            //            if (!double.TryParse(Console.ReadLine(), out double numero2))
            //            {
            //                Console.WriteLine("Número inválido. Intente nuevamente.");
            //                continue;
            //            }

            //            switch (opcion)
            //            {
            //                case 1:
            //                    Sumar(numero1, numero2);
            //                    break;
            //                case 2:
            //                    Restar(numero1, numero2);
            //                    break;
            //            }
            //        }
            //        else if (opcion == 3)
            //        {
            //            continuar = false;
            //            Console.WriteLine("Programa finalizado.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Opción inválida. Por favor seleccione 1, 2 o 3.");
            //        }
            //    }
            //}

            //static void Sumar(double a, double b)
            //{
            //    double resultado = a + b;
            //    Console.WriteLine($"El resultado de la suma es: {resultado}");
            //}

            //static void Restar(double a, double b)
            //{
            //    double resultado = a - b;
            //    Console.WriteLine($"El resultado de la resta es: {resultado}"); // <<< Error corregido (resultado)

            //Ejercicio 2

            //Console.WriteLine("Ingrese los numeros que quiera sumar");
            //int numeros = Convert.ToInt32(Console.ReadLine());


            //int suma = 0;
            //for (int i = 1; i <= numeros; i++)
            //{
            //    Console.Write($"ingrese el valor {i}: ");

            //    suma += int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine($"Resultado de su suma es: {suma}");


            //Ejercicio 3

            //string usuario = "Bryan123";
            //string contreseña = "1234";
            //int intentos = 3;
            //do{
            //    Console.WriteLine("Ingrese su usuario ");
            //    string usuario2 = Console.ReadLine();

            //    Console.WriteLine("Ingrese su contraseña ");
            //    string contraseña2 = Console.ReadLine();


            //    if (usuario2 == usuario & contraseña2 == contreseña)
            //    {
            //        Console.WriteLine($"bienvenido {usuario}");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("usuario y o contraseña son incorrectos");
            //        intentos--;
            //        Console.WriteLine($"Su numero de intentos disponibles es: {intentos}");
            //    }

            //}while(intentos >0);

            //Ejercicio 4

            //Console.WriteLine("Ingrese el numero de notas que quiere ingresar");
            //double calificaciones = Convert.ToInt32(Console.ReadLine());


            //double promedio = 0;
            //for (int i = 1; i <= calificaciones; i++)
            //{

            //    double nota;
            //    bool notaValida = false;

            //    while (!notaValida)
            //    {
            //        Console.Write($"Ingrese la nota {i} (entre 0 y 10): ");
            //        string CalificacionesIngresadas = Console.ReadLine(); 


            //        if (double.TryParse(CalificacionesIngresadas,out nota))
            //        {

            //            if (nota >= 0 && nota <= 10)
            //            {
            //                promedio += nota; 
            //                notaValida = true; 
            //            }
            //            else
            //            {
            //                Console.WriteLine("error: La nota debe estar entre 0 y 10 Por favor intente de nuevo.");
            //            }
            //        }
            //        else
            //        {

            //            Console.WriteLine("Error: Entrada inválida Por favor ingrese un número.");
            //        }
            //    }


            //}

            //double promedioF = (promedio / calificaciones);

            //if (promedioF >= 1 & promedioF < 6)
            //{
            //    Console.WriteLine("Su rendimiento es bajo");
            //    Console.WriteLine($"Su promedio es: {promedioF}");
            //}else if(promedioF >= 6 & promedioF < 8)
            //{
            //    Console.WriteLine("Su rendimiento es regular");
            //    Console.WriteLine($"Su promedio es: {promedioF}");
            //}
            //else if (promedioF >= 8 & promedioF <= 10)
            //{
            //    Console.WriteLine("Su rendimiento es excelente");
            //    Console.WriteLine($"Su promedio es: {promedioF}");
            //}
            //else
            //{
            //    Console.WriteLine("promedio invalido");
            //}


            //Ejercicio 5

            Console.WriteLine("----Inventario----");
            Console.WriteLine("Nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cantidad del producto: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Precio del producto");
            int precio = Convert.ToInt32(Console.ReadLine());

            DateTime fechaHoraActual = DateTime.Now;
            int TotalPrecio = (cantidad * precio);

            Console.WriteLine($"Nombre: {nombre} \nCantidad-Producto: {cantidad} \nPrecio: {precio}\nSubtotal: {TotalPrecio} \n Fecha_Ingreso: {fechaHoraActual}");


        }
    }
}
