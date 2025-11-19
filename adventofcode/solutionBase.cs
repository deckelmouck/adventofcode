using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionBase
    {
        public List<string> getInputLines(string filename)
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

        /// gets input from multiple lines seperated by a blank line in a list of string
        public List<string> getInput(string filename)
        {
            //string filename = @"2020\Day04\input.txt";

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

        public List<List<string>> getInputListed(string filename)
        {
            //string filename = @"2020\Day04\input.txt";

            List<List<string>> inputList = new List<List<string>>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    List<string> passline = new List<string>();

                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line != "")
                        {
                            passline.Add(line);
                        }
                        else
                        {
                            List<string> insert = new List<string>();

                            //use addrange to unlink insert from passline object, otherwise all items in inputList will be same (last passline)
                            insert.AddRange(passline);

                            inputList.Add(insert);
                            passline.Clear();
                        }
                    }
                    //bugfix do add last line, could cause a problem on day 4 :D
                    inputList.Add(passline);
                }
                return inputList;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<long> getInputLong(string filename )
        {
            //string filename = @"2020\Day01\input.txt";
            List<long> inputList = new List<long>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        inputList.Add(Convert.ToInt64(line));
                    }
                }
                return inputList;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        

        public List<long> getInputListLong(string filename )
        {
            //string filename = @"2020\Day01\input.txt";
            List<long> inputList = new List<long>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        inputList.Add(Convert.ToInt64(line));
                    }
                }
                return inputList;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public string getInputString(string filename)
        {
            string inputString = "";

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        inputString = inputString + line;
                    }
                }
                return inputString;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}