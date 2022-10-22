using System;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // making graph
            int[][] GraphArray = new int[][]
            {
                // All roades in graphs 
                new int[] {1,4,8},   // 0
                new int[] {0,2,3},   // 1
                new int[] {1,3},     // 2
                new int[] {1,2},     // 3
                new int[] {0,5,6,7}, // 4
                new int[] {4},       // 5
                new int[] {4},       // 6
                new int[] {4,9},     // 7
                new int[] {0,9},     // 8
                new int[] {7,8,10},  // 9
                new int[] {9}        // 10
            };

            // Where we are starting.
            Console.WriteLine("Choose position where you want to start.");
            string startPositionString = Console.ReadLine();
            int startPosition = Int32.Parse(startPositionString);

            Console.WriteLine("Choose position where you want to finish.");
            string endPositionString = Console.ReadLine();
            int endPosition = Int32.Parse(endPositionString);


            BFS bFS = new BFS(startPosition, endPosition ,GraphArray);
            bFS.Algorithm();
         
        }
    }

    public class BFS
    {
        private int _startPosition;
        private int _lastPosition;
        private int[][] _graphArray;

        public BFS(int sPosition, int lPosition, int[][] graphArray)
        {
            _startPosition = sPosition;
            _graphArray = graphArray;
            _lastPosition = lPosition;
        }

        public void PrintGraph()
        {
            for (int i = _startPosition; i < _graphArray.Length; i++)
            {
                for (int j = 0; j < _graphArray[i].Length; j++)
                {
                    Console.WriteLine($"{i}.Inputed values: {_graphArray[i][j]}");
                }
            }
        }

        public void Algorithm()
        {
            int lastPointOfFaze = 0;
            int roadLength = 0;

            List<int> odwiedzone = new List<int>();
            List<int> que = new List<int>();

            int actuallPostion = _startPosition;
            que.Add(actuallPostion);
            lastPointOfFaze = que.Last();

            do
            {
                Console.WriteLine("Odwiedzono Wierzcholek:" + actuallPostion);

                for (int i = 0; i < _graphArray[actuallPostion].Length; i++)
                {
                    if (que.Contains(_graphArray[actuallPostion][i]) || odwiedzone.Contains(_graphArray[actuallPostion][i]))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Dodano do kolejki wierzcholek: " + _graphArray[actuallPostion][i]);
                        que.Add(_graphArray[actuallPostion][i]);
                    }
                }

                if (que.Any())
                {
                    odwiedzone.Add(que[0]);
                    que.RemoveAt(0);



                    if (que.Any())
                    {
                        if (!que.Contains(lastPointOfFaze))
                        {
                            if (que.Contains(_lastPosition))
                            {
                                roadLength++;
                                break;
                            }
                            else
                            {
                                lastPointOfFaze = que.Last();
                                roadLength++;
                            }

                        }
                        actuallPostion = que[0];
                    }
                }
            }
            while (que.Any() == true);

            Console.WriteLine("Skonczylem algorytm");
            foreach (var values in odwiedzone)
            {
                Console.WriteLine($"Tutaj bylem - {values}");
            }

            Console.WriteLine("Dlugosc drogi wynosi: /////////////" + roadLength);

        }

    }
}

