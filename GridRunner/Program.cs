using System.Diagnostics;
using System.Drawing;
using System.Text;


public class GridRunner
{
    private Point fullGridSize;             //Full grid dimensions
    private int currentLocationX;           //Current X location in grid
    private int currentLocationY;           //Current Y location in grid
    private enumDirection currentDirection; //Enumerated direction being faced

    //Possible directions being faced
    public enum enumDirection
    {
        Left = 0,
        Up = 1,
        Right = 2,
        Down = 3
    }
    private GridRunner()
    {
        //
    }

    //Only constructor
    public GridRunner(int x, int y, string direction, Point gridSize)
    {
        currentLocationX = x;
        currentLocationY = y;
        currentDirection = (enumDirection)Enum.Parse(typeof(enumDirection), direction);
        fullGridSize = gridSize;
    }

    //By using L or R, update the current heading
    public void ChangeDirection(string turningDirection)
    {
        var change = turningDirection == "L" ? -1 : 1;
        var directionChange = (int)currentDirection + change;

        switch (directionChange)
        {
            case int n when n < 0:
                {
                    currentDirection = enumDirection.Down;
                    break;
                }
            case int n when n > 3:
                {
                    currentDirection = enumDirection.Left;
                    break;
                }
            default:
                {
                    currentDirection = (enumDirection)Enum.ToObject(typeof(enumDirection), directionChange);
                    break;
                }
        }
    }

    //Moving the robot
    public void MoveCell(string movement)
    {
        foreach (char c in movement)
        {
            //Debug.WriteLine(GetPosition());
            if (c == 'F')
            {
                //The character is movement
                //Move Left if X > 0
                if (currentDirection == enumDirection.Left && currentLocationX > 0)
                    currentLocationX--;
                //Move Right if X < the grid max X size
                if (currentDirection == enumDirection.Right && currentLocationX < fullGridSize.X)
                    currentLocationX++;
                //Move Up if Y < the grid max Y size
                if (currentDirection == enumDirection.Up && currentLocationY < fullGridSize.Y)
                    currentLocationY++;
                //Move Down if Y > 0
                if (currentDirection == enumDirection.Down && currentLocationY > 0)
                    currentLocationY--;
            }
            else
                ChangeDirection(c.ToString()); //The character is a turning instruction
        }
    }

    //Return the current location and heading
    public string GetPosition()
    {
        return $"{currentLocationX} {currentLocationY} {currentDirection}";
    }
}

class Program
{
    //Three lines of input are to be received: 
    //1) The first line of input is information pertaining to the size of the wall. 0 0 (bottom left) to x y
    //(Top right)
    //2) The second line of input is information about the spider’s current location and orientation.
    //This is made up of two integers and a word separated by spaces, corresponding to the x and
    //y coordinates and the spider's orientation. E.g. 4 10 Left 
    //3) The last line of input received is a series of instructions telling the spider how to explore the
    //wall.E.g.FLFLFRFFLF

    static void Main(string[] args)
    {
        //A bit optimistic in this case inputting the data, so assuming the user inputs all data corectly.
        Console.WriteLine("Please enter the size of the grid in X Y :");
        var grid = Console.ReadLine().Trim();
        Console.WriteLine("Please provide the current location and heading, i.e. 2 2 Up :");
        var location = Console.ReadLine().Trim();
        Console.WriteLine("Please provide movement string, ie L for turning Left, R turns right, and F for forward, concatenated :");
        var movement = Console.ReadLine().Trim();

        string[] splitString = grid.Split(' ');
        int gridX = Convert.ToInt32(splitString[0]);
        int gridY = Convert.ToInt32(splitString[1]);

        splitString = location.Split(' ');
        int posX = Convert.ToInt32(splitString[0]);
        int posY = Convert.ToInt32(splitString[1]);
        var posHead = splitString[2];

        Point gridSize = new Point(gridX, gridY);
        var gr = new GridRunner(posX, posY, posHead, gridSize);
        var returnValue = gr.GetPosition();
        Console.WriteLine(returnValue);
        Console.ReadLine();
    }

}
