/* 
Hola estudiantes quiero que hagamos un resumen de lo aprendido, es decir realizar un pequeño programa que haga el 
cobro de pasaje de una ruta de bus. Los valores tanto como ruta, precios, distancias y demás datos que entienda 
relevantes serán dados por ustedes.
*/ 

/* Resultado Ejemplo:

Auto Bus Plantinum 5 Pasajeros Ventas 5,000 quedan 17 asientos disponibles
Auto Bus Gold 3 Pasajeros Ventas 4,000 quedan 12 asientos disponibles

*/

class Program
{
    public static void Main(string[] args)
    {
        int totalCantidadPasajeros = 0;
        int totalGanancias = 0;
        bool addPasajero = true;

        while (addPasajero)
        {
            Bus bus = new Bus();
            totalCantidadPasajeros += bus.CantidadPasajeros;
            totalGanancias += bus.Ganancias;

            Console.WriteLine("¿Desea añadir a otro pasajero? (Sí/No)");
            string? answer = Console.ReadLine()?.ToLower();

            addPasajero = answer == "s" || answer == "si" || answer == "y" || answer == "yes";
        }

        Informe informe = new Informe(totalCantidadPasajeros, totalGanancias);
        informe.MostrarInforme();
    }
}

public class Bus
{
    public int Ganancias = 0;
    public int CantidadPasajeros = 0;

    public Bus()
    {
        Console.WriteLine("Ingrese el número del pasajero: ");
        int pasajero = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Ingrese el nivel de suscripción del pasajero:\nPlatinum\nGold\nBasica");
        string? subs = Console.ReadLine().ToLower();

        int rutatomada;
        switch (subs)
        {
            case "platinum":
                Console.WriteLine("El pasajero tiene una suscripción Platinum");

                Console.WriteLine("Ingrese la ruta tomada: \n1 - Ruta 1\n2 - Ruta 2\n3 - Ruta 3");
                rutatomada = int.Parse(Console.ReadLine() ?? "0");
                CalculoCosto(rutatomada, subs, pasajero);

                break;
            case "gold":
                Console.WriteLine("El pasajero tiene una suscripción Gold");

                Console.WriteLine("Ingrese la ruta tomada: \n1 - Ruta 1\n2 - Ruta 2\n3 - Ruta 3");
                rutatomada = int.Parse(Console.ReadLine() ?? "0");
                CalculoCosto(rutatomada, subs, pasajero);

                break;
            case "basica":
                Console.WriteLine("El pasajero tiene una suscripción Básica");

                Console.WriteLine("Ingrese la ruta tomada: \n1 - Ruta 1\n2 - Ruta 2\n3 - Ruta 3");
                rutatomada = int.Parse(Console.ReadLine() ?? "0");
                CalculoCosto(rutatomada, subs, pasajero);

                break;
            default:
                Console.WriteLine("Opción no válida, ingrese una subscripción válida");
                break;
        }
    }

    public void CalculoCosto(int rutatomada, string subs, int pasajero)
    {
        int calculoCosto = 0;
        /* Las rutas tendrán precios fijos en pesos

         Ruta 1 = 100
         Ruta 2 = 150
         Ruta 3 = 200 
         
         El nivel de suscripción cambiará la tarifa
         Platinum = x2
         Gold = x1.5
         Básica = x1
         */

        switch (subs)
        {
            case "platinum":
                if (rutatomada == 1)
                    calculoCosto = 100 * 2;
                else if (rutatomada == 2)
                    calculoCosto = 150 * 2;
                else
                    calculoCosto = 200 * 2;

                Console.WriteLine($"El costo a pagar por el pasajero {pasajero} es de {calculoCosto} pesos");
                Ganancias += calculoCosto;
                CantidadPasajeros += 1;
                break;

            case "gold":
                if (rutatomada == 1)
                    calculoCosto = (int)(100 * 1.5);
                else if (rutatomada == 2)
                    calculoCosto = (int)(150 * 1.5);
                else
                    calculoCosto = (int)(200 * 1.5);

                Console.WriteLine($"El costo a pagar por el pasajero {pasajero} es de {calculoCosto} pesos");
                Ganancias += calculoCosto;
                CantidadPasajeros += 1;
                break;
                
            case "basica":
                if (rutatomada == 1)
                    calculoCosto = 100;
                else if (rutatomada == 2)
                    calculoCosto = 150;
                else
                    calculoCosto = 200;

                Console.WriteLine($"El costo a pagar por el pasajero {pasajero} es de {calculoCosto} pesos");
                Ganancias += calculoCosto;
                CantidadPasajeros += 1;
                break;
        }
    }
}

public class Informe
{
    private int CantidadPasajeros;
    private int Ganancias;

    public Informe(int CantidadPasajeros, int Ganancias)
    {
        this.CantidadPasajeros = CantidadPasajeros;
        this.Ganancias = Ganancias;
    }

    public void MostrarInforme()
    {
        Console.WriteLine($"Cantidad total de pasajeros: {CantidadPasajeros}");
        Console.WriteLine($"Ganancias totales: {Ganancias}");
    }
}
