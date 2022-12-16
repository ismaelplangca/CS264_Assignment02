public class Line : Shape
{
    private string X1;
    private string Y1;
    private string X2;
    private string Y2;

    public Line (string X1, string Y1, string X2, string Y2)
    : base()
    {
        this.X1 = X1;
        this.Y1 = Y1;
        this.X2 = X2;

        this.Y2 = Y2;
        style.EditProperty("stroke","black");
    }
    public override void Edit(string input)
    {
        var vals = input.Split(" ");
        X1 = vals[0];
        Y1 = vals[1];
        X2 = vals[2];
        Y2 = vals[3];
    }
    public override string ToString()
    {
        return "Line(X1=" + X1
            + ",Y1=" + Y1
            + ",X2=" + X2
            + ",Y2=" + Y2
            + ",Style=" + style
            + ",Transforms=" + transforms
            + ")";
    }
    public override string ToSvgString()
    {
        return "<line x1=\"" + X1
            + "\" y1=\"" + Y1
            + "\" x2=\"" + X2
            + "\" y2=\"" + Y2
            + "\" " + style.ToSvgString()
            + " " + transforms.ToSvgString()
            + "/>";
    }
}