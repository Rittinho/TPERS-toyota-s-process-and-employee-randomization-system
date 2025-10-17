using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using TPERS.View.Services.Icons;

namespace TPERS.View.Pages.Components.Modal;

public partial class ProcessDescriptionModal : Popup<ToyotaProcess>
{
    public bool isEdit { get; set; } 
    public string title { get; set; } 
    public string description { get; set; }
    public IconPropertys icon { get; set; }

    public ICommand CloseCommand => new Command(CloseShow);

    public ProcessDescriptionModal(ToyotaProcess toyotaProcess)
	{
		InitializeComponent();

        title = toyotaProcess.title;
        description = toyotaProcess.description;
        icon = toyotaProcess.icon;

        BindingContext = this;
    }
    public async void CloseShow()
    {
        await CloseAsync();
    }
}