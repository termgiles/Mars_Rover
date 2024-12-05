using System.Reflection.Metadata.Ecma335;
using Mars_Rover;
using FluentAssertions;

namespace Mars_Rover_Tests
{
    public class Tests
    {

        [Test]
        public void InstructionParse_ShouldParseNeatInputs()
        {
            string input = "LMMMRMMMLR";
            List<Instruction> expectdOutput = new List<Instruction> { Instruction.L, Instruction.M, Instruction.M, Instruction.M, Instruction.R, Instruction.M, Instruction.M, Instruction.M, Instruction.L, Instruction.R };


            InputParser.ParseInstruction(input).Should().BeEquivalentTo(expectdOutput);
        }

        [Test]
        public void InstructionParse_ShouldParseMessyInputs()
        {
            string input = "wordIJ3-';mMLMRoo9 dfdsM";
            List<Instruction> expectdOutput = new List<Instruction> {Instruction.R,Instruction.M, Instruction.M, Instruction.L, Instruction.M, Instruction.R, Instruction.M};


            InputParser.ParseInstruction(input).Should().BeEquivalentTo(expectdOutput);
        }

        [Test]
        public void InstructionParse_ShouldThrowNoInput()
        {
            string input = "noinputsinthis";

            try
            {
                InputParser.ParseInstruction(input);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                if (ex.Message == "no recognised rover inputs")
                {
                    Assert.Pass();
                }
                else
                {
                   Assert.Fail();
                }

            }
        }
    }
}