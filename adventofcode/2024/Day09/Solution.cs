using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Year2024.Day09
{
    public class Solution : BaseSolution, ISolver
    {
        public void SolvePart1()
        {
            //var inputFilePath = GetInputFilePath("test");
            var inputFilePath = GetInputFilePath();

            string line = File.ReadAllText(inputFilePath);
            // Add your Part 1 solution logic here

            char[] numbers = line.ToArray();

            List<string> numbersList = new List<string>();
            int index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                //Console.WriteLine(number);
                if (i % 2 == 0)
                {
                    int number = int.Parse(numbers[i].ToString());
                    for (int n = 1; n <= number; n++)
                    {
                        numbersList.Add(index.ToString());
                    }
                    index++;
                }
                else
                {
                    int number = int.Parse(numbers[i].ToString());
                    for (int n = 1; n <= number; n++)
                    {
                        numbersList.Add(".");
                    }
                }
            }

            for (int i = 0; i < numbersList.Count; i++)
            {
                int lastNumberIndex = numbersList.Count - 1;

                if (numbersList[i] == ".")
                {
                    int lastNumber = 0;
                    lastNumberIndex = 0;
                    // search in numberslist from back, what the last number is that is not a dot
                    for (int n = numbersList.Count - 1; n >= 0; n--)
                    {
                        if (int.TryParse(numbersList[n], out int value))
                        {
                            lastNumber = value; 
                            lastNumberIndex = n;
                            break;
                        }
                    }
                    
                    if (i < lastNumberIndex)
                    {
                        numbersList[i] = lastNumber.ToString();
                        numbersList[lastNumberIndex] = ".";
                    }
                }
            }

            Console.WriteLine(string.Join("", numbersList));

            numbersList.RemoveAll(x => x == ".");
            long checksum = 0;
            for (int i = 0; i < numbersList.Count; i++)
            {
                checksum += long.Parse(numbersList[i]) * i;
            }

            Console.WriteLine($"Checksum: {checksum}");
        }

        public void SolvePart2()
        {
            Console.WriteLine("not implemented");
        }
    }
}
