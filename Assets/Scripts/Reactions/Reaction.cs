using Effects;

public class Reaction
{
    public string[] Elements;
    public string[] ResultElements;
    public IEffect[] Effects;

    public Reaction(string[] elements, string[] resultElements, IEffect[] effects)
    {
        Elements = elements;
        ResultElements = resultElements;
        Effects = effects;
    }
}