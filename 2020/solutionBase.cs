using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionBase
    {
        /// gets input from multiple lines seperated by a blank line in a list of string
        public List<string> getInput(string filename)
        {
            //string filename = @"C:\dev\adventofcode\2020\Day04\input.txt";

            List<string> inputList = new List<string>();


            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    string passline = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line != "")
                        {
                            passline = passline + " " + line;
                        }
                        else
                        {
                            inputList.Add(passline.Remove(0, 1));
                            passline = "";
                        }
                    }
                    //bugfix do add last line, could cause a problem on day 4 :D
                    inputList.Add(passline.Remove(0, 1));
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