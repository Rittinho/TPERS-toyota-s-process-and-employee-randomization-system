using CommunityToolkit.Maui.Views;
namespace TPERS.View.Pages.Components.Modal;

public partial class IconSelecter : Popup
{
    private Button lastButton;
    private Button lastColor;

    public string SelectedIcon { get; private set; }
    public Color SelectedColor { get; private set; }

    public IconSelecter()
    {
        InitializeComponent();
    }

    private void SelectIcon(object sender, EventArgs e)
    {
        if (sender is not Button button)
            return;

        if (lastButton is not null)
            lastButton.BackgroundColor = Color.FromArgb("282828");

        button.BackgroundColor = Color.FromArgb("404040");
        lastButton = button;
        SelectedIcon = button.Text;
    }

    private void SelectColor(object sender, EventArgs e)
    {
        if (sender is not Button button)
            return;

        if (lastColor is not null)
            lastColor.BorderWidth = 0;

        button.BorderWidth = 4;
        button.BorderColor = Colors.White;
        lastColor = button;
        SelectedColor = button.BackgroundColor;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // await CloseAsync(new IconProperty(SelectedIcon,SelectedColor));
    }
}
