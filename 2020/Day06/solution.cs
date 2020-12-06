using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    class solutionday06 : solutionBase
    {
        public solutionday06(int part)
        {
            List<string> input = getInput(@"C:\dev\adventofcode\2020\Day06\input.txt");
            int count = 0;

            foreach (var item in input)
            {
                Console.WriteLine(item);
                string sorted = String.Concat(item.Replace(" ", "").OrderBy(s => s).Distinct());
                Console.WriteLine(string.Format("{0} - {1}", sorted, sorted.Length.ToString()));
                count += sorted.Length;

            }

            Console.WriteLine(string.Format("sum of counts is: {0}", count.ToString()));
        }
    }
}