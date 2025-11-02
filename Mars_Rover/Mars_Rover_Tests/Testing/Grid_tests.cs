using FluentAssertions;
using Mars_Rover;
using System.Diagnostics;

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
        [Test]
        public void Test_FindRelativeCoords_ReturnsFourCorrectLocations()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.S, x = 5, y = 5 });

            List<(int, int)> expectedOutput = [(7, 8), (9, 8), (8, 7), (8, 9)];

            var output = testGrid.FindRelativeCoords((8, 8), (testStartingPosition.x, testStartingPosition.y));

            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_FindRelativeCoords_IgnoresSolids()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.S, x = 5, y = 5 });
            testGrid.GridArray[8, 9] = new Rock();

            List<(int, int)> expectedOutput = [(7, 8), (9, 8), (8, 7)];

            var output = testGrid.FindRelativeCoords((8, 8), (testStartingPosition.x, testStartingPosition.y));

            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_FindRelativeCoords_IgnoresGridEdge()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 4, y = 4 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.S, x = 9, y = 9 });

            List<(int, int)> expectedOutput = [(9, 8), (8, 9)];

            var output = testGrid.FindRelativeCoords((9, 9), (testStartingPosition.x, testStartingPosition.y));

            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_FindRelativeCoords_IncludesRover()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.S, x = 7, y = 8 });

            List<(int, int)> expectedOutput = [(8, 8), (6, 8), (7, 9), (7, 7)];

            var output = testGrid.FindRelativeCoords((7, 8), (testStartingPosition.x, testStartingPosition.y));

            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_FindRelativeCoords_AvoidsEnemy()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.S, x = 4, y = 4 });

            List<(int, int)> expectedOutput = [(3, 5), (3, 3), (2, 4)];

            var output = testGrid.FindRelativeCoords((3, 4), (testStartingPosition.x, testStartingPosition.y));

            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_DijkstraRover_MovesInLine()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.N, x = 8, y = 4 });

            List<Instruction> expectedOutput = [Instruction.M, Instruction.M, Instruction.M, Instruction.M];

            var output = testGrid.DijkstraRover(testEnemy, testRover);
            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_DijkstraRover_Turns()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            Enemy testEnemy = new Enemy(Compass.W);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.W, x = 8, y = 4 });

            List<Instruction> expectedOutput = [Instruction.R, Instruction.M, Instruction.M, Instruction.M, Instruction.M];

            var output = testGrid.DijkstraRover(testEnemy, testRover);
            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
        [Test]
        public void Test_DijkstraRover_AvoidsRock()
        {
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = new GridSize(10, 10);
            Position testStartingPosition = new Position() { orientation = Compass.N, x = 8, y = 8 };
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            testGrid.GridArray[8, 5] = new Rock();
            Enemy testEnemy = new Enemy(Compass.N);
            testGrid.LandCharacter(testEnemy, new Position() { orientation = Compass.N, x = 8, y = 4 });

            List<Instruction> expectedOutput = [Instruction.L, Instruction.M, Instruction.R, Instruction.M, Instruction.M, Instruction.M, Instruction.M, Instruction.R, Instruction.M];

            var output = testGrid.DijkstraRover(testEnemy, testRover);
            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
    }
}