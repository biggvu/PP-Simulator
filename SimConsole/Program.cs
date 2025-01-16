using SimConsole;
using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> points = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        int turnNumber = 1;

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();

            IMappable currentMappable = simulation.CurrentMappable;

            string mappableInfo = currentMappable switch
            {
                Orc orc => $"ORC {orc.Name} [{orc.Level}][{orc.Rage}] ({orc.Position})",
                Elf elf => $"ELF {elf.Name} [{elf.Level}][{elf.Agility}] ({elf.Position})",
                Creature creature => $"{creature.GetType().Name.ToUpper()} {creature.Name} [{creature.Level}] ({creature.Position})",
                _ => $"{currentMappable.GetType().Name.ToUpper()} [{currentMappable.Position}]"
            };

            Console.WriteLine($"Turn {turnNumber}:");
            Console.WriteLine(mappableInfo);
            Console.WriteLine($"Direction: {simulation.CurrentMoveName}");

            simulation.Turn();
            Console.ReadKey();
            turnNumber++;
        }

        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
    }
}
