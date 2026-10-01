namespace Ferreteria;

public static class Precios
{
<<<<<<< HEAD
    public const decimal MontoMinimoDescuento = 4000m;
=======
    public const decimal MontoMinimoDescuento = 2000m;
>>>>>>> 3f33c9f (Baja el monto mínimo de descuento a 2000)

    public const decimal Itbis = 0.18m;

    // Suma cantidad por precio unitario de cada lÃ­nea.
    public static decimal Subtotal(IEnumerable<Linea> lineas) =>
        lineas.Sum(l => l.Cantidad * l.PrecioUnitario);

    public static decimal Impuesto(decimal subtotal) =>
        Math.Round(subtotal * Itbis, 2);

<<<<<<< HEAD
    public static decimal Descuento(decimal subtotal) =>
        subtotal >= MontoMinimoDescuento ? Math.Round(subtotal * 8m / 100m, 2) : 0m;
=======
    public static decimal CargoEnvio(decimal subtotal) =>
        subtotal >= 10000m ? 0m : 300m;
>>>>>>> 4d2c1bd (Agrega cargo de envío)
}
