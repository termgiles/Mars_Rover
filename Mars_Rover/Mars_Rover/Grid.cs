using System.Diagnostics;
using System.Text;

namespace Mars_Rover
{
    public class Grid
    {
        public GridSize Size { get; private set; }
        public IGridElement[,] GridArray { get; private set; }
        public Dictionary<IGridElement, List<Position>> ElementHistory { get; private set; } = new Dictionary<IGridElement, List<Position>>();
        public GridSeeder Seeder;
        public Queue<string> Logs = new Queue<string>();
        private int tracksCleared = 0;

        private Grid(GridSize size)
        {
            Size = size;
            GridArray = new IGridElement[size.xAxis, size.yAxis];
            Seeder = new GridSeeder(this);
        }

        public static Grid GenerateGrid(GridSize size, Rover rover, Position roverPosition)
        {
            Grid newGrid = new Grid(size);
            newGrid.GridArray[roverPosition.x, roverPosition.y] = rover;
            rover.Orientation = roverPosition.orientation;
            newGrid.ElementHistory.Add(rover, new List<Position> { roverPosition });
            return newGrid;
        }

        public void LandCharacter(IGridCharacter character, Position characterPosition)
        {
            this.GridArray[characterPosition.x, characterPosition.y] = character;
            character.Orientation = characterPosition.orientation;
            this.ElementHistory.Add(character, new List<Position> { characterPosition });
        }

        public void InstructRover(List<Instruction> instructions, Rover rover)
        {
            if (!ElementHistory.Keys.Contains(rover))
            {
                throw new Exception("Rover not on grid");
            }
            foreach (Instruction i in instructions)
            {
                if (i == Instruction.L || i == Instruction.R)
                {
                    rover.Rotate(i);
                }
                if (i == Instruction.M)
                {
                    bool moved = RequestMove(rover);
                    if (moved)
                    {
                        if (rover.Orientation == Compass.N || rover.Orientation == Compass.S)
                            GridArray[(ElementHistory[rover][^2].x), (ElementHistory[rover][^2].y)] = new VerticalTrack();
                        if (rover.Orientation == Compass.E || rover.Orientation == Compass.W)
                            GridArray[(ElementHistory[rover][^2].x), (ElementHistory[rover][^2].y)] = new HorizontalTrack();
                    }
                    if (!moved)
                    {
                        Logs.Enqueue($"Rover {rover.Name} crashed at {ElementHistory[rover][^1].x} {ElementHistory[rover][^1].y}");
                        break;
                    }
                }
            }
        }


        public bool RequestMove(IGridCharacter character)
        {
            Position currentPosition = ElementHistory[character][^1];
            Compass currentOrientation = character.Orientation;
            Position newPosition = new Position();
            if (character.Orientation == Compass.N)
            {
                newPosition.x = currentPosition.x;
                newPosition.y = currentPosition.y + 1;
            }
            if (character.Orientation == Compass.E)
            {
                newPosition.x = currentPosition.x + 1;
                newPosition.y = currentPosition.y;
            }
            if (character.Orientation == Compass.S)
            {
                newPosition.x = currentPosition.x;
                newPosition.y = currentPosition.y - 1;
            }
            if (character.Orientation == Compass.W)
            {
                newPosition.x = currentPosition.x - 1;
                newPosition.y = currentPosition.y;
            }
            if (newPosition.x < 0 || newPosition.x >= this.Size.xAxis) return false;
            if (newPosition.y < 0 || newPosition.y >= this.Size.yAxis) return false;
            if (this.GridArray[newPosition.x, newPosition.y] != null && this.GridArray[newPosition.x, newPosition.y].IsSolid) return false;
            if (this.GridArray[newPosition.x, newPosition.y] != null && this.GridArray[newPosition.x, newPosition.y].Symbol == 'o') this.Seeder.CollectCoin(newPosition);
            this.ElementHistory[character].Add(newPosition);
            this.GridArray[newPosition.x, newPosition.y] = character;
            this.GridArray[currentPosition.x, currentPosition.y] = null;
            return true;
        }

        public void ClearTrack(Rover rover)
        {
            Position oldestUnclearedPosition = ElementHistory[rover][tracksCleared];
            if (this.GridArray[oldestUnclearedPosition.x, oldestUnclearedPosition.y] == null)
            {
                tracksCleared++;
                return;
            }
            if (this.GridArray[oldestUnclearedPosition.x, oldestUnclearedPosition.y].IsSolid)
            {
                return;
            }
            else
            {
                this.GridArray[oldestUnclearedPosition.x, oldestUnclearedPosition.y] = null;
                tracksCleared++;
            }
        }

        public string Display(bool? write)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Size.xAxis + 4; i++)
            {
                sb.Append('=');
            }
            sb.Append("\n");
            for (int i = this.Size.yAxis - 1; i >= 0; i--)
            {
                sb.Append("||");
                for (int j = 0; j < this.Size.xAxis; j++)
                {
                    if ((this.GridArray[j, i]) == null)
                    {
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append(this.GridArray[j, i].Symbol);
                    }
                }
                sb.Append("||");
                sb.Append("\n");
            }
            for (int i = 0; i < this.Size.xAxis + 4; i++)
            {
                sb.Append('=');
            }
            sb.Append("\n");

            if (write == true) Console.Write(sb.ToString());
            return sb.ToString();
        }

        public string DisplayUpperMessage(bool? write, Rover rover)
        {
            StringBuilder sb = new StringBuilder();
            string name = "Name " + rover.Name;
            string score = "score: " + Seeder.score;

            if (name.Length +  score.Length > this.Size.xAxis)
            {
                for(int i = 0; i < this.Size.xAxis - score.Length + 4; i++)
                {
                    sb.Append(' ');
                }
                sb.Append(score);
            }
            else
            {
                sb.Append(name);
                for (int i = 0; i < this.Size.xAxis - score.Length - name.Length + 4; i++)
                {
                    sb.Append(' ');
                }
                sb.Append(score);
            }
            sb.Append("\n");
            if (write == true) Console.Write(sb.ToString());
            return sb.ToString();
        }

        public string DisplayLowerMessage(bool? write)
        {
            StringBuilder sb = new StringBuilder();

            if(Logs.Count > 0)
            {
                sb.Append(Logs.Dequeue());
                sb.Append("\n");
            }

            if (write == true) Console.Write(sb.ToString());
            return sb.ToString();

        }
    }

}
