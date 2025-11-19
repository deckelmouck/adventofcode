using System;

namespace adventofcode
{
    class solutionday10 : solutionBase
    {
        public solutionday10(int part)
        {
            var input = getInputLong(@"2020\Day10\Input.txt");

            input.Sort();

            int pos = 0;

            int onestep = 0;
            int threestep = 1;

            foreach (var item in input)
            {
                if(pos == 0 && item == 1)
                {
                    onestep++;
                }
                if(pos > 0 && item == input[pos - 1] + 1)
                {
                    onestep++;
                }             
                else if(pos > 0 && item == input[pos - 1] + 3)
                {
                    threestep++;
                } 
                pos++;
                Console.WriteLine(string.Format("item: {0}, onestep: {1}, threestep: {2}", item.ToString(), onestep.ToString(), threestep.ToString()));
            }
            Console.WriteLine(string.Format("output: onestep: {0}, threestep {1} = {2}", onestep.ToString(), threestep.ToString(), (onestep * threestep).ToString()));
        }
    }
}