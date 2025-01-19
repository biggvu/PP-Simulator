using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using System.Collections.Generic;

public class SimulationModel : PageModel
{
    public int CurrentTurn { get; set; }
    public int MapSizeX { get; set; }
    public int MapSizeY { get; set; }
    public List<SimulationTurnLog> TurnLogs { get; set; }

    public Dictionary<char, string> SymbolToImageMap { get; } = new()
    {
        { 'X', "combo-80.png" },
        { 'B', "eagle-80.png" },
        { 'E', "elf-80.png" },
        { 'b', "emu-80.png" },
        { 'O', "ork-80.png" },
        { 'A', "rabbit-80.png" }
    };

    public void OnGet(int turn = 0)
    {
        var mapSizeX = 8;
        var mapSizeY = 6;
        var moves = "dlrludluddlrulr";
        var map = new SmallTorusMap(mapSizeX, mapSizeY);

        List<IMappable> mappables = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals("Rabbits", 5),
            new Birds("Eagles", Birds.MovementType.Flying, 3),
            new Birds("Ostriches", Birds.MovementType.NonFlying, 4)
   
        };

        List<Point> points = new()
        {
            new(2, 2),
            new(3, 1),
            new(5, 5),
            new(7, 3),
            new(0, 4)
        };

        var simulation = new Simulation(map, mappables, points, moves);
        var history = new SimulationHistory(simulation);

        MapSizeX = mapSizeX;
        MapSizeY = mapSizeY;
        TurnLogs = history.TurnLogs;

        CurrentTurn = Math.Clamp(turn, 0, TurnLogs.Count - 1);
    }
}
