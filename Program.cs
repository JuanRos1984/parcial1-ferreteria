using System.Globalization;
using Ferreteria;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

if (args.Contains("pruebas"))
    return Pruebas.Ejecutar();

var compra = new List<Linea> { new("Cemento gris 42.5 kg", 2, 650m), new("Varilla 3/8", 1, 340m) };
Console.WriteLine(Reporte.Resumen(compra));
return 0;
