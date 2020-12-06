using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    class solutionday06 : solutionBase
    {
        public solutionday06(int part)
        {
            int count = 0;

            if(part == 1)
            {
                List<string> input = getInput(@"C:\dev\adventofcode\2020\Day06\input.txt");

                foreach (var item in input)
                {
                    Console.WriteLine(item);
                    string sorted = String.Concat(item.Replace(" ", "").OrderBy(s => s).Distinct());
                    Console.WriteLine(string.Format("{0} - {1}", sorted, sorted.Length.ToString()));
                    count += sorted.Length;

                }

                Console.WriteLine(string.Format("sum of counts is: {0}", count.ToString()));
            }

            if (part == 2)
            {
                List<List<string>> input = getInputListed(@"C:\dev\adventofcode\2020\Day06\input.txt");
                int yes = 0;

                foreach (var group in input)
                {
                    Console.WriteLine("--new group--");
                    string completeGroup = "";
                    int groupMembers = 0;

                    foreach (var item in group)
                    {
                        completeGroup = completeGroup + item;
                        groupMembers++;
                        Console.WriteLine(item);
                    }

                    string sorted = String.Concat(completeGroup.Replace(" ", "").OrderBy(s => s).Distinct());

                    string[] arr = new string[sorted.Length];
                    for (int i = 0; i < sorted.Length; i++)
                    {
                        arr[i] = sorted[i].ToString();
                    }             

                    int sameAnswers = 0;

                    foreach (var str in arr)
                    {
                        sameAnswers = completeGroup.Count(x => x.ToString() == str);
                        if(sameAnswers == groupMembers)
                        {
                            yes++;
                        }
                    }

                }
                Console.WriteLine(string.Format("yes answers: {0}", yes.ToString()));
            }
        }
    }
}