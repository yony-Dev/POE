using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        // Clase que representa un producto en el inventario
        class Producto
        {
            public string Nombre { get; set; }
            public double Precio { get; set; }
            public int Cantidad { get; set; }

            // Método para mostrar la información del producto
            public override string ToString()
            {
                return $"Nombre: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}";
            }
        }

        static void Main(string[] args)
        {
            bool ejecutando = true;
            int opcionSeleccionada = 0;

            // Diccionario para almacenar los productos (nombre como clave)
            Dictionary<string, Producto> inventario = new Dictionary<string, Producto>();

            while (ejecutando)
            {
                // Menú principal del sistema
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("  INVENTARIO");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("1. Agregar  producto");
                Console.WriteLine("2. Calcular valor total del inventario");
                Console.WriteLine("3. Buscar producto por nombre");
                Console.WriteLine("4. Mostrar todos los productos");
                Console.WriteLine("5. Salir");
                Console.WriteLine("═══════════════════════════════════════");
                Console.Write("Seleccione una opción: ");

                bool entradaValida = int.TryParse(Console.ReadLine(), out opcionSeleccionada);

                if (!entradaValida)
                {
                    Console.WriteLine(" Error: Debe ingresar un número válido");
                    continue;
                }

                switch (opcionSeleccionada)
                {
                    case 1: // Agregar producto
                        Console.Write("Ingrese el nombre del producto: ");
                        string nombreProducto = Console.ReadLine();

                        if (inventario.ContainsKey(nombreProducto))
                        {
                            Console.WriteLine(" Este producto ya existe en el inventario");
                            continue;
                        }

                        Console.Write("Ingrese el precio del producto: ");
                        double precioProducto;
                        bool precioValido = double.TryParse(Console.ReadLine(), out precioProducto);

                        Console.Write("Ingrese la cantidad disponible: ");
                        int cantidadProducto;
                        bool cantidadValida = int.TryParse(Console.ReadLine(), out cantidadProducto);

                        if (!precioValido || precioProducto <= 0)
                        {
                            Console.WriteLine(" Precio inválido. Debe ser un número mayor a 0");
                            continue;
                        }

                        if (!cantidadValida || cantidadProducto < 0)
                        {
                            Console.WriteLine(" Cantidad inválida. Debe ser un número mayor a 0");
                            continue;
                        }

                        // Crear y agregar el nuevo producto
                        Producto nuevoProducto = new Producto
                        {
                            Nombre = nombreProducto,
                            Precio = precioProducto,
                            Cantidad = cantidadProducto
                        };

                        inventario.Add(nombreProducto, nuevoProducto);
                        Console.WriteLine(" Producto agregado correctamente al inventario");
                        break;

                    case 2: // Calcular valor total
                        if (inventario.Count == 0)
                        {
                            Console.WriteLine(" El inventario está vacío");
                            continue;
                        }

                        double valorTotalInventario = 0;
                        foreach (var producto in inventario.Values)
                        {
                            valorTotalInventario += producto.Cantidad * producto.Precio;
                        }

                        Console.WriteLine($" Valor total del inventario: ${valorTotalInventario:F2}");
                        break;

                    case 3: // Buscar producto
                        Console.Write("Ingrese el nombre del producto a buscar: ");
                        string nombreBuscado = Console.ReadLine();

                        bool encontrado = false;
                        foreach (var producto in inventario.Values)
                        {
                            if (producto.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("\n Producto encontrado:");
                                Console.WriteLine($"   Nombre: {producto.Nombre}");
                                Console.WriteLine($"   Precio: ${producto.Precio:F2}");
                                Console.WriteLine($"   Cantidad: {producto.Cantidad} unidades");
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine(" Producto no encontrado en el inventario");
                        }
                        break;

                    case 4: // Mostrar inventario
                        if (inventario.Count == 0)
                        {
                            Console.WriteLine(" No hay productos en el inventario");
                            continue;
                        }

                        Console.WriteLine("\n LISTA COMPLETA DE PRODUCTOS:");
                        Console.WriteLine("──────────────────────────────");
                        foreach (var producto in inventario.Values)
                        {
                            Console.WriteLine($"• {producto.Nombre} - ${producto.Precio:F2} - {producto.Cantidad} unidades");
                        }
                        break;
                    case 5: // Salir
                        Console.WriteLine(" Saliendo del sistema de inventario...");
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine(" Opción no válida. Por favor seleccione 1-6");
                        break;
                }
            }
        }
    }
}
/*
1.¿Qué son las propiedades automáticas en C#?
Las propiedades automáticas son una forma abreviada de declarar propiedades 
sin necesidad de escribir manualmente el campo privado que las respalda.
El compilador genera automáticamente ese campo privado (llamado "backing field"). Por ejemplo, en el código de arriba:
public string Nombre { get; set; }
public double Precio { get; set; }
Nombre, Precio y Cantidad son propiedades automáticas. El compilador crea campos ocultos como _nombre, _precio y _cantidad,
y los métodos get y set para acceder a ellos.

==================================================================
2.¿Cuál es la diferencia entre un campo y una propiedad
Campo: Es una variable declarada directamente en una clase. Ejemplo:
private string _nombre; => Campo privado
Los campos suelen ser privados y almacenan datos internos de la clase.

Propiedad: Es una abstracción que expone un acceso controlado a los campos. Ejemplo:
public string Nombre { get; set; } => Propiedad automática
Las propiedades permiten validar datos, notificar cambios o calcular valores on-the-fly, mientras que los campos solo almacenan valores.

==================================================================
3.¿Qué ventajas tiene usar get y set en las propiedades?
Encapsulación: Ocultas los campos internos (como _precio) y expones solo lo necesario.
Puedes agregar lógica en el set. Por ejemplo, evitar precios negativos.
Cambias la implementación interna(como calcular un valor) sin afectar cómo se usa la propiedad.
Si luego agregas validación, el código que usa la propiedad no se rompe.

==================================================================
4.Explique cómo funciona la propiedad calculada ValorTotal => Precio * Cantidad
Esta es una propiedad de solo lectura que calcula su valor en tiempo real usando el operador => (lambda).
No almacena datos; cada vez que se accede a ella, recalcula el resultado:
public double ValorTotal => Precio * Cantidad;
Ejemplo: Si Precio = 10 y Cantidad = 5, al leer ValorTotal devolverá 50.

una ventaja es que siempre refleja los valores actuales de Precio y Cantidad. Si cambian, el ValorTotal se actualiza automáticamente.

Uso en el código: Podría haberse usado para calcular el valor total del inventario sin necesidad del bucle foreach en el case 2.
*/