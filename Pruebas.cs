namespace Ferreteria;

public static class Pruebas
{
    private static readonly List<Linea> Compra = new()
    {
        new("Cemento gris 42.5 kg", 2, 650m),
        new("Varilla 3/8", 1, 340m),
    };

    public static int Ejecutar()
    {
        var casos = new List<(string Nombre, bool Paso)>
        {
            ("El subtotal suma cantidad por precio", Precios.Subtotal(Compra) == 1640m),
            ("El ITBIS es el 18 % del subtotal", Precios.Impuesto(100m) == 18m),
            ("El resumen muestra el total", Reporte.Resumen(Compra).Contains("Total")),
            ("Descuento del 8 % en compras grandes", Precios.Descuento(20000m) == 1600m),
            ("Sin descuento en compras pequeÃ±as", Precios.Descuento(100m) == 0m),
        };

        int fallas = 0;
        foreach (var (nombre, paso) in casos)
        {
            Console.WriteLine($"{(paso ? "OK   " : "FALLA")} {nombre}");
            if (!paso) fallas++;
        }
        Console.WriteLine(fallas == 0 ? "Todas las pruebas pasan." : $"{fallas} prueba(s) fallan.");
        return fallas == 0 ? 0 : 1;
    }
}
