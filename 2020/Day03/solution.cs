using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionday03
    {
        string filename = @"C:\dev\adventofcode\2020\Day03\input.txt";
        int multi = 0;

        public solutionday03(int part)
        {
            if(part == 1)
            {
                int trees = encounter(3, 1);
                Console.WriteLine(string.Format("encounter {0} trees", trees.ToString()));
            }

            if(part == 2)
            {
                Int64[] slopes = new Int64[5];

                slopes[0] = encounter(1,1);
                slopes[1] = encounter(3,1);
                slopes[2] = encounter(5,1);
                slopes[3] = encounter(7,1);
                slopes[4] = encounter(1,2);

                Int64 trees = slopes[0] * slopes[1] * slopes[2] * slopes[3] * slopes[4];
                                
                Console.WriteLine(string.Format("encounter {0} trees", trees.ToString()));
            }

        }

        public int encounter(int right, int down)
        {
            int[] test = inputWidthAndHeight();
            string output = string.Format("input dimensions are widht {0}, heigth {1}", test[0].ToString(), test[1].ToString());
            Console.WriteLine(output);

            int neededwidth = right * down * test[1];

            multi = neededwidth / test[0] + 1;

            List<string> input = getInput(multi);

            int x = 0;
            int y = 0;
            int trees = 0;

            foreach (var item in input)
            {   
                if(y % down == 0)
                {
                    if(item[x].ToString() == "#")
                    {
                        trees++;
                    }
                    x = x + right;
                }             
                
                y++;
                Console.Write(".");
            }
            
            Console.WriteLine(string.Format("encounter {0} trees", trees.ToString()));
            return trees;

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