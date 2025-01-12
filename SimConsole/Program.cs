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
        List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> points = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        int turnNumber = 1;

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();

            Creature currentCreature = simulation.CurrentCreature;

            string creatureInfo = currentCreature switch
            {
                Orc orc => $"ORC {orc.Name} [{orc.Level}][{orc.Rage}] ({orc.Position})",
                Elf elf => $"ELF {elf.Name} [{elf.Level}][{elf.Agility}] ({elf.Position})",
                _ => $"{currentCreature.GetType().Name.ToUpper()} {currentCreature.Name} [{currentCreature.Level}] ({currentCreature.Position})"
            };

            Console.WriteLine($"Turn {turnNumber}:");
            Console.WriteLine(creatureInfo);
            Console.WriteLine($"Direction: {simulation.CurrentMoveName}");

            simulation.Turn();
            Console.ReadKey();
            turnNumber++;
        }

        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
    }
}
