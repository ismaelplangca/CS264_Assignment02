public class ShapeFactory
{
    public ShapeFactory() {}
    public Shape CreateShape(string[] inp)
    {
        switch(inp[0])
        {
            case "circle" :
                return new Circle(inp[1],inp[2],inp[3]);
            case "ellipse" :
                return new Ellipse(inp[1],inp[2],inp[3],inp[4]);
            case "line" :
                return new Line(inp[1],inp[2],inp[3],inp[4]);
            case "path" :
                return new Path(inp.Skip(1).Aggregate((a, b) => a + " " + b) );
            case "polygon" :
                return new Polygon(inp);
            case "polyline" :
                return new Polyline(inp);
            case "rectangle" :
                return new Rectangle(inp[1],inp[2],inp[3],inp[4]);
            default : throw new Exception("AHhh");
        }
    }
}