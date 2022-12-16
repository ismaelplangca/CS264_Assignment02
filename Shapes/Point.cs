public sealed class Point
{
    string X { get; set; }
    string Y { get; set; }
    // Regex here instead?
    public Point(string X, string Y)
    {
        this.X = X;
        this.Y = Y;
    }
    public override string ToString()
    {
        return X + "," + Y;
    }
}