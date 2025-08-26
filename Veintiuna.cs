
using System;
using Humanizer;
using Colorful;
using System.Drawing;
using Spectre.Console;

class Veintiuna
{
    static void Main()
    {
        char userInput = ' ';

        do
        {
            var option = Spectre.Console.AnsiConsole.Prompt(
                new Spectre.Console.SelectionPrompt<string>()
                    .Title("[bold yellow]Veintiuna[/] - Elige una opción:")
                    .PageSize(3)
                    .AddChoices(new[] { "Iniciar juego", "Salir" })
            );

            if (option == "Iniciar juego")
            {
                Jugar();
            }
            else if (option == "Salir")
            {
                Spectre.Console.AnsiConsole.MarkupLine("[blue]Saliendo...[/]");
                return;
            }

            Spectre.Console.AnsiConsole.MarkupLine("¿Desea continuar? ([green]s[/]/[red]n[/]): ");
            userInput = System.Console.ReadKey().KeyChar;
            System.Console.WriteLine();

        } while (char.ToLower(userInput) != 'n');
    }

    static void Jugar()
    {
        int sumaCartas = 0;
        string[] nombresCartas = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        int indice = Random.Shared.Next(0, 13);
        int valor = ObtenerValorCarta(indice);
        sumaCartas += valor;
        Spectre.Console.AnsiConsole.Write(
            new Spectre.Console.Panel($"Carta inicial: {nombresCartas[indice]} (valor: {valor} - {valor.ToWords()})")
                .Border(Spectre.Console.BoxBorder.Rounded)
                .BorderColor(Spectre.Console.Color.Blue)
                .Padding(1,1)
        );

        while (sumaCartas < 21)
        {
            var action = Spectre.Console.AnsiConsole.Prompt(
                new Spectre.Console.SelectionPrompt<string>()
                    .Title("¿Qué deseas hacer?")
                    .PageSize(3)
                    .AddChoices(new[] { "Pedir carta", "Detenerse" })
            );

            if (action == "Detenerse")
                break;

            indice = Random.Shared.Next(0, 13);
            valor = ObtenerValorCarta(indice);
            sumaCartas += valor;
            Spectre.Console.AnsiConsole.Write(
                new Spectre.Console.Panel($"Has sacado {nombresCartas[indice]} (valor: {valor} - {valor.ToWords()})\nSuma de cartas: {sumaCartas} ({sumaCartas.ToWords()})")
                    .Border(Spectre.Console.BoxBorder.Rounded)
                    .BorderColor(Spectre.Console.Color.Yellow)
                    .Padding(1,1)
            );

            if (sumaCartas == 21)
            {
                Spectre.Console.AnsiConsole.Write(
                    new Spectre.Console.Panel($"¡Has ganado con {sumaCartas} ({sumaCartas.ToWords()}) puntos!")
                        .Header("[bold green]¡Victoria![/]")
                        .Border(Spectre.Console.BoxBorder.Rounded)
                        .Padding(1,1)
                        .BorderColor(Spectre.Console.Color.Green)
                );
                break;
            }
            else if (sumaCartas > 21)
            {
                Spectre.Console.AnsiConsole.Write(
                    new Spectre.Console.Panel($"¡Te has pasado! Has perdido con {sumaCartas} ({sumaCartas.ToWords()}) puntos.")
                        .Header("[bold red]Derrota[/]")
                        .Border(Spectre.Console.BoxBorder.Rounded)
                        .Padding(1,1)
                        .BorderColor(Spectre.Console.Color.Red)
                );
                break;
            }
        }
    }

    static int ObtenerValorCarta(int indice)
    {
        // A = 0, 2-10 = 1-9, J/Q/K = 10-12
        if (indice == 0)
        {
            var valorAs = Spectre.Console.AnsiConsole.Prompt(
                new Spectre.Console.SelectionPrompt<string>()
                    .Title("Has sacado un As. ¿Qué valor quieres darle?")
                    .PageSize(3)
                    .AddChoices(new[] { "1", "11" })
            );
            if (valorAs == "11") return 11;
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
