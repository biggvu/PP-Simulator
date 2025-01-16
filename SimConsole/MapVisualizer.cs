using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class MapVisualizer
    {
        private readonly Map _map;

        public MapVisualizer(Map map)
        {
            _map = map;
        }

        public void Draw()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            int width = _map.SizeX;
            int height = _map.SizeY;

            // Rysowanie górnej krawędzi
            Console.Write(Box.TopLeft);
            for (int x = 0; x < width; x++)
            {
                Console.Write($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
                if (x < width - 1)
                {
                    Console.Write(Box.TopMid);
                }
            }
            Console.WriteLine(Box.TopRight);

            // Rysowanie wierszy mapy
            for (int y = height - 1; y >= 0; y--)
            {
                // Wiersz z zawartością komórek
                Console.Write(Box.Vertical);
                for (int x = 0; x < width; x++)
                {
                    var mappables = _map is SmallMap smallMap ? smallMap.At(x, y).ToList() : new List<IMappable>();
                    char cellContent = ' ';
                    if (mappables.Count == 1)
                    {
                        cellContent = mappables.First() is Orc ? 'O' : 'E';
                    }
                    else if (mappables.Count > 1)
                    {
                        cellContent = 'X';
                    }

                    Console.Write($" {cellContent} ");
                    Console.Write(Box.Vertical);
                }
                Console.WriteLine();

                // Rysowanie linii poziomych (siatki) między wierszami
                if (y > 0)
                {
                    Console.Write(Box.MidLeft);
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
                        if (x < width - 1)
                        {
                            Console.Write(Box.Cross);
                        }
                    }
                    Console.WriteLine(Box.MidRight);
                }
            }

            // Rysowanie dolnej krawędzi
            Console.Write(Box.BottomLeft);
            for (int x = 0; x < width; x++)
            {
                Console.Write($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
                if (x < width - 1)
                {
                    Console.Write(Box.BottomMid);
                }
            }
            Console.WriteLine(Box.BottomRight);
        }
    }
}
