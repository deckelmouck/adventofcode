using System;

namespace adventofcode.Year2019.Day01;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        string line;
        //int counter = 0;
        int neededfuel = 0;
        // string filepath = Environment.CurrentDirectory + @"\2019\Day01\201901_1.txt";
        //string filepath = Path.Combine(Environment.CurrentDirectory, "2019", "Day01", "201901_1.txt");
        //string filepath = Path.Combine(Environment.CurrentDirectory, GetYear(), $"Day{GetDay()}", "input.txt");
        string filepath = GetInputFilePath("201901_1.txt");

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

    public void SolvePart2()
    {
        string line;
        //int counter = 0;
        int neededfuel = 0;
        //string filepath = Environment.CurrentDirectory + @"\2019\Day01\201901_1.txt";
        string filepath = System.IO.Path.Combine(Environment.CurrentDirectory, "2019", "Day01", "201901_1.txt");

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
