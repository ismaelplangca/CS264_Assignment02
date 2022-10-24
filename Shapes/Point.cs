public sealed class Point
{
    static int id;
    string X { get; set; }
    string Y { get; set; }
    // Regex here instead?
    public Point(string X, string Y)
    {
        id++;
        this.X = X;
        this.Y = Y;
    }
    public override string ToString()
    {
        return X + "," + Y;
    }
}