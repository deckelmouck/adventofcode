using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode
{
    class solutionday05
    {
        public solutionday05(int part)
        {
            List<string> input = getInput();
            List<int> boardingIds = new List<int>();

            Console.WriteLine(string.Format("input has {0} items", input.Count.ToString()));

            foreach (var item in input)
            {
                //Console.WriteLine(item);
                boardingIds.Add(getSeatId(item));
            }

            if(part == 1)
            {
                Console.WriteLine(string.Format("greatest boarding id is: {0}", boardingIds.Max().ToString()));
            }

            if(part == 2)
            {
                boardingIds.Sort();

                int minId = boardingIds.Min();
                int maxId = boardingIds.Max();

                for (int i = minId; i < maxId; i++)
                {
                    if(!boardingIds.Contains(i))
                    {
                        Console.WriteLine(string.Format("not in boardingIds: {0}", i.ToString()));
                    }
                }
            }
        }

        public int getSeatId(string boarding)
        {
            int ret = 0;

            string rowstring = boarding.Substring(0,7);
            string seatstring = boarding.Substring(7,3);

            rowstring = rowstring.Replace("B","1").Replace("F", "0");
            seatstring = seatstring.Replace("R", "1").Replace("L","0");

            //Console.WriteLine(string.Format("row: {0}, seat: {1}", rowstring, seatstring));
            //Console.WriteLine(string.Format("row: {0}, seat: {1}, seatid: {2}",  Convert.ToInt32(rowstring, 2).ToString(), Convert.ToInt32(seatstring, 2).ToString(), (Convert.ToInt32(rowstring, 2) * 8) + (Convert.ToInt32(seatstring, 2))));

            ret = (Convert.ToInt32(rowstring, 2) * 8) + (Convert.ToInt32(seatstring, 2));

            return ret;
        }



        public List<string> getInput()
        {
            string filename = @"2020/Day05/input.txt";

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