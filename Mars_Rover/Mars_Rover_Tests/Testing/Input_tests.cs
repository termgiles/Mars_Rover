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

        [Test]
        public void ParseRoverStartingPosition_ShouldParseValidString()
        {
            string input = "15 16 W";
            Position expectedOutput = new Position();
            expectedOutput.x = 15;
            expectedOutput.y = 16;
            expectedOutput.orientation = Compass.W;

            Position output = InputParser.ParseRoverStartingPosition(input);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ParseRoverStartingPosition_ShouldParseTuple()
        {
            (int, int, Compass) input = (43, 55, Compass.N);
            Position expectedOutput = new Position();
            expectedOutput.x = 43;
            expectedOutput.y = 55;
            expectedOutput.orientation = Compass.N;

            Position output = InputParser.ParseRoverStartingPosition(input);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ParseGridSize_ShouldParseVarietyOfSeparators()
        {
            string comma = "5,6";
            string colon = "5:6";
            string semicolon = "5;6";
            string hyphen = "5-6";
            string hyphenWithSpaces = "5 - 6";
            string mix = " 5: - 6:";
            string space = "5 6";
            string brackets = "(5, 6)";

            GridSize expectedOutput = new GridSize(5, 6);

            InputParser.StringToGridSize(comma).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(colon).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(semicolon).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(hyphen).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(hyphenWithSpaces).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(mix).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(space).Should().BeEquivalentTo(expectedOutput);
            InputParser.StringToGridSize(brackets).Should().BeEquivalentTo(expectedOutput);
        }

    }
}