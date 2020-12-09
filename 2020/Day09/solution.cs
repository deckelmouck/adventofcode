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

            foreach (var item in input)
            {
                List<long> temp = new List<long>();
                temp.AddRange(input.Select(x => x.));

                Console.WriteLine(item.ToString());
            }
        }
    }
}