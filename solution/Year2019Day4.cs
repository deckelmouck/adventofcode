using System;
using System.Collections.Generic;

namespace adventofcode
{
    public class code
    {
        public int value {get; set;}
        public int first {get; set;}
        public int second {get; set;}
        public int third {get; set;}
        public int fourth {get; set;}
        public int fifth {get; set;}
        public int sixth {get; set;}
        public bool hasdouble {get; set;}
    }

    public class year2019day4
    {
        public static List<code> codes = new List<code>();

        public static int codestart = 0;
        public static int codeend = 999999;

        public static void part1()
        {
            string line;
            string filepath = Environment.CurrentDirectory + @"\inputs\201904_1.txt";

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);

            while((line = file.ReadLine()) != null)
            {
                int pos = line.IndexOf("-");

                codestart = Convert.ToInt32(line.Substring(0,pos));
                codeend = Convert.ToInt32(line.Substring(pos+1, line.Length-pos-1));

                Console.WriteLine("{0}, {1}", codestart.ToString(), codeend.ToString());
            }

            for (int codevalue = codestart; codevalue <= codeend; codevalue ++)
            {
                code mycode = new code();

                mycode.value = codevalue;
                mycode.first = Convert.ToInt32((codevalue.ToString()).Substring(0, 1));
                mycode.second = Convert.ToInt32((codevalue.ToString()).Substring(1, 1));
                mycode.third = Convert.ToInt32((codevalue.ToString()).Substring(2, 1));
                mycode.fourth = Convert.ToInt32((codevalue.ToString()).Substring(3, 1));
                mycode.fifth = Convert.ToInt32((codevalue.ToString()).Substring(4, 1));
                mycode.sixth = Convert.ToInt32((codevalue.ToString()).Substring(5, 1));

                if(mycode.first == mycode.second | mycode.second == mycode.third
                    | mycode.third == mycode.fourth | mycode.fourth == mycode.fifth
                    | mycode.fifth == mycode.sixth)
                {
                    mycode.hasdouble = true;
                }
                else
                {
                    mycode.hasdouble = false;
                }

                if(mycode.hasdouble && mycode.first <= mycode.second && mycode.second <= mycode.third
                    && mycode.third <= mycode.fourth && mycode.fourth <= mycode.fifth
                    && mycode.fifth <= mycode.sixth)
                {
                    codes.Add(mycode);
                    Console.WriteLine("code {0} added to list", mycode.value.ToString());
                }
            }

            Console.WriteLine("list of codes contains {0} codes", codes.Count.ToString());
        }

    }

}