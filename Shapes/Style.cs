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
        var sb = new StringBuilder();
        foreach(var key in styles.Keys)
            sb.Append(key).Append(":").Append(styles[key]).Append(";\n");
        sb.Length--;
        return sb.ToString();
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach(var key in styles.Keys)
            if(styles[key].Length != 0 )
                sb.Append(key).Append(":").Append(styles[key]).Append(";");
        return sb.ToString();
    }
    public string ToSvgString()
    {
        var sb = new StringBuilder();
        sb.Append("style=\"");
        sb.Append(this.ToString() );
        sb.Append("\"");
        return sb.ToString();
    }
}