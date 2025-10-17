using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace TPERS.View.Pages.Components.Modal;

public partial class ConfirmActionModal : Popup<bool>
{
    public ICommand CancelCommand => new Command(Cancel);
    public ICommand ConfirmCommand => new Command(Confirm);
    public ConfirmActionModal(TokenAction tokenAction)
	{
		InitializeComponent();

        TitleLabel.Text = tokenAction.actionTitle;
        DescriptionLabel.Text = tokenAction.actionDescription;

        BackButton.IsVisible = !tokenAction.canConfirm;
        ActionButtons.IsVisible = tokenAction.canConfirm;

        BindingContext = this;
    }
    private async void Cancel() => await CloseAsync(false);
    private async void Confirm() => await CloseAsync(true);
}