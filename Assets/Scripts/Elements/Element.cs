public class Element
{
    public string Name;
    public string Formula;
    public EnvironmentType EnvironmentType;

    public Element(string name, string formula, EnvironmentType environmentType)
    {
        Name = name;
        Formula = formula;
        EnvironmentType = environmentType;
    }
}