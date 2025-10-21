namespace TPERS.View.Pages;
public class ToyotaProcess
{
    public string title { get; set; } 

    public string description { get; set; }

    public IconPropertys icon { get; set; }

    public ToyotaProcess(string title, string description, IconPropertys iconPropertys)
    {
        this.title = !string.IsNullOrEmpty(title) ? title : "Sem nome";
        this.description = !string.IsNullOrEmpty(description) ? description : "Sem descrição";

        icon = iconPropertys;
    }

}
