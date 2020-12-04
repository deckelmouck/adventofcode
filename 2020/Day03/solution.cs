using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionday03
    {
        string filename = @"C:\dev\adventofcode\2020\Day03\input.txt";

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
            List<string> input = getInput();

            int x = 0;
            int y = 0;
            int trees = 0;

            foreach (var item in input)
            {   
                if(y % down == 0)
                {
                    if(item[x % item.Length].ToString() == "#")
                    {
                        trees++;
                    }
                    x = x + right;
                }             
                
                y++;
                //Console.Write(".");
            }
            
            Console.WriteLine(string.Format("encounter {0} trees", trees.ToString()));
            return trees;

        }

        public List<string> getInput()
        {
            List<string> inputList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        inputList.Add(line);
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