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
            ("Sin descuento bajo RD$ 4000", Precios.Descuento(3999m) == 0m),
            ("Descuento desde RD$ 4000", Precios.Descuento(4000m) == 320m),
            ("Envío de 300 por debajo de 10000", Precios.CargoEnvio(100m) == 300m),
            ("Envío gratis desde 10000", Precios.CargoEnvio(10000m) == 0m),
            ("El resumen muestra el cargo correcto", Reporte.ResumenConEnvio(Compra).Contains("Envío: 300.00")),
            ("El resumen muestra envío gratis desde 10000", Reporte.ResumenConEnvio(new List<Linea> { new("Compra grande", 1, 10000m) }).Contains("Envío: 0.00")),
            ("Se rechaza cantidad cero", CantidadInvalida(0)),
            ("Se rechaza cantidad negativa", CantidadInvalida(-1)),
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

    private static bool CantidadInvalida(int cantidad)
    {
        try
        {
            _ = new Linea("Producto", cantidad, 1m);
            return false;
        }
        catch (ArgumentException)
        {
            return true;
        }
    }
}
