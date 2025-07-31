using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_06
{
    internal class Program
    {
        int opcion;
        static void Main(string[] args)
        {
            //variables 
            int opcion;
            decimal r;
            decimal baseRec, alturaRec;

            bool continuar = true;

            while (continuar)
            {
                {
                    Console.WriteLine("1. Triangulo: ");
                    Console.WriteLine("2. Cuadrado: ");
                    Console.WriteLine("3. Rectanglulo: ");
                    Console.WriteLine("4. Salir: ");
                    //Pedimos una opcion

                    Console.WriteLine("Elige una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                }
                while ((opcion < 1) || (opcion > 4)) ;
                //hacer la operacion según la opción elegida

                switch (opcion)
                {
                    case 1:
                        Triangulo();
                        break;
                    case 2:
                        r = Cuadrado(); //Asinamos el valor devuelto por "Return"
                                        //Mostramos el resultado, con la informacion que contiene "r"
                        Console.WriteLine("El area del cuadado es:{0} cm", r);
                        break;
                    case 3:
                        Console.WriteLine("Introduce la base: ");
                        baseRec = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Introduce la altura: ");
                        alturaRec = Convert.ToDecimal(Console.ReadLine());

                        //Invocamos al metodo
                        Rectangulo(baseRec, alturaRec);
                        break;

                    case 4:
                     continuar = false;
                        break;

                }// Cierre del main 


            }
        }

        static void Triangulo()
        {
            decimal baseTriangulo, alturaTriangulo, resultado;

            Console.WriteLine("Ingrese la base");
            baseTriangulo = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Ingrese la altura");
            alturaTriangulo = Convert.ToDecimal(Console.ReadLine());

            resultado = (baseTriangulo * alturaTriangulo) / 2;

            Console.WriteLine("El área es {0} cm", resultado);
        }

        static decimal Cuadrado()
        {
            //Variables del metodo Restar ()
            decimal longitud, resultado;

            Console.WriteLine("Introduce uno de los lados: ");
            longitud = Convert.ToDecimal(Console.ReadLine());

            //Operacion 
            resultado = longitud * longitud;

            return resultado;
        }

        static void Rectangulo(decimal baseRec, decimal alturaRec)
        {
            //Declaracion de variables
            decimal resultado;

            //Multiplicacion con los valores que mandan los arguementos
            resultado = baseRec * alturaRec;

            //Mostramos el resultado
            Console.WriteLine("Base:{0} * Altura:{1} = Area:{2} cm", baseRec, alturaRec, resultado);
        }
    }
}