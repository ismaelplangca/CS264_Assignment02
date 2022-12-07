using System.Text;
public class Path : Shape
{
    private string path;
    public Path()
    {
        path="";
    } 
    public Path(string path)
    {
        this.path = path;
    }
    public override void Edit(string input)
    {
        path = input;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Path(Path=\"" + path + "\"")
        .Append(",Style=" + style)
        .Append(",Transforms=" + transforms + ")");
        return sb.ToString();
    }
    public override string ToSvgString()
    {
        return "<path d=\"" + path + "\" " + style.ToSvgString() +" " + transforms.ToSvgString() + "/>";
    }
}