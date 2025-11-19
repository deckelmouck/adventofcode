using System;

namespace adventofcode
{
    class solutionday13 : solutionBase
    {
        public solutionday13(int part)
        {
            var input = getInputLines(@"2020\Day13\input.txt");

            int timestamp = Convert.ToInt32(input[0]);            
            int _line = 99999;
            int _timestamp = 9999999;

            foreach (var item in input[1].Split(","))
            {
                if(item != "x")
                {
                    int line = Convert.ToInt32(item);
                    for (int i = timestamp; i < timestamp + line; i++)
                    {
                        if(i % line == 0)
                        {
                            Console.WriteLine(string.Format("{0}, {1}, {2}", timestamp.ToString(), i.ToString(), line.ToString()));
                            if(i < _timestamp)
                            {
                                _timestamp = i;
                                _line = line;
                            }
                        }
                    }

                }
            }
            int result = (_timestamp - timestamp) * _line;
            Console.WriteLine(string.Format("Line {0} at timestamp {1} - result = {2}", _line.ToString(), _timestamp.ToString(), result.ToString()));
        }
    }
}