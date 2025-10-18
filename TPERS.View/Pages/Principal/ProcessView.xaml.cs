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
    public ObservableCollection<ToyotaProcess> processList { get; } = [];

    private ToyotaProcess? currentProcessInEdit;

    public ICommand UpdateIconProcessCommand => new Command(UpdateIcon);
    public ICommand SowProcessCommand => new Command<ToyotaProcess>(SowProcess);
    public ICommand CreateProcessCommand => new Command(CreateProcess);
    public ICommand UpdateProcessCommand => new Command<ToyotaProcess>(UpdateProcess);
    public ICommand SaveUpdateProcessCommand => new Command(SaveUpdate);
    public ICommand CancelUpdateProcessCommand => new Command(CancelUpdateProcess);
    public ICommand DeleteProcessCommand => new Command<ToyotaProcess>(DeleteProcess);

    public ProcessView()
    {
        InitializeComponent();

        ProcessIcon.iconColor = Colors.White;
        ProcessIcon.iconImage = FASolid.Asterisk;

        BindingContext = this;
    }

    private async void UpdateIcon()
    {
        IPopupResult<IconPropertys> result = await this.ShowPopupAsync<IconPropertys>(new IconSelecterModal(ProcessIcon.iconImage, ProcessIcon.iconColor),PopupOptions.Empty,CancellationToken.None);

        if(result.WasDismissedByTappingOutsideOfPopup)
            return;

        if (result.Result == null)
            return;

        ProcessIcon.iconColor = result.Result!.color;
        ProcessIcon.iconImage = result.Result.image;
    }

    private async void CreateProcess()
    {
        string title = !string.IsNullOrEmpty(ProcessTitleLabel.Text)? ProcessTitleLabel.Text : "Sem nome";
        string description = !string.IsNullOrEmpty(ProcessDescriptionLabel.Text) ? ProcessDescriptionLabel.Text : "Sem descrição";

        if (VerifyIfThere())
        {
            IPopupResult<bool> warningresult = await this.ShowPopupAsync<bool>(new ConfirmActionModal(
                      new TokenAction(
                          "Processo existente",
                          "Verifique os existentes",
                          false)),
                          PopupOptions.Empty,
                          CancellationToken.None);

            if (warningresult.WasDismissedByTappingOutsideOfPopup || !warningresult.Result!)
                return;
        }

        processList.Add(new ToyotaProcess(title, description, new IconPropertys(ProcessIcon.iconImage, ProcessIcon.iconColor)));

        ClearFilds();
    }

    private async void SowProcess(ToyotaProcess toyotaProcess)
    {
        var modal = new ProcessDescriptionModal(toyotaProcess);
        IPopupResult<ToyotaProcess> result = await this.ShowPopupAsync<ToyotaProcess>(modal, PopupOptions.Empty, CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup)
            return;
    }

    private async void DeleteProcess(ToyotaProcess toyotaProcess)
    {
        IPopupResult<bool> result = await this.ShowPopupAsync<bool>(new ConfirmActionModal(
            new TokenAction(
                "Excluir processo?",
                "Essa ação não tem volta!",
                true)), 
                PopupOptions.Empty, 
                CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return;

        processList.Remove(toyotaProcess);
    }

    public void UpdateProcess(ToyotaProcess toyotaProcess)
    {
        currentProcessInEdit = toyotaProcess;

        CreateButton.IsVisible = false;
        EditButtons.IsVisible = true;
        TitleLabel.Text = "Editar Processo";

        LoadFilds(toyotaProcess);
    }

    public async void SaveUpdate()
    {
        if (VerifyChanged())
        {
            CreateButton.IsVisible = true;
            EditButtons.IsVisible = false;

            TitleLabel.Text = "Criar Processo";
            ClearFilds();

            return;
        }

        IPopupResult<bool> result = await this.ShowPopupAsync<bool>(new ConfirmActionModal(
           new TokenAction(
               "Alterar processo?",
               "Essa ação não tem volta!",
               true)),
               PopupOptions.Empty,
               CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return;

        CreateProcess();
        processList.Remove(currentProcessInEdit!);

        CreateButton.IsVisible = true;
        EditButtons.IsVisible = false;

        TitleLabel.Text = "Criar Processo";
    }

    public async void CancelUpdateProcess()
    {

        if (VerifyChanged())
        {
            CreateButton.IsVisible = true;
            EditButtons.IsVisible = false;

            TitleLabel.Text = "Criar Processo";
            ClearFilds();

            return;
        }

        IPopupResult<bool> result = await this.ShowPopupAsync<bool>(new ConfirmActionModal(
            new TokenAction(
                "Excluir alterarção?",
                "Essa ação não tem volta!",
                true)),
                PopupOptions.Empty,
                CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return;

        CreateButton.IsVisible = true;
        EditButtons.IsVisible = false;

        TitleLabel.Text = "Criar Processo";
        ClearFilds();
    }

    private bool VerifyChanged()
    {
        if (ProcessTitleLabel.Text == currentProcessInEdit!.title &&
            ProcessDescriptionLabel.Text == currentProcessInEdit.description &&
            ProcessIcon.iconImage == currentProcessInEdit.icon.image &&
            ProcessIcon.iconColor == currentProcessInEdit.icon.color)
            return true;

        else
            return false;
    }

    private bool VerifyIfThere()
    {
        foreach (var process in processList)
        {
            if (process.title == ProcessTitleLabel.Text &&
                process.description == ProcessDescriptionLabel.Text &&
                process.icon.image == ProcessIcon.iconImage &&
                process.icon.color == ProcessIcon.iconColor)
                return true;
        }
        return false;
    }

    private void LoadFilds(ToyotaProcess toyotaProcess)
    {
        ProcessIcon.iconImage = toyotaProcess.icon.image;
        ProcessIcon.iconColor = toyotaProcess.icon.color;

        ProcessDescriptionLabel.Text = toyotaProcess.description;
        ProcessTitleLabel.Text = toyotaProcess.title;
    }

    private void ClearFilds()
    {
        ProcessIcon.iconColor = Colors.White;
        ProcessIcon.iconImage = FASolid.Asterisk;

        ProcessDescriptionLabel.Text = string.Empty;
        ProcessTitleLabel.Text = string.Empty;
    }
}