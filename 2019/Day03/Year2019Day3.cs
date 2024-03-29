using System;
using System.Collections.Generic;

namespace adventofcode
{
    public class Waypoint
    {
        public int line {get; set;}
        public int xcoordinate {get; set;}
        public int ycoordinate {get; set;}
        public int manhattendistance {get; set;}
        public int steps {get; set;}
    }

    public class year2019day3
    {
        public static List<Waypoint> waypoints = new List<Waypoint>();

        public static int actualx;
        public static int actualy;
        public static int step;

        public static void part1()
        {
            string line;
            string filepath = Environment.CurrentDirectory + @"\2019\Day03\201903_1.txt";

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            
            List<string> vectors = new List<string>();

            int linenumber = 0;

            while((line = file.ReadLine()) != null)
            {
                linenumber = linenumber + 1;

                //reset for new line
                actualx = 0;
                actualy = 0;

                vectors.Clear();
                //read line in vectors
                vectors.AddRange(line.Split(','));

                //go through each vector
                foreach (string vector in vectors)
                {
                    Console.WriteLine(vector);

                    string direction = vector.Substring(0, 1);
                    int count = Convert.ToInt32(vector.Substring(1, vector.Length - 1));

                    switch (direction)
                    {
                        case "D":
                            moved(linenumber, count);
                            break;
                        case "L":
                            movel(linenumber, count);
                            break;
                        case "R":
                            mover(linenumber, count);
                            break;
                        case "U":
                            moveu(linenumber, count);
                            break;
                        default:

                        break;
                    }
                }
            }

            List<Waypoint> lstwp1 = new List<Waypoint>();
            List<Waypoint> lstwp2 = new List<Waypoint>();

            foreach (Waypoint wayp in waypoints)
            {
                if(wayp.line == 1)
                {
                    lstwp1.Add(wayp);
                }
                if(wayp.line == 2)
                {
                    lstwp2.Add(wayp);
                }
            }

            Console.WriteLine(lstwp1.Count.ToString());
            Console.WriteLine(lstwp2.Count.ToString());

            List<Waypoint> lstwpboth = new List<Waypoint>();

            int countboth = 0;
            int countfirst = 1;
            int countfirstall = lstwp1.Count;
            
            foreach(Waypoint wayp1 in lstwp1)
            {
                if(!lstwpboth.Contains(wayp1))
                {
                    foreach(Waypoint wayp2 in lstwp2)
                    {
                        if(!lstwpboth.Contains(wayp2))
                        {
                            if(wayp1.xcoordinate == wayp2.xcoordinate && wayp1.ycoordinate == wayp2.ycoordinate)
                            {
                                if(!lstwpboth.Contains(wayp1))
                                {
                                    lstwpboth.Add(wayp1);
                                    countboth++;
                                    Console.WriteLine(countboth.ToString());
                                }
                            }
                        }
                    }
                }
                countfirst++;
                if(countfirst % 1000 == 0)
                {
                    Console.WriteLine("all: {0}", countfirst.ToString());
                }
            }

            Console.WriteLine("there are {0} waypoints in both lines", lstwpboth.Count.ToString());

            Waypoint lowestwaypoint = new Waypoint();
            lowestwaypoint = lstwpboth[0];

            foreach (Waypoint wp in lstwpboth)
            {
                if(wp.manhattendistance < lowestwaypoint.manhattendistance)
                {
                    lowestwaypoint = wp;
                }
            }

            Console.WriteLine("waypoint in both lines with lowest manhatten distance from center:");
            Console.WriteLine("waypoint: x = {0}, y = {1}, md = {2}", lowestwaypoint.xcoordinate.ToString(), lowestwaypoint.ycoordinate.ToString(), lowestwaypoint.manhattendistance.ToString());

        }

