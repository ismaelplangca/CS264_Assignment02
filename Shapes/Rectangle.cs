public class Rectangle : Shape
{
    private string X;
    private string Y;
    private string Width;
    private string Height;
    public Rectangle(string x, string y, string width, string height)
    : base()
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }
    public override void Edit(string input)
    {
        var vals = input.Split(" ");
        X = vals[0];
        Y = vals[1];
        Width = vals[2];
        Height = vals[3];
    }
    public override string ToString()
    {
        return "Rectangle(X=" + X
            + ",Y=" + Y
            + ",Width=" + Width
            + ",Height=" + Height
            + ",Style=" + style.ToString()
            + ",Transforms=" + transforms.ToString()
            + ")";
    }
    public override string ToSvgString()
    {
        return "<rect x=\"" + X
            + "\" y=\"" + Y
            + "\" width=\"" + Width
            + "\" height=\"" + Height
            + "\" " + style.ToSvgString()
            + " " + transforms.ToSvgString()
            + "/>";
    }
}