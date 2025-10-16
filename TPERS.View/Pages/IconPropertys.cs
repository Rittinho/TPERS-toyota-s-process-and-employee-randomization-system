namespace TPERS.View.Pages;
public class IconPropertys(string icon, Color color)
{
    public string image { get; set; } = icon;
    public Color color { get; set; } = color;
}