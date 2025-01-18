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

        //opisanie zadania
        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Birds("Eagles", Birds.MovementType.Flying, 3),
            new Birds("Ostriches", Birds.MovementType.NonFlying, 4),
            new Animals("Rabbits", 5)
        };

        List<Point> points = new()
        {
            new(0, 0), // Orc
            new(7, 5), // Elf
            new(4, 2), // Eagles
            new(6, 3), // Ostriches
            new(3, 4)  // Rabbits
        };
        string moves = "dlrldrudllurrdd";
        //koniec opisu zadania

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
                Birds bird => $"{bird.Description.ToUpper()} [{(bird.CanFly ? "Flying" : "Non-Flying")}][{bird.Size}] ({bird.Position})",
                Animals animal => $"{animal.Description.ToUpper()} [{animal.Size}] ({animal.Position})",
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
