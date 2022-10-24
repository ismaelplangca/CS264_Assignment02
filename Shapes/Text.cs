using System.Text;
public class Text : Shape
{
    private string x;
    private string y;
    private string text;
    public Text(string x, string y, string text)
    : base()
    {
        this.x = x;
        this.y = y;
        this.text = text;
    }
    public override void Edit(string text)
    {
        var values = text.Split(" ");
        this.x = values[0];
        this.y = values[1];
        try { this.text = values[2];
        } catch(Exception) {}
    }
    public override string ToSvgString()
    {
        var sb = new StringBuilder();

        sb.Append("<text x=").Append(x)
        .Append(" y=").Append(y)
        .Append(style.ToSvgString() )
        .Append(">")
        .Append(text)
        .Append("</text>");

        return sb.ToString();
    }
}