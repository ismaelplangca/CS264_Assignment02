public abstract class Shape
{
    public Style style { get; }
    public Translate transforms { get; }
    public Shape()
    {
        style = Style.GetInstance();
        transforms = new();
    }
    // These methods are abstract in order for them 
    // to able to get the child class' fields
    // whilst they are Shapes
    public abstract void Edit(string input);
    public abstract string ToSvgString();
}