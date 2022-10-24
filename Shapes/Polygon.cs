using System.Text;
using System.Text.RegularExpressions;
public class Polygon : Shape
{
    private List<Point> list;
    public Polygon()
    : base()
    {
        list = new();
    }
    public Polygon(string[] array)
    : base()
    {
        list = new();
        var regex = new Regex("[0-9]+,[0-9]+");
        for(int i = 1; i < array.Length; i++)
        {
            if(regex.IsMatch(array[i]) )
            {
                var xy = array[i].Split(",");
                list.Add(new Point(xy[0],xy[1]) );
            }
        }
    }
    public Polygon AddPoint(string x, string y)
    {
        list.Add(new Point(x ,y) );
        return this;
    }
    public override void Edit(string input)
    {
        var regex = new Regex("[0-9]+,[0-9]+");
        list.Clear();
        list = input.Split(" ")
            .Where(xy => regex.IsMatch(xy) )
            .Select(xy => xy.Split(",") )
            .Select(vals => new Point(vals[0],vals[1]) )
            .ToList();
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Polygon(Points=");
        foreach(var p in list)
            sb.Append("(" + p + "),");
        sb.Append("Style=" + style.ToString() )
        .Append(",Transforms=" + transforms.ToString()  + ")");
        return sb.ToString();
    }
    public override string ToSvgString()
    {
        var sb = new StringBuilder();
        sb.Append("<polygon points=\"");
        foreach(var p in list)
            sb.Append(p + " ");
        sb.Length--;
        sb.Append("\" " + style.ToSvgString() )
        .Append(" " + transforms.ToSvgString()  + "/>");
        return sb.ToString();
    }
}