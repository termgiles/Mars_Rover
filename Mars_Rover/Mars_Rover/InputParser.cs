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

        public static (bool isValid, List<Instruction> instructions) ParseKeyInput(string keyInput)
        {
            List<Instruction> output = new List<Instruction>();
            if(keyInput == "LeftArrow" || keyInput == "a" || keyInput == "A")
            {
                output.Add(Instruction.L);
                return (true, output);
            }
            if (keyInput == "RightArrow" || keyInput == "d" || keyInput == "D")
            {
                output.Add(Instruction.R);
                return (true, output);
            }
            if (keyInput == "UpArrow" || keyInput == "w" || keyInput == "W")
            {
                output.Add(Instruction.M);
                return (true, output);
            }
            if (keyInput == "DownArrow" || keyInput == "s" || keyInput == "S")
            {
                output.Add(Instruction.L);
                output.Add(Instruction.L);
                return (true, output);
            }
            return (false, output);
        }

        public static Position ParseRoverStartingPosition(string roverStartingPositon)
        {
            //[0-9]* [0-9]* [NESW]
            Position output = new Position();
            try
            {
                Regex positionFormat = new Regex("[0-9]* [0-9]* [NESW]");
                Regex positionFormatNoDirection = new Regex("[0-9]* [0-9]*");
                if (positionFormat.IsMatch(roverStartingPositon) || positionFormatNoDirection.IsMatch(roverStartingPositon))
                {
                    output.x = Int32.Parse(roverStartingPositon.Split(' ')[0]);
                    output.y = Int32.Parse(roverStartingPositon.Split(' ')[1]);
                    try
                    {
                        output.orientation = roverStartingPositon.Split(' ')[2].ToUpper() switch
                        {
                            "N" => Compass.N,
                            "E" => Compass.E,
                            "S" => Compass.S,
                            "W" => Compass.W
                        };
                    }
                    catch
                    {
                        output.orientation = Compass.N;
                    }
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
            string cleanedInputOne = input.Replace(',', ' ').Replace(':',' ').Replace(';',' ').Replace('-', ' ').Replace('(', ' ').Replace(')', ' ').Trim();
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
