using System.Text;
public class Canvas
{
    // Z-Index is list index
    private List<Shape> list;
    private string svgStartTag;
    public Canvas()
    {
        list = new();
        svgStartTag = "<svg>";
    }
    public Canvas(string height, string width)
    {
        list = new();
        svgStartTag = "<svg height=\"" + height + "\" width=\"" + width + "\">";
    }
    public int ShapeCount()
    {
        return list.Count;
    }
    public Canvas AddShape(Shape s)
    {
        list.Add(s);
        return this;
    }
    public Shape GetShape(int index)
    {
        return list[index];
    }
    public bool ReplaceShape(int index, Shape s)
    {
        list[index] = s;
        return true;
    }
    public void SwapShape(int i1, int i2)
    {
        if(i1 == i2) 
            return;

        var temp = list[i1];
        list[i1] = list[i2];
        list[i2] = temp;
    }
    public void RemoveShape(int index)
    {
        if(list.Count == 0)
        {
            Console.WriteLine("No Shapes Yet!");
            return;
        }
        list.RemoveAt(index);
    }
    public void GroupShapes(int[] shapeIndexes)
    {
        var group = new List<Shape>();
        var array = list.ToArray();
        foreach(var i in shapeIndexes)
        {
            group.Add(list[i]);
            array[i] = null!;
        }
        list = array.Where(x => x is not null).ToList();
        list.Add(new Group(group) );
    }
    public void UngroupShapes(int index)
    {
        if(list[index] is not Group)
        {
            Console.WriteLine("This Is Not A Group!");
            return;
        }
        var ungrouped = (Group)list[index];
        list.RemoveAt(index);
        list.AddRange(ungrouped.GetShapes() );
    }
    public string Contents()
    {
        if(list.Count == 0)
            return "No Shapes Yet!";
            
        var str = new StringBuilder();
        for(int i = 0; i < list.Count; i++)
            str.Append("Index=").Append(i).Append(",").Append(list[i]).Append("\n");
        str.Length--;
        return str.ToString();
    }
    public string ToSvgString()
    {
        var sb = new StringBuilder();
        sb.Append(svgStartTag + "\n");
        foreach(var shape in list)
            sb.Append(shape.ToSvgString() + "\n");
        sb.Append("</svg>");
        return sb.ToString();
    }
    public void ExportToSvg(string filename)
    {
        using(var sw = new StreamWriter(filename) )
            sw.Write(ToSvgString() );
    }
}