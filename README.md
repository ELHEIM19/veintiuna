# test

Este proyecto es un juego de cartas simple en consola hecho en C# para .NET 9.0.

## Cómo ejecutar

1. Instala [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0).
2. Ejecuta el proyecto con:

```
dotnet run --project test/test.csproj
```

## Estructura

- `Program.cs`: Código principal del juego.
- `test.csproj`: Archivo de configuración del proyecto.

## Juego

El juego consiste en pedir cartas hasta sumar 21 puntos sin pasarse. Si llegas a 21, ganas; si te pasas, pierdes.
