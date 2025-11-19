using System;
using System.IO;

namespace adventofcode.Year2024.Day07
{
    public class Solution : BaseSolution, ISolver
    {
        public void SolvePart1()
        {
            //var inputFilePath = GetInputFilePath("test");
            var inputFilePath = GetInputFilePath();

            string[] lines = File.ReadAllLines(inputFilePath);
            // Add your Part 1 solution logic here

            long sum = 0;
            
            foreach (var line in lines)
            {
                if (CanCalculate(line))
                {
                    sum += long.Parse(line.Split(":")[0]);
                }
            }

            Console.WriteLine(sum);
        }

        public void SolvePart2()
        {
            Console.WriteLine("not implemented");
        }


        // check if value before the double point can be calculated with addition and or multiplication of the values after the double point by left to right calculation rule
        private bool CanCalculate(string line)
        {
            var parts = line.Split(":");
            var left = parts[0];
            var right = parts[1];

            long leftValue = long.Parse(left);
            var numbers = right.Trim().Split(" ");

            long[] numbersArray = new long[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersArray[i] = long.Parse(numbers[i]);
            }

            return CheckOperations(leftValue, numbersArray, 0, numbersArray[0]);
        }

        private static bool CheckOperations(long target, long[] numbers, int index, long currentValue)
        {
            // Base case: we've used all numbers, check if we reached the target
            if (index == numbers.Length - 1)
            {
                return currentValue == target;
            }

            // Get the next number
            long nextNumber = numbers[index + 1];

            // Try addition
            if (CheckOperations(target, numbers, index + 1, currentValue + nextNumber))
            {
                return true;
            }

            // Try multiplication
            if (CheckOperations(target, numbers, index + 1, currentValue * nextNumber))
            {
                return true;
            }

            // If neither addition nor multiplication worked, return false
            return false;
        }
    }
}
