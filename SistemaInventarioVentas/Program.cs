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
    int comparaciones = 0;

    for (int i = 0; i < codigo.Length; i++)
    {
        comparaciones++;

        if (codigo[i] == codigoBuscado)
        {
            Console.WriteLine("\nPRODUCTO ENCONTRADO");
            Console.WriteLine($"Codigo: {codigo[i]}");
            Console.WriteLine($"Nombre: {nombre[i]}");
            Console.WriteLine($"Categoria: {categoria[i]}");
            Console.WriteLine($"Precio: ${precioUnitario[i]}");
            Console.WriteLine($"Existencias: {existencias[i]}");
            Console.WriteLine($"Comparaciones realizadas: {comparaciones}");

            return;
        }
    }

    Console.WriteLine("Producto no encontrado");
    Console.WriteLine($"Comparaciones realizadas: {comparaciones}");
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
    OrdenarProductosPorCodigo();

    int izquierda = 0;
    int derecha = codigo.Length - 1;

    int comparaciones = 0;

    while (izquierda <= derecha)
    {
        comparaciones++;

        int medio = (izquierda + derecha) / 2;

        if (codigo[medio] == codigoBuscadoBinaria)
        {
            Console.WriteLine("\nPRODUCTO ENCONTRADO");
            Console.WriteLine($"Código: {codigo[medio]}");
            Console.WriteLine($"Nombre: {nombre[medio]}");
            Console.WriteLine($"Categoría: {categoria[medio]}");
            Console.WriteLine($"Precio: ${precioUnitario[medio]}");
            Console.WriteLine($"Existencias: {existencias[medio]}");
            Console.WriteLine($"Comparaciones realizadas: {comparaciones}");

            return;
        }

        if (string.Compare(codigoBuscadoBinaria, codigo[medio]) > 0)
        {
            izquierda = medio + 1;
        }
        else
        {
            derecha = medio - 1;
        }
    }

    Console.WriteLine("Producto no encontrado");
    Console.WriteLine($"Comparaciones realizadas: {comparaciones}");
}

void OrdenarProductosPorCodigo()
{
    for (int i = 0; i < codigo.Length - 1; i++)
    {
    for (int j = 0; j < codigo.Length - 1 - i; j++)
    {
        if (string.Compare(codigo[j], codigo[j + 1]) > 0)
        {
        string auxCodigo = codigo[j];
        codigo[j] = codigo[j + 1];
        codigo[j + 1] = auxCodigo;

            string auxNombre = nombre[j];
            nombre[j] = nombre[j + 1];
            nombre[j + 1] = auxNombre;

        string auxCategoria = categoria[j];
            categoria[j] = categoria[j + 1];
            categoria[j + 1] = auxCategoria;

            int auxPrecio = precioUnitario[j];
            precioUnitario[j] = precioUnitario[j + 1];
                precioUnitario[j + 1] = auxPrecio;

            int auxExistencias = existencias[j];
            existencias[j] = existencias[j + 1];
                existencias[j + 1] = auxExistencias;
        }
        }
    }
}

bool VentasSonConsistentes()
{
    int total = numeroFactura.Length;

    return total > 0
        && codigoProducto.Length == total
        && cantidadVendida.Length == total
        && fechaVenta.Length == total;
}

bool EsNumeroFacturaValido(string entrada, out int numero)
{
    numero = 0;

    if (string.IsNullOrWhiteSpace(entrada))
    {
        return false;
    }

    if (!int.TryParse(entrada.Trim(), out numero))
    {
        return false;
    }

    return numero > 0;
}

int BuscarIndiceProducto(string codigoProd)
{
    for (int i = 0; i < codigo.Length; i++)
    {
        if (codigo[i] == codigoProd)
        {
            return i;
        }
    }

    return -1;
}

string FormatearFilaVenta(string factura, string fecha, string codProd, string producto, string cantidad, string precio, string total)
{
    const int ANCHO_FACTURA = 9;
    const int ANCHO_FECHA = 12;
    const int ANCHO_CODIGO = 9;
    const int ANCHO_PRODUCTO = 24;
    const int ANCHO_CANTIDAD = 10;
    const int ANCHO_PRECIO = 12;
    const int ANCHO_TOTAL = 10;

    return $"{factura,-ANCHO_FACTURA}{fecha,-ANCHO_FECHA}{codProd,-ANCHO_CODIGO}{producto,-ANCHO_PRODUCTO}{cantidad,-ANCHO_CANTIDAD}{precio,-ANCHO_PRECIO}{total,-ANCHO_TOTAL}";
}

void MostrarEncabezadoVentas()
{
    string encabezado = FormatearFilaVenta("Factura", "Fecha", "Código", "Producto", "Cantidad", "Precio ($)", "Total ($)");
    string linea = new string('=', encabezado.Length);

    Console.WriteLine(linea);
    Console.WriteLine(encabezado);
    Console.WriteLine(linea);
}

void MostrarFilaVenta(int indice)
{
    int indiceProducto = BuscarIndiceProducto(codigoProducto[indice]);

    string nombreProducto = indiceProducto >= 0 ? nombre[indiceProducto] : "Desconocido";
    int precio = indiceProducto >= 0 ? precioUnitario[indiceProducto] : 0;
    int total = precio * cantidadVendida[indice];

    Console.WriteLine(FormatearFilaVenta(
        numeroFactura[indice].ToString(),
        fechaVenta[indice].ToString("dd/MM/yyyy"),
        codigoProducto[indice],
        nombreProducto,
        cantidadVendida[indice].ToString(),
        precio.ToString(),
        total.ToString()));
}

