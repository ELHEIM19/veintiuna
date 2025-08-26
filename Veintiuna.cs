using System;

class Veintiuna
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
        string[] nombresCartas = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        int indice = Random.Shared.Next(0, 13);
        int valor = ObtenerValorCarta(indice);
        sumaCartas += valor;
        Console.WriteLine($"Carta inicial: {nombresCartas[indice]} (valor: {valor})");

        while (sumaCartas < 21)
        {
            Console.WriteLine("Presiona Enter para pedir otra carta o cualquier otra tecla para detenerte...");
            var key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
                break;

            indice = Random.Shared.Next(0, 13);
            valor = ObtenerValorCarta(indice);
            sumaCartas += valor;
            Console.WriteLine($"Has sacado {nombresCartas[indice]} (valor: {valor}). Suma de cartas: {sumaCartas}");

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

    static int ObtenerValorCarta(int indice)
    {
        // A = 0, 2-10 = 1-9, J/Q/K = 10-12
        if (indice == 0)
        {
            Console.Write("Has sacado un As. ¿Qué valor quieres darle? (1/11): ");
            string? input = Console.ReadLine();
            if (input != null && input.Trim() == "11") return 11;
            return 1;
        }
        else if (indice >= 10) // J, Q, K
        {
            return 10;
        }
        else // 2-10
        {
            return indice + 1;
        }
    }
}
