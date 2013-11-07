/// <summary>
/// Represents a point in 2D René Descarte's coordinate system.
/// <param name="X">Point X-axis coordinate.</param>
/// <param name="Y">Point Y-axis coordinate.</param>
/// </summary>
internal class Point
{
    public Point(int x = 0, int y = 0)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }
}
