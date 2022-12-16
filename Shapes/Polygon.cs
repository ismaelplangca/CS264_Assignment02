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
        return 
            "Polygon(Points=" +
            String.Join(",", list.Select(a => "(" + a + ")") ) +
            ",Style=" + style + ",Transforms=" + transforms + ")"; 
    }
    public override string ToSvgString()
    {
        return
            "<polygon points=\"" +
            String.Join(" ", list) + "\" "
            + style.ToSvgString() + " " + transforms.ToSvgString() + "/>";
    }
}