namespace Utilities.Models;

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string Color { get; set; }

    public Country()
    {
        Id = Common.GetUniqId();
        Name = string.Empty;
        Value = 0;
        Color = string.Empty;
    }
    public override string ToString()
    {
        return Name;
    }
}