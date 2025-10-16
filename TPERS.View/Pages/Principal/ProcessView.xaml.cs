using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TPERS.View.Pages.Components.Modal;
using TPERS.View.Services.Icons;

namespace TPERS.View.Pages.Principal;

public partial class ProcessView : ContentPage
{
    public ObservableCollection<ToyotaProcess> processList { get; } = new ObservableCollection<ToyotaProcess>();

    public ICommand IconCustomizerPopup => new Command(IconPopup);
    public ICommand ProcessPopupCommand=> new Command<ToyotaProcess>(ProcessPopup);
    public ICommand SaveProcessCommand => new Command(SaveProcess);

    public ProcessView()
    {
        InitializeComponent();

        Icon.iconColor = Colors.White;
        Icon.iconImage = FASolid.Asterisk;

        BindingContext = this;
    }

    private async void IconPopup()
    {
        IPopupResult<IconPropertys> result = await this.ShowPopupAsync<IconPropertys>(new IconSelecterModal(Icon.iconImage,Icon.iconColor),PopupOptions.Empty,CancellationToken.None);
        if(result.WasDismissedByTappingOutsideOfPopup)
            return;

        Icon.iconColor = result.Result!.color;
        Icon.iconImage = result.Result.image;
    }
    private void SaveProcess()
    {
        string title = !string.IsNullOrEmpty(titleLabel.Text)? titleLabel.Text : "Sem nome";
        string description = !string.IsNullOrEmpty(descriptionLabel.Text) ? descriptionLabel.Text : "Sem descrição";

        processList.Add(new ToyotaProcess(title, description, new IconPropertys(Icon.iconImage, Icon.iconColor)));
    }
    private async void ProcessPopup(ToyotaProcess toyotaProcess)
    {
        var modal = new ProcessDescriptionModal(toyotaProcess);
        IPopupResult<ToyotaProcess> result = await this.ShowPopupAsync<ToyotaProcess>(modal, PopupOptions.Empty, CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup)
            return;
    }
}