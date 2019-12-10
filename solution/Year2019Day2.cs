using System;

namespace adventofcode
{
    public class year2019day2
    {
        public static string input {get; set;}

        public static void part1()
        {
            string line;
            string filepath = Environment.CurrentDirectory + @"\inputs\201902_1.txt";

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

    }
}