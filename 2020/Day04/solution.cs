using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode
{
    class solutionday04
    {

        public solutionday04(int part)
        {

            if(part == 1)
            {

                List<string> input = getInput();
                List<passport> passports = new List<passport>();

                foreach (var item in input)
                {
                    Console.WriteLine(item);

                    string[] arrpassport = new string[item.Split(" ").Length];

                    for (int i = 0; i < item.Split(" ").Length; i++)
                    {
                        arrpassport[i] = item.Split(" ")[i];
                    }

                    passport pass = new passport();

                    foreach (var keyvalue in arrpassport)
                    {
                        string key = keyvalue.Split(":")[0];
                        string value = keyvalue.Split(":")[1];

                        switch (key)
                        {
                            case "byr":
                                pass.byr = Convert.ToInt32(value);
                                break;
                            case "iyr":
                                pass.iyr = Convert.ToInt32(value);
                                break;
                            case "eyr":
                                pass.eyr = Convert.ToInt32(value);
                                break;
                            case "hgt":
                                pass.hgt = value;
                                break;
                            case "hcl":
                                pass.hcl = value;
                                break;
                            case "ecl":
                                pass.ecl = value;
                                break;
                            case "pid":
                                pass.pid = value;
                                break;
                            case "cid":
                                pass.cid = Convert.ToInt32(value);
                                break;
                            default:
                                break;
                        }
                    }

                    passports.Add(pass);
                }

                Console.WriteLine(string.Format("{0} passports in list", passports.Count.ToString()));
                Console.WriteLine(string.Format("{0} passports are valid", (passports.FindAll(p => p.isValid() == true).Count).ToString()));

                
            }
            
        }



        public List<string> getInput()
        {
            string filename = @"2020\Day04\input.txt";

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