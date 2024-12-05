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
    }
}
