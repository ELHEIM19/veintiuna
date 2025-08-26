# test

Este proyecto es un juego de cartas simple en consola hecho en C# para .NET 9.0.

## Cómo ejecutar

1. Instala [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0).
2. Ejecuta el proyecto con:

```
dotnet run --project test/test.csproj
```

## Estructura

 - `Veintiuna.cs`: Código principal del juego.
 - `veintiuna.csproj`: Archivo de configuración del proyecto.

## Cómo jugar

Al iniciar el programa, verás un menú:

1. Iniciar juego
2. Salir

Si eliges "Iniciar juego":
- Recibes una carta inicial (puede ser A, 2-10, J, Q o K).
- Puedes pedir más cartas presionando Enter, o detenerte con cualquier otra tecla.
- El objetivo es sumar 21 puntos sin pasarte.
- Si llegas a 21, ganas. Si te pasas, pierdes.

### Valores de las cartas
- Las cartas del 2 al 10 valen su propio número.
- Las figuras (J, Q, K) valen 10 puntos.
- Los Ases (A) pueden valer 1 u 11 puntos, y el jugador decide el valor cada vez que sale un As.

Al finalizar una partida, puedes elegir si deseas continuar jugando o salir.
