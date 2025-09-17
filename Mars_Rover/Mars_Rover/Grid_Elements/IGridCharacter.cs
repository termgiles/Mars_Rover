using Mars_Rover;
//will probably need to extend IGridElement as a IGridCharacter. It will add a compass.
//the current landRover and requesMove methods will be rewritten to implement this adn check 
public interface IGridCharacter : IGridElement 
{
    public Compass Orientation { get; set; } 
}