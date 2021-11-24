namespace NasaRover.Domain.Business.Common;

/// <summary>
/// Location model
/// </summary>
public class Location
{
    /// <summary>
    /// The x coordinate of the location
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// The y coordinate of the location
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Initializes Location
    /// </summary>
    public Location(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }
}