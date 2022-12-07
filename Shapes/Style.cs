using System.Text;
public class Style
{
    private Dictionary<string,string> styles = new() 
    {
        // Default styles
        {"fill",""},
        {"stroke",""},
        {"stroke-width",""}
    };
    public Style() {}
    public void EditProperty(string key, string value)
    {
        styles[key] = value;
    }
    public void RemoveStyle(string key)
    {
        styles.Remove(key);
    }
    public string ShowStyles()
    {
        return 
            String.Join(
                Environment.NewLine,
                styles.Select(kv => kv.Key + ":" + kv.Value + ";")
            );
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach(var kv in styles)
            if(kv.Value.Length != 0 )
                sb.Append(kv.Key + ":" + kv.Value + ";");
        return sb.ToString();
    }
    public string ToSvgString()
    {
        return "style=\"" + this.ToString() + "\"";
    }
}