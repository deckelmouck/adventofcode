using System;
using System.Collections.Generic;

namespace adventofcode
{
    class solutionday11 : solutionBase
    {
        public class Chair
        {
            public int GridRow { get; set; }
            public int GridColumn { get; set; }
            public string Status { get; set; }

            public Chair(int row, int col, string status)
            {
                GridRow = row;
                GridColumn = col;
                Status = status;
            }

            public Chair(Chair c)
            {
                GridColumn = c.GridColumn;
                GridRow = c.GridRow;
                Status = c.Status;
            }

        }

        public int _Part = 0;

        public solutionday11(int part)
        {
            _Part = part;
            var input = getInputLines(@"C:\dev\adventofcode\2020\Day11\testinput.txt");

            List<Chair> map = new List<Chair>();

            int row = 0;

            foreach (var inputrow in input)
            {
                int column = 0;
                foreach (var inputcolumn in inputrow)
                {
                    map.Add(new Chair(row, column, inputcolumn.ToString()));
                    column++;
                }
                row++;
            }

            foreach (var item in map)
            {
                int neighboors = CheckNeighboors(map, item);

                Console.WriteLine(string.Format("{0},{1} = {2}, {3}",item.GridRow.ToString(), item.GridColumn.ToString(), item.Status, neighboors.ToString()));
            }

            List<Chair> Prev = new List<Chair>(Seating(map));
            List<Chair> Next = new List<Chair>(Seating(Prev));
            
            int round = 0;
            while (Prev.FindAll(x => x.Status == "#").Count != Next.FindAll(x => x.Status == "#").Count)
            {
                Prev = Next;
                Next = Seating(Next);
            

            int seated = Next.FindAll(x => x.Status == "#").Count;
            round++;
            Console.WriteLine(string.Format("round {1}: {0} occupied seats", seated.ToString(), round.ToString()));
            }
        }

        
        public int CheckNeighboors(List<Chair> map, Chair chair)
        {
            int neighboors = 0;
            List<(int, int)> directions = new List<(int, int)>();
            directions.AddRange( new[] { (0, -1), (0, 1), (-1, 0), (1, 0), (-1, -1), (-1, 1), (1, -1), (1, 1) });
            
            foreach (var (row, col) in directions)
            {
                Chair neighboor = map.Find(c => c.GridColumn == chair.GridColumn + col && c.GridRow == chair.GridRow + row);

                if(neighboor != null && neighboor.Status == "#")
                {
                    neighboors++;
                }
                else if (neighboor != null && _Part == 2 && neighboor.Status == ".")
                {
                    //recursive look at other neighboors in this direction to find an occupied seat..
                    
                }
            }
            return neighboors;
        }

        public List<Chair> Seating(List<Chair> map)
        {
            int OccupiedLimit = 5; //(_Part == 1) ? 4 : 5;
            List<Chair> newMap = new List<Chair>();

            foreach (var chair in map)
            {
                Chair newChair = new Chair(chair.GridRow, chair.GridColumn, chair.Status);

                if(newChair.Status == "L" && CheckNeighboors(map, newChair) == 0)
                {
                    newChair.Status = "#";
                }
                else if (newChair.Status == "#" && CheckNeighboors(map, newChair) >= OccupiedLimit)
                {
                    newChair.Status = "L";
                }

                newMap.Add(newChair);
            }

            return newMap;
        }
    }
}