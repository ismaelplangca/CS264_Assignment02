public class Ellipse : Shape
{
    private string Cx;
    private string Cy;
    private string Rx;
    private string Ry;
    public Ellipse(string Cx, string Cy, string Rx, string Ry)
    : base()
    {
        this.Cx = Cx;
        this.Cy = Cy;
        this.Rx = Rx;
        this.Ry = Ry;
    }
    public override void Edit(string input)
    {
        var vals = input.Split(" ");
        Cx = vals[0];
        Cy = vals[1];
        Rx = vals[2];
        Ry = vals[3];
    }
    public override string ToString()
    {
        return "Ellipse(Cx=" + Cx
            + ",Cy=" + Cy
            + ",Rx=" + Rx
            + ",Ry=" + Ry
            + ",Style=" + style
            + ",Transforms=" + transforms
            + ")";
    }
    public override string ToSvgString()
    {
        return "<ellipse cx=\"" + Cx 
            + "\" cy=\"" + Cy
            + "\" rx=\"" + Rx
            + "\" ry=\"" + Ry
            + "\" " + style.ToSvgString()
            + " " + transforms.ToSvgString()
            + "/>";
    }
}