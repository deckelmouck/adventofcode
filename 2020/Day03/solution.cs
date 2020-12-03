using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionday03
    {
        string filename = @"C:\dev\adventofcode\2020\Day03\input.txt";
        int multi = 0;

        public solutionday03(int right, int down)
        {
            int[] test = inputWidthAndHeight();
            string output = string.Format("input dimensions are widht {0}, heigth {1}", test[0].ToString(), test[1].ToString());
            Console.WriteLine(output);

            int neededwidth = right * down * test[1];

            multi = neededwidth / test[0] + 1;

            List<string> input = getInput(32);

            int x = 1;
            int y = 0;
            int trees = 0;

            foreach (var item in input)
            {                
                if(item[y].ToString() == "#")
                {
                    trees++;
                }
                y = y + 3;
                x++;
                Console.Write(".");
            }
            
            Console.WriteLine(string.Format("encounter {0} trees", trees.ToString()));
        }

        public int[] inputWidthAndHeight()
        {
            int width = 0;
            int height = 0;
            int[] dimensions = new int[2];

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int length = line.Length;
                        if(width < length)
                        {
                            width = length;
                        }
                        height++;                        
                    }
                }

                dimensions[0] = width;
                dimensions[1] = height;
                
                return dimensions;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<string> getInput(int multi)
        {
            List<string> inputList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string newline = line;

                        for (int i = 0; i < multi; i++)
                        {
                            newline = newline + line;
                        }

                        inputList.Add(newline);
                    }
                }
                return inputList;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}