using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionDay01
    {
        public solutionDay01(int part)
        {
            List<int> input = new List<int>();
            input = getInput();

            if(part == 1)
            {
                foreach (var numOne in input)
                {
                    foreach (var numTwo in input)
                    {
                        if (numOne + numTwo == 2020)
                        {
                            string ret;
                            ret = string.Format("num1: {0}, num2: {1}, result: {2}", numOne.ToString(), numTwo.ToString(), (numOne * numTwo).ToString());
                            Console.WriteLine(ret);
                            return;
                        }
                    }
                }
            }

            if(part == 2)
            {                
                foreach (var numOne in input)
                {
                    foreach (var numTwo in input)
                    {
                        foreach (var numThree in input)
                        {
                            if (numOne + numTwo + numThree == 2020)
                            {
                                string ret;
                                ret = string.Format("num1: {0}, num2: {1}, num3: {2}, result: {3}", 
                                    numOne.ToString(), 
                                    numTwo.ToString(), 
                                    numThree.ToString(), 
                                    (numOne * numTwo * numThree).ToString());
                                Console.WriteLine(ret);
                                return;
                            }        
                        }
                    }
                }

            }

            Console.WriteLine("exit");
            
        }

        public List<int> getInput()
        {
            string filename = @"C:\dev\adventofcode\2020\Day01\input.txt";
            List<int> inputList = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        inputList.Add(Convert.ToInt32(line));
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