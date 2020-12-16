using System;
using System.Collections.Generic;

namespace adventofcode
{
    class solutionday15
    {
        public class Spoken
        {
            public int Turn { get; set; }
            public int SpokenNumber { get; set; }
        }

        public solutionday15(int part)
        {
            var input = "11,18,0,20,1,7,16"; //"0,3,6";

            if(part == 1)
            {
                List<int[]> numbers = new List<int[]>();

                foreach (var item in input.Split(","))
                {
                    int[] number = new int[2];
                    number[0] = Convert.ToInt32(item);
                    number[1] = 0;
                    numbers.Add(number);   
                }

                List<Spoken> spokenList = new List<Spoken>();
                int searchTurn = (part == 1) ? 2020 : 30000000;

                for (int i = 0; i < searchTurn; i++)
                {
                    int turn = i + 1;
                    Console.Write(string.Format("Turn {0} - ", (i+1).ToString()));

                    if(i < numbers.Count)
                    {
                        int[] spoken = new int[2];
                        spoken = numbers[i];
                        spokenList.Add(new Spoken {Turn = turn, SpokenNumber = spoken[0]});
                        Console.WriteLine(string.Format("Spoken {0}", spoken[0].ToString()));
                    }
                    else if (i == 3)
                    {
                        spokenList.Add(new Spoken {Turn = turn, SpokenNumber = 0});
                        Console.WriteLine(string.Format("Spoken 0"));
                    }
                    else
                    {
                        int lastturn = i;
                        int lastspoken = spokenList.Find(x => x.Turn == lastturn).SpokenNumber;

                        int inspoken = spokenList.FindAll(x => x.SpokenNumber == lastspoken && x.Turn < turn - 1).Count;

                        if(inspoken == 0)
                        {
                            spokenList.Add(new Spoken {Turn = turn, SpokenNumber = 0});
                            Console.WriteLine(string.Format("Spoken 0"));
                        }
                        else 
                        {
                            var lastturninlist = spokenList.FindLast(x => x.SpokenNumber == lastspoken && x.Turn < turn - 1).Turn;
                            int newnumber = turn - lastturninlist - 1;

                            spokenList.Add(new Spoken {Turn = turn, SpokenNumber = newnumber});
                            Console.WriteLine(string.Format("Spoken {0}", newnumber));
                        }
                    }
                }

            }
            else if (part == 2)
            {
                Dictionary<int, int> spokenDic = new Dictionary<int, int>();

                for (int i = 0; i < input.Split(',').Length; i++)
                {
                    spokenDic.Add(Convert.ToInt32(input.Split(',')[i]), i + 1);
                }

                int lastnumber = Convert.ToInt32(input.Split(',')[input.Split(',').Length - 1]);
                int searchTurn = 30000000;

                for (int i = spokenDic.Count + 1; i <= searchTurn; i++)
                {
                    if(spokenDic.ContainsKey(lastnumber))
                    {
                        int spoken = i-1 - spokenDic[lastnumber];
                        spokenDic[lastnumber] = i-1;
                        lastnumber = spoken;
                    }
                    else
                    {
                        spokenDic[lastnumber] = i - 1;
                        lastnumber = 0;
                    }
                }

                Console.WriteLine(string.Format("last number on turn {0} is: {1}", searchTurn, lastnumber));
            }    
        }
    }
}