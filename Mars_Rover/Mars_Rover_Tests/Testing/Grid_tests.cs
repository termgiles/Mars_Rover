using FluentAssertions;
using Mars_Rover;

namespace Mars_Rover_Tests
{
    public class Grid_tests 
    {
        [Test]
        public void Test_Rover_CantMoveOffGridN()
        {
            Rover testRoverN = new Rover("testRover", Compass.N);
            GridSize testSize = InputParser.StringToGridSize("60 20");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("30 19 N");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverN, testStartingPosition);
            bool expectedResult = false;

            bool output = testGrid.RequestMove(testRoverN);
            output.Should().Be(expectedResult);
        }
        [Test]
        public void Test_Rover_CantMoveOffGridE()
        {
            Rover testRoverE = new Rover("testRover", Compass.E);
            GridSize testSize = InputParser.StringToGridSize("60 20");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("59 10 E");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverE, testStartingPosition);
            bool expectedResult = false;

            bool output = testGrid.RequestMove(testRoverE);
            output.Should().Be(expectedResult);
        }
        [Test]
        public void Test_Rover_CantMoveOffGridS()
        {
            Rover testRoverS = new Rover("testRover", Compass.S);
            GridSize testSize = InputParser.StringToGridSize("60 20");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("30 0 S");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverS, testStartingPosition);
            bool expectedResult = false;

            bool output = testGrid.RequestMove(testRoverS);
            output.Should().Be(expectedResult);
        }
        [Test]
        public void Test_Rover_CantMoveOffGridW()
        {
            Rover testRoverW = new Rover("testRover", Compass.W);
            GridSize testSize = InputParser.StringToGridSize("60 20");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("0 10 W");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverW, testStartingPosition);
            bool expectedResult = false;

            bool output = testGrid.RequestMove(testRoverW);
            output.Should().Be(expectedResult);
        }
        [Test]
        public void Test_Rover_CanMoveToEmpty()
        {
            Rover testRoverW = new Rover("testRover", Compass.E);
            GridSize testSize = InputParser.StringToGridSize("100 100");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("40 41 W");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverW, testStartingPosition);
            bool expectedResult = true;

            bool output = testGrid.RequestMove(testRoverW);
            output.Should().Be(expectedResult);
        }
        [Test]
        public void Test_Rover_CantMoveThroughSolid()
        {
            Rover testRoverW = new Rover("testRover", Compass.E);
            GridSize testSize = InputParser.StringToGridSize("100 100");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("40 41 W");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverW, testStartingPosition);
            testGrid.GridArray[39, 41] = new Rock();
            bool expectedResult = false;

            bool output = testGrid.RequestMove(testRoverW);
            output.Should().Be(expectedResult);
        }
        [Test]
        public void Test_Rover_CanMoveToUnSolid()
        {
            Rover testRoverW = new Rover("testRover", Compass.E);
            GridSize testSize = InputParser.StringToGridSize("100 100");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("40 41 W");
            Grid testGrid = Grid.GenerateGrid(testSize, testRoverW, testStartingPosition);
            testGrid.GridArray[39, 41] = new VerticalTrack();
            bool expectedResult = true;

            bool output = testGrid.RequestMove(testRoverW);
            output.Should().Be(expectedResult);
        }

    }
}