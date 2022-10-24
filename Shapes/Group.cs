using System.Text;
public class Group : Shape
{
    private List<Shape> list;
    public Group(List<Shape> list)
    : base()
    {
        this.list = list;
    }
    public override void Edit(string input) {}
    public List<Shape> GetShapes()
    {
        return list;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Group(Styles=" + style.ToString() + " Transforms=" + transforms.ToString() + "\n");
        for(int i = 0; i < list.Count; i++)
            sb.Append("\t" + i + "," + list[i] + "\n");
        sb.Append(")");
        return sb.ToString();
    }
    public override string ToSvgString()
    {
        var sb = new StringBuilder();
        sb.Append("<g " + style.ToSvgString() + " " + transforms.ToSvgString() + ">\n");
        foreach(var shape in list)
            sb.Append(shape.ToSvgString() + "\n");
        sb.Append("</g>");
        return sb.ToString();
    }
}