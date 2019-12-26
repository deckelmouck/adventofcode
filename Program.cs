using System;

namespace adventofcode
{
    class Program
    {
        static int year {get; set;}
        static int day {get; set;}
        static int part {get;set;}

        static void Main(string[] args)
        {
            Console.WriteLine("Hello to adventofcode 2019!");

            bool standard = true ;

            if(standard)
            {
                Console.WriteLine("Please enter a year:");
                year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter a day:");
                day = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter a part:");
                part = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("you selected year {0} day {1} part {2} to solve. let's try it....", year.ToString(), day.ToString(), part.ToString());

                solve(year, day, part);
            }
            else 
            {
                solve(2019, 3, 1);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void solve(int year, int day, int part)
        {
            if(year == 2019)
            {
                if(day == 1)
                {   
                    if(part == 1)
                    {
                        year2019day1.part1();
                    }
                    else if(part == 2)
                    {
                        year2019day1.part2();
                    }
                }
                else if(day == 2)
                {
                    if(part == 1)
                    {
                        year2019day2.part1();
                    }
                    else if(part == 2)
                    {
                        year2019day2.part2();
                    }
                }
                else if(day == 3)
                {
                    if(part == 1)
                    {
                        year2019day3.part1();
                    }
                }
            }
        }

    }
}
;