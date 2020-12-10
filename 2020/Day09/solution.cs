using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    class solutionday09 : solutionBase
    {
        public solutionday09(int part)
        {
            var input = getInputLong(@"C:\dev\adventofcode\2020\Day09\input.txt");

            int pos = 0;
            long nomatch = 0;

            foreach (var item in input.GetRange(25, input.Count-25))
            {
                List<long> temp = new List<long>();
                temp = input.GetRange(pos, 25);
                bool included = false;

                foreach (var i in temp)
                {
                    foreach (var j in temp)
                    {
                        if(i != j && item == i + j)
                        {
                            included = true;
                        }
                    }
                }

                if(!included)
                {
                    Console.WriteLine(string.Format("not included {0}", item.ToString()));
                    nomatch = item;
                }
                pos++;
            }
        
            
            if(part == 2 && nomatch > 0)
            {
                int count = 0;
                foreach (var item in input)
                {
                    int retval = nextAdd(nomatch, 0, count, count, input);

                    if(retval > 0)
                    {
                        Console.WriteLine(string.Format("between {0} and {1}", count.ToString(), retval.ToString()));
                    }

                    count++;
                }
            }
        }

        public int nextAdd(long search, long actualsum, int start, int position, List<long> inputtosearch)
        {
            actualsum += inputtosearch[position];

            if(actualsum < search)
            {
                nextAdd(search, actualsum, start, position + 1, inputtosearch);
            }
            else if (actualsum > search)
            {
                return 0;
            }
            else if (actualsum == search)
            {
                if(position != start)
                {
                    Console.WriteLine(string.Format("between {0} and {1}", start.ToString(), position.ToString()));

                    List<long> solutions = new List<long>();

                    for (int i = 0; i < position - start; i++)
                    {
                        solutions.Add(inputtosearch[start + i]);
                    }
                    solutions.Sort();
                    Console.WriteLine(string.Format("between {0} and {1}", solutions.Min().ToString(), solutions.Max().ToString()));
                    Console.WriteLine(string.Format("{0}", (solutions.Min() + solutions.Max()).ToString()));
                }
                return position;
            }

            return 0;
        }
    }
}