using System;

class Program
{
    static void Main()
    {
        int menuOption;
        char userInput = ' ';

        do
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Iniciar juego");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out menuOption))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (menuOption)
            {
                case 1:
                    Jugar();
                    break;
                case 2:
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.Write("¿Desea continuar? (s/n): ");
            userInput = Console.ReadKey().KeyChar;
            Console.WriteLine();

        } while (char.ToLower(userInput) != 'n');
    }

    static void Jugar()
    {
        int sumaCartas = 0;
        int carta = Random.Shared.Next(1, 11);
        sumaCartas += carta;
        Console.WriteLine($"Carta inicial: {carta}");

        while (sumaCartas < 21)
        {
            Console.WriteLine("Presiona Enter para pedir otra carta o cualquier otra tecla para detenerte...");
            var key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
                break;

            carta = Random.Shared.Next(1, 11);
            sumaCartas += carta;
            Console.WriteLine($"Has sacado {carta}. Suma de cartas: {sumaCartas}");

            if (sumaCartas == 21)
            {
                Console.WriteLine("¡Has ganado!");
                break;
            }
            else if (sumaCartas > 21)
            {
                Console.WriteLine("¡Te has pasado! Has perdido.");
                break;
            }
        }
    }
}
