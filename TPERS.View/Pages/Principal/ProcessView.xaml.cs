using CommunityToolkit.Maui.Extensions;
using TPERS.View.Pages.Components.Modal;

namespace TPERS.View.Pages.Principal;

public partial class ProcessView : ContentPage
{
	public ProcessView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var result = this.ShowPopupAsync(new IconSelecterModal());
        
    }
}