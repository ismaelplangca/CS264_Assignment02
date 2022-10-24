public class Circle : Shape 
{
    private string Cx;
    private string Cy;
    private string Radius;
    public Circle(string Cx, string Cy, string Radius) 
    : base()
    {
        this.Cx = Cx;
        this.Cy = Cy;
        this.Radius = Radius;
    }
    public override void Edit(string input)
    {
        var vals = input.Split(" ");
        Cx = vals[0];
        Cy = vals[1];
        Radius = vals[2];
    }
    public override string ToString()
    {
        return "Circle(Cx=" + Cx
            + ",Cy=" + Cy
            + ",Radius=" + Radius
            + ",Style=" + style.ToString()
            + ",Transforms=" + transforms.ToString()
            + ")";
    }
    public override string ToSvgString()
    {
        return "<circle cx=\"" + Cx
            + "\" cy=\"" + Cy
            + "\" r=\"" + Radius
            + "\" " + style.ToSvgString()
            + " " + transforms.ToSvgString()
            + "/>";
    }
}