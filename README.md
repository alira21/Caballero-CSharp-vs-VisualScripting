# Caballero del Oro – C# vs Visual Scripting

Juego 2D en Unity 6 donde el caballero debe recolectar todo el oro del mapa antes de que se acabe el tiempo.

## Controles
- Flechas: mover al caballero
- R: reiniciar al terminar la partida

## Implementación
- **Movimiento (C#):** `Scripts/PlayerController.cs`
- **Cámara (C#):** `Scripts/SeguirCamara.cs`
- **Contador, tiempo, victoria y derrota (C#):** `Scripts/GameManager.cs`
- **Recolección del oro (Visual Scripting):** Script Machine en el prefab del oro. El grafo detecta al Player con On Trigger Enter 2D y Compare Tag, llama a `GameManager.SumarOro()` y destruye la moneda.

## Grafo de Visual Scripting
![Grafo de recolección](docs/grafo_recoleccion.png)

## Ventajas y desventajas
| Criterio | C# | Visual Scripting |
|---|---|---|
| Facilidad de implementación | Requiere conocer la sintaxis, pero es rápido una vez aprendido | Más fácil para empezar, pero conectar nodos lleva más tiempo |
| Legibilidad | Compacto y se puede comentar | Muy visual en grafos pequeños, confuso con mucha lógica |
| Escalabilidad | Mejor para proyectos grandes y para trabajar con GitHub | Se complica en sistemas grandes |
