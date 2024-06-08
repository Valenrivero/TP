using System; 
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        Tienda miTienda = new Tienda();

        //productos de ejemplo
        miTienda.AgregarProducto(new Producto("jugos", 10.0m, 20));
        miTienda.AgregarProducto(new Producto("oreos", 30.0m, 15));
        miTienda.AgregarProducto(new Producto("yerba", 25.0m, 10));

        while (true)
        {
            Console.WriteLine("===Menú===");
            Console.WriteLine("1. Ingresar como vendedor");
            Console.WriteLine("2. ingresar como comprador");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    MenuVendedor(miTienda);
                    break;
                case 2:
                    MenuComprador(miTienda);
                    break;
                case 3:
                    Console.WriteLine("Adios");
                    return;
                
                default:
                    Console.WriteLine("Opcion inválida. Intente nuevamente.");
                    break;


            }
        }
    }

    static void MenuVendedor(Tienda tienda)
    {
        Console.WriteLine("=== Menú Vendedor ===");
        Console.WriteLine("1. Agregar producto"); //
        Console.WriteLine("2. Cambiar precio de un producto"); //
        Console.WriteLine("3. Modificar stock de un producto"); //
        Console.WriteLine("4. Volver al menú principal");
        Console.WriteLine("Seleccione una opción: ");

        
        int opcion = int.Parse(Console.ReadLine());
        int primera_vez = 0;

        while(opcion != 4)
        {
            if (primera_vez == 1)
            {
                Console.WriteLine("=== Opciones ===");
                Console.WriteLine("1. Agregar producto"); //
                Console.WriteLine("2. Cambiar precio de un producto"); //
                Console.WriteLine("3. Modificar stock de un producto"); //
                Console.WriteLine("4. Volver al menú principal");
                Console.WriteLine("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("1. Agregar producto");
                    Console.WriteLine("Ingrese un nombre");
                    string nombre = Console.ReadLine();
                    while (nombre == null)
                    {
                        Console.WriteLine("Debe ingresar un nombre");
                        nombre = Console.ReadLine();
                    }
                    Console.WriteLine("Ingrese el costo del producto");
                    decimal costo = decimal.Parse(Console.ReadLine());
                    while (costo <= 0)
                    {
                        Console.WriteLine("El costo debe ser mayor a cero");
                        costo = decimal.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Ingrese el stock del producto");
                    int stock = int.Parse(Console.ReadLine());
                    while (stock < 0)
                    {
                        Console.WriteLine("El stock debe ser mayor o igual a cero");
                        stock = int.Parse(Console.ReadLine());
                    }

                    Producto nuevo_producto = new Producto(nombre, costo, stock);

                    tienda.AgregarProducto(nuevo_producto);
                    break;
                case 2:
                    Console.WriteLine("Ingrese el nombre del producto");
                    string nombre2 = Console.ReadLine();
                    while (nombre2 == null)
                    {
                        Console.WriteLine("Debe ingresar un nombre");
                        nombre2 = Console.ReadLine();
                    }
                    Console.WriteLine("Ingrese el costo del producto");
                    decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
                    while (nuevoPrecio <= 0)
                    {
                        Console.WriteLine("El costo debe ser mayor a cero");
                        nuevoPrecio = decimal.Parse(Console.ReadLine());
                    }
                    tienda.ModificarPrecioProducto(nombre2, nuevoPrecio);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el nombre del producto");
                    string nombre3 = Console.ReadLine();
                    while (nombre3 == null)
                    {
                        Console.WriteLine("Debe ingresar un nombre");
                        nombre3 = Console.ReadLine();
                    }
                    Console.WriteLine("Ingrese el stock del producto");
                    int stock3 = int.Parse(Console.ReadLine());
                    while (stock3 < 0)
                    {
                        Console.WriteLine("El stock debe ser mayor o igual a cero");
                        stock3 = int.Parse(Console.ReadLine());
                    }
                    tienda.ModificarStockProducto(nombre3, stock3);
                    break;
                case 4:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
            primera_vez = 1;
        }

        
        
    }

    static void MenuComprador (Tienda tienda)
    {
        Carrito carrito = new Carrito();

        Console.WriteLine("=== Menú Comprador ===");
        Console.WriteLine("1. Mostrar productos disponibles");
        Console.WriteLine("2. Agregar producto al carrito");
        Console.WriteLine("3. Eliminar producto del carrito"); 
        Console.WriteLine("4. Pagar"); 
        Console.WriteLine("5. Salir"); 
        Console.Write("Seleccione una opción: ");

        int opcion = int.Parse(Console.ReadLine());
        int primera_vez = 0;
        while (opcion != 5)
        {
            if (primera_vez == 1)
            {
                Console.WriteLine("=== Opciones ===");
                Console.WriteLine("1. Mostrar productos disponibles"); 
                Console.WriteLine("2. Agregar producto al carrito"); 
                Console.WriteLine("3. Eliminar producto del carrito"); 
                Console.WriteLine("4. Pagar"); 
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());
            }
            switch (opcion)
            {
                case 1:
                    tienda.MostrarProducto();
                    break;
                case 2:
                    Console.WriteLine("Ingrese el nombre del producto");
                    string entrada = Console.ReadLine();
                    while (entrada == null)
                    {
                        Console.WriteLine("Debe ingresar el nombre del producto");
                        entrada = Console.ReadLine();
                    }
                    Console.WriteLine("Especifique la cantidad del producto");
                    int cantidad = int.Parse(Console.ReadLine());
                    while (cantidad <= 0)
                    {
                        Console.WriteLine("Debe especificar una cantidad del producto mayor a cero");
                        cantidad = int.Parse(Console.ReadLine());
                    }
                    carrito.AgregarProducto(tienda.ObtenerListaProductosEnTienda(), entrada, cantidad);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el nombre del producto");
                    string entrada3 = Console.ReadLine();
                    while (entrada3 == null)
                    {
                        Console.WriteLine("Debe ingresar el nombre del producto");
                        entrada3 = Console.ReadLine();
                    }
                    carrito.EliminarProducto(tienda.ObtenerListaProductosEnTienda(), entrada3);
                    break;
                case 4:
                    Console.WriteLine($"Subtotal del carrito: {carrito.CalcularSubtotal():C}");
                    Console.WriteLine("Ingrese el monto con el que piensa pagar");
                    decimal montoPago = decimal.Parse(Console.ReadLine());
                    int comparacion = Decimal.Compare(montoPago, carrito.CalcularSubtotal());
                    while (comparacion < 0)
                    {
                        Console.WriteLine("Debe pagar con un monto igual o mayor al precio de la compra");
                        cantidad = int.Parse(Console.ReadLine());
                        comparacion = Decimal.Compare(montoPago, carrito.CalcularSubtotal());
                    }
                    tienda.Cobrar(montoPago, carrito.CalcularSubtotal());
                    break;
                case 5:
                    Console.WriteLine("Adios");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente. ");
                    break;
            }

            primera_vez = 1;
        }
    }
}