        public static void part2()
        {
            string line;
            string filepath = Environment.CurrentDirectory + @"\2019\Day03\201903_1.txt";

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            
            List<string> vectors = new List<string>();

            int linenumber = 0;

            while((line = file.ReadLine()) != null)
            {
                linenumber = linenumber + 1;

                //reset for new line
                actualx = 0;
                actualy = 0;
                step = 0;

                vectors.Clear();
                //read line in vectors
                vectors.AddRange(line.Split(','));

                //go through each vector
                foreach (string vector in vectors)
                {
                    Console.WriteLine(vector);

                    string direction = vector.Substring(0, 1);
                    int count = Convert.ToInt32(vector.Substring(1, vector.Length - 1));

                    switch (direction)
                    {
                        case "D":
                            moved(linenumber, count);
                            break;
                        case "L":
                            movel(linenumber, count);
                            break;
                        case "R":
                            mover(linenumber, count);
                            break;
                        case "U":
                            moveu(linenumber, count);
                            break;
                        default:

                        break;
                    }
                }
            }

            List<Waypoint> lstwp1 = new List<Waypoint>();
            List<Waypoint> lstwp2 = new List<Waypoint>();

            foreach (Waypoint wayp in waypoints)
            {
                if(wayp.line == 1)
                {
                    lstwp1.Add(wayp);
                }
                if(wayp.line == 2)
                {
                    lstwp2.Add(wayp);
                }
            }

            Console.WriteLine(lstwp1.Count.ToString());
            Console.WriteLine(lstwp2.Count.ToString());

            List<Waypoint> lstwpboth = new List<Waypoint>();

            int countboth = 0;
            int countfirst = 1;
            int countfirstall = lstwp1.Count;
            
            foreach(Waypoint wayp1 in lstwp1)
            {
                if(!lstwpboth.Contains(wayp1))
                {
                    foreach(Waypoint wayp2 in lstwp2)
                    {
                        if(!lstwpboth.Contains(wayp2))
                        {
                            if(wayp1.xcoordinate == wayp2.xcoordinate && wayp1.ycoordinate == wayp2.ycoordinate)
                            {
                                if(!lstwpboth.Contains(wayp1))
                                {
                                    lstwpboth.Add(wayp1);
                                    countboth++;
                                    Console.WriteLine(countboth.ToString());
                                    Console.WriteLine("steps = {0}", wayp1.steps + wayp2.steps);
                                }
                            }
                        }
                    }
                }
                countfirst++;
                if(countfirst % 1000 == 0)
                {
                    Console.WriteLine("all: {0}", countfirst.ToString());
                }
            }

            Console.WriteLine("there are {0} waypoints in both lines", lstwpboth.Count.ToString());

            Waypoint lowestwaypoint = new Waypoint();
            lowestwaypoint = lstwpboth[0];

            foreach (Waypoint wp in lstwpboth)
            {

                if(wp.manhattendistance < lowestwaypoint.manhattendistance)
                {
                    lowestwaypoint = wp;
                }
            }

            Console.WriteLine("waypoint in both lines with lowest manhatten distance from center:");
            Console.WriteLine("waypoint: x = {0}, y = {1}, md = {2}", lowestwaypoint.xcoordinate.ToString(), lowestwaypoint.ycoordinate.ToString(), lowestwaypoint.manhattendistance.ToString());

        }

        public static void moveu(int line, int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                actualy = actualy + 1;
                step++;
                waypoints.Add(new Waypoint{ line = line, xcoordinate = actualx, ycoordinate = actualy, manhattendistance = Math.Abs(actualx) + Math.Abs(actualy), steps = step });
            }
        }
        public static void moved(int line, int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                actualy = actualy - 1;
                step++;
                waypoints.Add(new Waypoint{ line = line, xcoordinate = actualx, ycoordinate = actualy, manhattendistance = Math.Abs(actualx) + Math.Abs(actualy), steps = step });
            }
        }
        public static void movel(int line, int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                actualx = actualx - 1;
                step++;
                waypoints.Add(new Waypoint{ line = line, xcoordinate = actualx, ycoordinate = actualy, manhattendistance = Math.Abs(actualx) + Math.Abs(actualy), steps = step });
            }
        }
        public static void mover(int line, int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                actualx = actualx + 1;
                step++;
                waypoints.Add(new Waypoint{ line = line, xcoordinate = actualx, ycoordinate = actualy, manhattendistance = Math.Abs(actualx) + Math.Abs(actualy), steps = step });
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}