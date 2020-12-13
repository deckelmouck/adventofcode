using System;

namespace adventofcode
{
    class solutionday12 : solutionBase
    {
        class Ship
        {
            public int PositionX { get; set; }
            public int PositionY { get; set; }

            private int _direction;
            public int Direction
            {
                get { return _direction; }
                set { _direction = value % 360; }
            }
            

            public Ship()
            {
                PositionX = 0;
                PositionY = 0;
                Direction = 90;
            }

            public void Move(string instruction)
            {
                string action = instruction.Substring(0, 1);
                int value = Convert.ToInt32(instruction.Substring(1, instruction.Length-1));

                Console.WriteLine(string.Format("action: {0} - {1}", action, value.ToString()));

                int Movedirection = 0;

                switch (action)
                {
                    case "F":
                        Movedirection = Direction;
                        break;
                    case "N":
                        Movedirection = 0;
                        break;
                    case "S":
                        Movedirection = 180;
                        break;
                    case "E":
                        Movedirection = 90;
                        break;
                    case "W":
                        Movedirection = 270;
                        break;
                    case "L":
                        Direction -= value;
                        break;
                    case "R":
                        Direction += value;
                        break;
                    default:
                        Movedirection = Direction;
                        break;
                }

                if(action != "L" && action != "R")
                {
                    switch (Movedirection)
                    {
                        case 0:
                            PositionY += value;
                            break;
                        case 90:
                            PositionX += value;
                            break;
                        case 180:
                            PositionY -= value;
                            break;
                        case 270:
                            PositionX -= value;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(string.Format("after: {0} - {1} - d: {2}", PositionX, PositionY, Direction));
            }

        }

        public solutionday12(int part)
        {
            Ship ship = new Ship();
            var instructions = getInputLines(@"C:\dev\adventofcode\2020\Day12\input.txt");

            foreach (var instruction in instructions)
            {
                //Console.WriteLine(string.Format("{0}", instruction));
                ship.Move(instruction);
            }

            int ManhattenDistance = Math.Abs(ship.PositionX) + Math.Abs(ship.PositionY);
            Console.WriteLine(string.Format("ships position {0} . {1} = MD: {2}", ship.PositionX, ship.PositionY, ManhattenDistance));

        }
    }
}