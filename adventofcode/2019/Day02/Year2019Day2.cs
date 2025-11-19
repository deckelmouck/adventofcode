using System;

namespace adventofcode
{
    public class year2019day2
    {
        public static string input {get; set;}

        public static void part1()
        {
            string line;
            string filepath = Environment.CurrentDirectory + @"\2019\Day02\201902_1.txt";

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            line = file.ReadLine();

            string[] opcodes;

            opcodes = line.Split(',');

            /*foreach(var word in opcodes)
            {
                Console.WriteLine(word);
            }*/

            int opcodeposition = 0;
            int opcode = 0;

            opcode = Convert.ToInt32(opcodes[opcodeposition]);

            opcodes[1] = "12";
            opcodes[2] = "2";

            while(opcode != 99)
            {
                int value1position = Convert.ToInt32(opcodes[opcodeposition + 1]);
                int value2position = Convert.ToInt32(opcodes[opcodeposition + 2]);
                int value3position = Convert.ToInt32(opcodes[opcodeposition + 3]);

                int value1 = Convert.ToInt32(opcodes[value1position]);
                int value2 = Convert.ToInt32(opcodes[value2position]);
                //int value3 = Convert.ToInt32(opcodes[value3position]);

                int solution = 0;

                if(opcode == 1)
                {
                    solution = value1 + value2;
                }
                else if(opcode == 2)
                {
                    solution = value1 * value2;
                }

                opcodes[value3position] = solution.ToString();
             
                opcodeposition = opcodeposition + 4;
                opcode = Convert.ToInt32(opcodes[opcodeposition]);
                
            }

            Console.WriteLine("Solution at position o is: {0}", opcodes[0]);
            
        }

        public static void part2()
        {
            string line;
            string filepath = Environment.CurrentDirectory + @"\2019\Day02\201902_1.txt";

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            line = file.ReadLine();

            //string[] opcodes;

            //string[] opcodesinput = line.Split(',');

            //int opcodeposition = 0;
            //int opcode = 0;

            //int noun = 0;
            //int verb = 0;
            int output = 19690720;

            //opcode = Convert.ToInt32(opcodes[opcodeposition]);

            //opcodes[1] = "12";
            //opcodes[2] = "2";

            for (int noun = 0; noun < 100; noun++)
            {
                //Console.WriteLine("try noun: {0}", noun.ToString());
                for (int verb = 0; verb < 100; verb++)
                {
                    //Console.WriteLine("try verb: {0}", verb.ToString());
                    
                    string[] opcodes = line.Split(',');
                    int opcodeposition = 0;
                    int opcode = Convert.ToInt32(opcodes[opcodeposition]);

                    opcodes[1] = noun.ToString();
                    opcodes[2] = verb.ToString();

                    while(opcode != 99)
                    {
                        int value1position = Convert.ToInt32(opcodes[opcodeposition + 1]);
                        int value2position = Convert.ToInt32(opcodes[opcodeposition + 2]);
                        int value3position = Convert.ToInt32(opcodes[opcodeposition + 3]);

                        int value1 = Convert.ToInt32(opcodes[value1position]);
                        int value2 = Convert.ToInt32(opcodes[value2position]);
                        //int value3 = Convert.ToInt32(opcodes[value3position]);

                        int solution = 0;

                        if(opcode == 1)
                        {
                            solution = value1 + value2;
                        }
                        else if(opcode == 2)
                        {
                            solution = value1 * value2;
                        }

                        if(solution == output)
                        {
                            Console.WriteLine("noun = {0} and verb = {1}", noun.ToString(), verb.ToString());
                            Console.WriteLine((100 * noun + verb).ToString());
                        }
                        opcodes[value3position] = solution.ToString();
                        
                        opcodeposition = opcodeposition + 4;
                        opcode = Convert.ToInt32(opcodes[opcodeposition]);
                        
                    }                    
                }
            }         
        }

    }
}