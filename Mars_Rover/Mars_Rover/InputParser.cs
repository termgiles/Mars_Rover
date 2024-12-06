using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Mars_Rover
{
    public class InputParser 
    {
        public static List<Instruction> ParseInstruction(string instructions)
        {
            List<Instruction> output = new List<Instruction>();
            char[] roverInstructions = new char[3] { 'L', 'R', 'M' };
            try
            {
                foreach (char c in instructions.ToUpper())
                {
                    if (roverInstructions.Contains(c))
                    {
                        switch(c)
                        {
                            case 'L':
                                output.Add(Instruction.L);
                                break;
                            case 'R':
                                output.Add(Instruction.R);
                                break;
                            case 'M':
                                output.Add(Instruction.M);
                                break;
                        };
                    }
                }
                if (output.Count > 0)
                {
                    return output;
                }
                else
                {
                    throw new Exception("no recognised rover inputs");
                }
            }
            catch
            {
                throw new Exception("no recognised rover inputs");
            }
        }

        public static Position ParseRoverStartingPosition(string roverStartingPositon)
        {
            //[0-9]* [0-9]* [NESW]
            Position output = new Position();
            try
            {
                Regex positionFormat = new Regex("[0-9] * [0-9] * [NESW]");
                if (positionFormat.IsMatch(roverStartingPositon))
                {
                    output.x = Int32.Parse(roverStartingPositon.Split(' ')[0]);
                    output.y = Int32.Parse(roverStartingPositon.Split(' ')[1]);
                    output.orientation = roverStartingPositon.Split(' ')[2] switch
                    {
                        "N" => Compass.N,
                        "E" => Compass.E,
                        "S" => Compass.S,
                        "W" => Compass.W
                    };
                }
                else
                {
                    throw new Exception("not regex match");
                }
                return output;
            }
            catch
            {
                throw new Exception("faulty position coordinates or orientation"); 
            }
        }
        public static Position ParseRoverStartingPosition((int,int,Compass) input)
        {
            Position output = new Position();
            output.x = input.Item1;
            output.y = input.Item2;
            output.orientation = input.Item3;
            return output;

        }
        
        public static GridSize StringToGridSize(string input)
        {
            char[] separatorChars = new char[] { ',','-',':',';' };
            string cleanedInputOne = input.Replace(',', ' ').Replace(':',' ').Replace(';',' ').Replace('-', ' ').Trim();
            string cleanedInputTwo = Regex.Replace(cleanedInputOne, "[ ]+", " ");
            string[] coordinates = cleanedInputTwo.Split(' ');
            try
            {
                return new GridSize(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }
            catch
            {
                throw new Exception("faulty grid coordinates");
            }
        }
    }
}
