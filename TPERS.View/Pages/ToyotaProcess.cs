namespace TPERS.View.Pages;
public class ToyotaProcess(string title, string description, IconPropertys iconPropertys)
{
    public string title { get; set; } = title;

    public string description { get; set; } = description;

    public IconPropertys icon { get; set; } = iconPropertys;

}
