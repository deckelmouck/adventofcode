using System;

namespace adventofcode
{
    public class year2019day1
    {
        public static string input {get; set;}

        public static void part1()
        {
            string line;
            //int counter = 0;
            int neededfuel = 0;
            string filepath = Environment.CurrentDirectory + @"\2019\Day01\201901_1.txt";
            Console.WriteLine(filepath);

            if(System.IO.File.Exists(filepath))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);

                while((line = file.ReadLine()) != null)
                {
                    int mass = Convert.ToInt32(line);
                    int fuel = mass / 3 - 2;

                    neededfuel = neededfuel + fuel;
                    //Console.WriteLine(line);
                    //counter++;
                }
                //Console.WriteLine("{0} lines read.", counter.ToString());
                Console.WriteLine("we need {0} fuel.", neededfuel);
            }
        }
        public static void part2()
        {
            string line;
            //int counter = 0;
            int neededfuel = 0;
            string filepath = Environment.CurrentDirectory + @"\2019\Day01\201901_1.txt";
            Console.WriteLine(filepath);

            if(System.IO.File.Exists(filepath))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);

                while((line = file.ReadLine()) != null)
                {
                    int mass = Convert.ToInt32(line);
                    int fuel = mass / 3 - 2;
                    int fueltotal = fuel;

                    while(fuel / 3 - 2 > 0)
                    {
                        fuel = fuel / 3 - 2;
                        fueltotal = fueltotal + fuel;
                    }

                    neededfuel = neededfuel + fueltotal;

                    //Console.WriteLine(line);
                    //counter++;
                }
                //Console.WriteLine("{0} lines read.", counter.ToString());
                Console.WriteLine("we need {0} fuel.", neededfuel);
            }
        }


    }
}