void MostrarVentaEncontrada(int indice, int comparaciones)
{
    Console.WriteLine("\nFACTURA ENCONTRADA");
    MostrarEncabezadoVentas();
    MostrarFilaVenta(indice);
    Console.WriteLine($"Comparaciones realizadas: {comparaciones}\n");
}

void MostrarFacturaNoEncontrada(int comparaciones)
{
    Console.WriteLine("Factura no encontrada");
    Console.WriteLine($"Comparaciones realizadas: {comparaciones}\n");
}

void IntercambiarVentas(int a, int b)
{
    int auxFactura = numeroFactura[a];
    numeroFactura[a] = numeroFactura[b];
    numeroFactura[b] = auxFactura;

    string auxCodigoProducto = codigoProducto[a];
    codigoProducto[a] = codigoProducto[b];
    codigoProducto[b] = auxCodigoProducto;

    int auxCantidad = cantidadVendida[a];
    cantidadVendida[a] = cantidadVendida[b];
    cantidadVendida[b] = auxCantidad;

    DateTime auxFecha = fechaVenta[a];
    fechaVenta[a] = fechaVenta[b];
    fechaVenta[b] = auxFecha;
}

void OrdenarVentasPorFactura()
{
    if (!VentasSonConsistentes())
    {
        return;
    }

    for (int i = 0; i < numeroFactura.Length - 1; i++)
    {
        for (int j = 0; j < numeroFactura.Length - 1 - i; j++)
        {
            if (numeroFactura[j] > numeroFactura[j + 1])
            {
                IntercambiarVentas(j, j + 1);
            }
        }
    }
}

void BuscarFacturaLineal(string facturaBuscada)
{
    if (!VentasSonConsistentes())
    {
        Console.WriteLine("Error: los datos de ventas no son válidos.\n");
        return;
    }

    if (!EsNumeroFacturaValido(facturaBuscada, out int numeroBuscado))
    {
        Console.WriteLine("Número de factura inválido. Debe ser un entero positivo.\n");
        return;
    }

    int comparaciones = 0;

    for (int i = 0; i < numeroFactura.Length; i++)
    {
        comparaciones++;

        if (numeroFactura[i] == numeroBuscado)
        {
            MostrarVentaEncontrada(i, comparaciones);
            return;
        }
    }

    MostrarFacturaNoEncontrada(comparaciones);
}

void BuscarFacturaBinaria(string FacturaBuscadaBinaria)
{
    if (!VentasSonConsistentes())
    {
        Console.WriteLine("Error: los datos de ventas no son válidos.\n");
        return;
    }

    if (!EsNumeroFacturaValido(FacturaBuscadaBinaria, out int numeroBuscado))
    {
        Console.WriteLine("Número de factura inválido. Debe ser un entero positivo.\n");
        return;
    }

    OrdenarVentasPorFactura();

    int izquierda = 0;
    int derecha = numeroFactura.Length - 1;
    int comparaciones = 0;

    while (izquierda <= derecha)
    {
        comparaciones++;

        int medio = (izquierda + derecha) / 2;

        if (numeroFactura[medio] == numeroBuscado)
        {
            MostrarVentaEncontrada(medio, comparaciones);
            return;
        }

        if (numeroBuscado > numeroFactura[medio])
        {
            izquierda = medio + 1;
        }
        else
        {
            derecha = medio - 1;
        }
    }

    MostrarFacturaNoEncontrada(comparaciones);
}

int ContarVentasPorFecha(DateTime fechaBuscada, out int comparaciones)
{
    int coincidencias = 0;
    comparaciones = 0;

    for (int i = 0; i < fechaVenta.Length; i++)
    {
        comparaciones++;

        if (fechaVenta[i].Date == fechaBuscada.Date)
        {
            coincidencias++;
        }
    }

    return coincidencias;
}

int CalcularTotalVenta(int indice)
{
    int indiceProducto = BuscarIndiceProducto(codigoProducto[indice]);

    if (indiceProducto < 0)
    {
        return 0;
    }

    return precioUnitario[indiceProducto] * cantidadVendida[indice];
}

void ConsultarVentasPorFecha(DateTime fechaBuscada)
{
    if (!VentasSonConsistentes())
    {
        Console.WriteLine("Error: los datos de ventas no son válidos.\n");
        return;
    }

    int coincidencias = ContarVentasPorFecha(fechaBuscada, out int comparaciones);

    if (coincidencias == 0)
    {
        Console.WriteLine($"\nNo se encontraron ventas el {fechaBuscada:dd/MM/yyyy}");
        Console.WriteLine($"Comparaciones realizadas: {comparaciones}\n");
        return;
    }

    Console.WriteLine($"\nVENTAS DEL {fechaBuscada:dd/MM/yyyy}");
    MostrarEncabezadoVentas();

    int totalDelDia = 0;

    for (int i = 0; i < fechaVenta.Length; i++)
    {
        if (fechaVenta[i].Date == fechaBuscada.Date)
        {
            MostrarFilaVenta(i);
            totalDelDia += CalcularTotalVenta(i);
        }
    }

    Console.WriteLine($"\nVentas encontradas: {coincidencias}");
    Console.WriteLine($"Total vendido en el día: ${totalDelDia}");
    Console.WriteLine($"Comparaciones realizadas: {comparaciones}\n");
}

void CompararEficienciaBusquedas()
{
    throw new NotImplementedException();
}