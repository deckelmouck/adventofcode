﻿using System;
using adventofcode;
namespace adventofcode
{
    class Program
    {
        static int year {get; set;}
        static int day {get; set;}
        static int part {get;set;}

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("Hello to adventofcode!");

            if(args.Length == 3)
            {
                year = Convert.ToInt32(args[0]);
                day = Convert.ToInt32(args[1]);
                part = Convert.ToInt32(args[2]);

                Console.WriteLine("you selected year {0} day {1} part {2} to solve. let's try it....", year.ToString(), day.ToString(), part.ToString());

                solve(year, day, part);
            }
            else 
            {
                //solutionDay1 sd1 = new solutionDay1(2);
                //solutionday02 sd2 = new solutionday02(2);
                //solutionday03 sd3 = new solutionday03(2);
                //solutionday04 sd4 = new solutionday04(1);
                solutionday05 sd5 = new solutionday05(2);                
            }

            TimeSpan timeSpan = DateTime.Now - start;
            Console.Write("Problem solved in ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(string.Format("{0} ms", timeSpan.TotalMilliseconds.ToString()));
            Console.ResetColor();
            //Console.WriteLine("Press any key to exit.");
            //Console.Read(); 
        }

        static void solve(int year, int day, int part)
        {
            if(year == 2020)
            {
                switch (day)
                {
                    case 1:
                        solutionDay01 sd1 = new solutionDay01(part);
                        break;
                    case 2:
                        solutionday02 sd2 = new solutionday02(part);
                        break;
                    case 3:
                        solutionday03 sd3 = new solutionday03(part);
                        break;
                    case 4:
                        solutionday04 sd4 = new solutionday04(part);
                        break;
                    case 5:
                        solutionday05 sd5 = new solutionday05(part);
                        break;
                    case 6:
                        solutionday06 sd6 = new solutionday06(part);
                        break;
                    case 8:
                        solutionday08 sd8 = new solutionday08(part);
                        break;
                    case 9:
                        solutionday09 sd9 = new solutionday09(part);
                        break;
                    case 10:
                        solutionday10 sd10 = new solutionday10(part);
                        break;
                    case 11:
                        solutionday11 sd11 = new solutionday11(part);
                        break;
                    case 12:
                        solutionday12 sd12 = new solutionday12(part);
                        break;
                    default:
                        break;
                }
            }

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
                    else if(part == 2)
                    {
                        year2019day3.part2();
                    }
                }
                else if(day == 4)
                {
                    if(part == 1)
                    {
                        year2019day4.part1();
                    }
                    else if(part == 2)
                    {
                        year2019day4.part2();
                    }
                }
            }
        }
    }
}
;