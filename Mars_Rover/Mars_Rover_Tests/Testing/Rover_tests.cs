using Mars_Rover;
using FluentAssertions;
namespace Mars_Rover_Tests
{
    public class Rover_tests 
    {
        [Test]
        public void RoverRotate_RotatesRoverRight()
        {
            Rover testRover = new Rover("testRover", Compass.W);
            Compass expectedOutput = Compass.N;

            testRover.Rotate(Instruction.R);
            testRover.Orientation.Should().Be(expectedOutput);
        }

        [Test]
        public void RoverRotate_RotatesRoverRightEast()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            Compass expectedOutput = Compass.E;

            testRover.Rotate(Instruction.R);
            testRover.Orientation.Should().Be(expectedOutput);
        }

        [Test]
        public void RoverRotate_RotatesRoverLeft()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            Compass expectedOutput = Compass.W;

            testRover.Rotate(Instruction.L);
            testRover.Orientation.Should().Be(expectedOutput);
        }

        [Test]
        public void RoverRotate_Move_DoesntRotateRover()
        {
            Rover testRover = new Rover("testRover", Compass.S);
            Compass expectedOutput = Compass.S;

            testRover.Rotate(Instruction.M);
            testRover.Orientation.Should().Be(expectedOutput);
        }

    }
}