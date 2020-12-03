using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionday02 
    {
        public solutionday02(int part)
        {
            List<string> input = getInput();

            if (part == 1)
            {
                int valid = 1;

                foreach (var item in input)
                {
                    string checkrange = item.Split(" ")[0];
                    string checkchar = item.Split(" ")[1].Replace(":", "");
                    string checkpassword = item.Split(" ")[2];

                    int min = Convert.ToInt32(checkrange.Split("-")[0]);
                    int max = Convert.ToInt32(checkrange.Split("-")[1]);

                    int count = checkpassword.Split(checkchar).Length-1;
                    
                    if(min >= count && count <= max)
                    {
                        valid++;
                    }
                }
                
                Console.WriteLine(string.Format("{0} are valid passwords", valid.ToString()));
            }

            if (part == 2)
            {
                int valid = 0;

                foreach (var item in input)
                {
                    string checkrange = item.Split(" ")[0];
                    string checkchar = item.Split(" ")[1].Replace(":", "");
                    string checkpassword = item.Split(" ")[2];

                    int min = Convert.ToInt32(checkrange.Split("-")[0])-1;
                    int max = Convert.ToInt32(checkrange.Split("-")[1])-1;

                    char first = checkpassword[min];
                    char second = checkpassword[max];

                    if(checkchar == first.ToString() ^ checkchar == second.ToString())
                    {
                        valid++;
                    }
                }
                Console.WriteLine(string.Format("{0} are valid passwords", valid.ToString()));
            }     
        }

        public List<string> getInput()
        {
            string filename = @"C:\dev\adventofcode\2020\Day02\input.txt";

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