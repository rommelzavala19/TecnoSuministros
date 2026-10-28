using System.Reflection.PortableExecutable;
using System.Globalization;

//Inicializacion de los productos y sus datos
string[] codigo = { "P105", "P101", "P108", "P103", "P110", "P102", "P107", "P104", "P109", "P106" };
string[] nombre = { "Teclado Mecanico RGB", "Mouse Optico USB", "Monitor Gamer 24", "Memoria RAM 16GB DDR4", "Disco SSD 1TB", "Laptop Intel Core i7", "Impresora HP", "Headset Gamer 7.1", "Webcam Full HD", "Router Wi-Fi Dual Band" };
string[] categoria = { "Perifericos", "Perifericos", "Pantallas", "Componentes", "Almacenamiento", "Computadoras", "Impresion", "Audio", "Video", "Redes" };
int[] precioUnitario = { 35, 15, 180, 45, 85, 750, 120, 50, 40, 60 };
int[] existencias = { 25, 50, 12, 30, 20, 8, 15, 40, 18, 22 };

//Inicializacion de las ventas y sus datos
int[] numeroFactura = { 1004, 1001, 1007, 1002, 1005, 1008, 1003, 1006 };
string[] codigoProducto = { "P101", "P105", "P102", "P108", "P103", "P101", "P104", "P110" };
int[] cantidadVendida = { 2, 1, 1, 3, 2, 5, 1, 2 };
DateTime[] fechaVenta = { new DateTime(2026, 10, 24), new DateTime(2026, 10, 20), new DateTime(2026, 10, 22), new DateTime(2026, 10, 21), new DateTime(2026, 10, 24), new DateTime(2026, 10, 20), new DateTime(2026, 10, 23), new DateTime(2026, 10, 22) };

string opcion;

do
{
    MostrarMenu();

    opcion = (Console.ReadLine() ?? string.Empty).Trim();

    switch (opcion)
    {
        case "1":
            MostrarInventario();
            break;
        case "2":
            string codigoBuscado = PedirDatos("Ingrese el código del producto a buscar: ");
            BuscarProductoLineal(codigoBuscado);
            break;
        case "3":
            string codigoBuscadoBinaria = PedirDatos("Ingrese el código del producto a buscar: ");
            BuscarProductoBinaria(codigoBuscadoBinaria);
            break;
        case "4":
            string facturaBuscada = PedirDatos("Ingrese el número de factura a buscar: ");
            BuscarFacturaLineal(facturaBuscada);
            break;
        case "5":
            string facturaBuscadaBinaria = PedirDatos("Ingrese el número de factura a buscar: ");
            BuscarFacturaBinaria(facturaBuscadaBinaria);
            break;
        case "6":
            DateTime fechaBuscada = PedirFecha("Ingrese la fecha de venta a buscar (dd/mm/yyyy): ");
            ConsultarVentasPorFecha(fechaBuscada);
            break;
        case "7":
            CompararEficienciaBusquedas();
            break;
        case "8":
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.\n");
            break;
    }

} while (opcion != "8");


void MostrarMenu()
{
    Console.WriteLine("========== TECNO SUMINISTROS ==========");
    Console.WriteLine("1. Mostrar inventario");
    Console.WriteLine("2. Buscar producto por código (lineal)");
    Console.WriteLine("3. Buscar producto por código (binaria)");
    Console.WriteLine("4. Buscar factura (lineal)");
    Console.WriteLine("5. Buscar factura (binaria)");
    Console.WriteLine("6. Consultar ventas por fecha");
    Console.WriteLine("7. Comparar eficiencia de búsquedas");
    Console.WriteLine("8. Salir");
    Console.WriteLine("=======================================");
    Console.Write("Seleccione una opción: ");
}
void MostrarInventario()
{
    const int MAX_PRODUCTOS = 10;
    const int ANCHO_CODIGO = 10;
    const int ANCHO_NOMBRE = 26;
    const int ANCHO_CATEGORIA = 18;
    const int ANCHO_PRECIO = 18;
    const int ANCHO_EXISTENCIAS = 14;

    int anchoTotal = ANCHO_CODIGO + ANCHO_NOMBRE + ANCHO_CATEGORIA + ANCHO_PRECIO + ANCHO_EXISTENCIAS;
    string linea = new string('=', anchoTotal);

    Console.WriteLine("\n========== INVENTARIO DE PRODUCTOS ==========");
    Console.WriteLine(linea);
    Console.WriteLine($"{"Código",-ANCHO_CODIGO}{"Nombre",-ANCHO_NOMBRE}{"Categoría",-ANCHO_CATEGORIA}{"Precio Unit. ($)",-ANCHO_PRECIO}{"Existencias",-ANCHO_EXISTENCIAS}");
    Console.WriteLine(linea);

    for (int i = 0; i < MAX_PRODUCTOS; i++)
    {
        Console.WriteLine($"{codigo[i],-ANCHO_CODIGO}{nombre[i],-ANCHO_NOMBRE}{categoria[i],-ANCHO_CATEGORIA}{precioUnitario[i],-ANCHO_PRECIO}{existencias[i],-ANCHO_EXISTENCIAS}");
    }

    Console.WriteLine(linea + "\n");
}

void BuscarProductoLineal(string codigoBuscado)
{
   
}

string PedirDatos(string mensaje)
{
    while (true) 
    {
        Console.Write(mensaje);
        string entrada = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

        if (!string.IsNullOrWhiteSpace(entrada))
        {
            return entrada;
        }

        Console.WriteLine("Entrada inválida. Intente nuevamente.\n");
    }
}

DateTime PedirFecha(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string entrada = (Console.ReadLine() ?? string.Empty).Trim();

        if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime fecha))
        {
            return fecha;
        }

        Console.WriteLine("Fecha inválida. Intente nuevamente.\n");
    }
}

void BuscarProductoBinaria(string codigoBuscadoBinaria)
{
    throw new NotImplementedException();
}

void BuscarFacturaLineal(string facturaBuscada)
{
    throw new NotImplementedException();
}

void BuscarFacturaBinaria(string FacturaBuscadaBinaria)
{
    throw new NotImplementedException();
}

void ConsultarVentasPorFecha(DateTime fechaBuscada)
{
    throw new NotImplementedException();
}

void CompararEficienciaBusquedas()
{
    throw new NotImplementedException();
}