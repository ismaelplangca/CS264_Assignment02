using System.Text;
public class Translate
{
    private Dictionary<string, string> transforms = new()
    {
        {"matrix",""},
        {"rotate",""},
        {"translate",""},
        {"scale",""},
        {"skewX",""},
        {"skewY",""}
    };
    public Translate() {}
    public void EditTranslation(string key, string value)
    {
        transforms[key] = value;
    }
    public string ShowTransforms()
    {
        var sb = new StringBuilder();
        foreach(var key in transforms.Keys)
            sb.Append(key + "(" + transforms[key] + ")\n");
        sb.Length--;
        return sb.ToString();
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach(var key in transforms.Keys)
            if(transforms[key].Length != 0)
                sb.Append(key + "(" + transforms[key] + ")");
        return sb.ToString();
    }
    public string ToSvgString()
    {
        var sb = new StringBuilder();
        sb.Append("transform=\"");
        sb.Append(this.ToString() );
        sb.Append("\"");
        return sb.ToString();
    }
}