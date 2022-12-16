using System.Text;
public class Style
{
    private Style() {}
    private static Style instance = null!;
    public static Style GetInstance()
    {
        if(instance == null)
        {
            instance = new Style();
        }
        return instance;
    }

    private Dictionary<string,string> styles = new()
    {
        {"fill",""},
        {"stroke",""},
        {"stroke-width",""}
    };

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
