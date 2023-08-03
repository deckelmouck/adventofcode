using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode
{    
    class aocinstruction
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int Argument { get; set; }
        public bool Executed { get; set; }
    }

    static class Extensions
{
    public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
    {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }
}

    class solutionday08
    {
        public int Part { get; set; }
        public solutionday08(int part)
        {
            Part = part;
            var input = getInput();

            if(part == 1)
            {
                solve(input);
            }

            if(part == 2)
            {
                foreach (var item in input)
                {
                    if(item.Operation == "nop" || item.Operation == "jmp")
                    {
                        var inputcopy = getInput();
                        //inputcopy.AddRange(input);

                        switch (item.Operation)
                        {
                            case "jmp":
                                inputcopy.Find(i => i.Id == item.Id).Operation = "nop";
                                break;
                            case "nop":
                                inputcopy.Find(i => i.Id == item.Id).Operation = "jmp";
                                break;
                            default:
                                break;
                        }  

                        solve(inputcopy); 
                    }
                }

            }

        }

        public void solve(List<aocinstruction> input)
        {    
            int accumulator = 0;
            int step = 0;
            bool execute = true;
            string output = "error";

            while (execute)
            {
                aocinstruction nextInstruction = input[step];

                if(nextInstruction.Executed || step > input.Count)
                {
                    if(Part == 1)
                    {
                        output = "solved";
                    }

                    execute = false;
                    break;
                }

                input[step].Executed = true;

                switch (nextInstruction.Operation)
                {
                    case "acc":
                        accumulator += nextInstruction.Argument;
                        step++;
                        break;
                    case "jmp":
                        step += nextInstruction.Argument;
                        break;
                    case "nop":
                        step++;
                        break;
                    default:
                        break;
                }

                if(step >= input.Count)
                {
                    output = "solved";
                    break;
                }

            }

            if(Part == 1 || output == "solved")
            {
                Console.WriteLine(string.Format("accumulator value: {0} with {1}", accumulator.ToString(), output));
            }
        }
        
        public List<aocinstruction> getInput()
        {
            string filename = @"2020\Day08\input.txt";
            List<aocinstruction> inputList = new List<aocinstruction>();
            int count = 0;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        aocinstruction ins = new aocinstruction();

                        ins.Id = count;
                        ins.Operation = line.Split(" ")[0];
                        ins.Argument = Convert.ToInt32(line.Split(" ")[1]);
                        ins.Executed = false;

                        inputList.Add(ins);
                        count++;
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