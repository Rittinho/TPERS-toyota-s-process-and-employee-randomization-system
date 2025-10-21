using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Handlers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TPERS.View.Pages.Components.Modal;
using TPERS.View.Services.Icons;
using TPERS.View.Services.Injections.Contract;

namespace TPERS.View.Pages.Principal;

public partial class ProcessView : ContentPage
{
    private IVerificationServices verification;
    public ObservableCollection<ToyotaProcess> processList { get; } = [];

    private ToyotaProcess? currentProcessInEdit;

    public IAsyncRelayCommand UpdateIconProcessCommand => new AsyncRelayCommand(UpdateIcon);
    public IAsyncRelayCommand SowProcessCommand => new AsyncRelayCommand<ToyotaProcess>(SowProcess);
    public IAsyncRelayCommand CreateProcessCommand => new AsyncRelayCommand(CreateProcess);
    public ICommand UpdateProcessCommand => new Command<ToyotaProcess>(UpdateProcess);
    public ICommand SaveUpdateProcessCommand => new Command(SaveUpdate);
    public ICommand CancelUpdateProcessCommand => new Command(CancelUpdateProcess);
    public ICommand DeleteProcessCommand => new Command<ToyotaProcess>(DeleteProcess);

    public ProcessView(IVerificationServices verificationServices)
    {
        InitializeComponent();

        verification = verificationServices;
        ProcessIcon.iconColor = Colors.White;
        ProcessIcon.iconImage = FASolid.Asterisk;

        BindingContext = this;
    }

    private async Task UpdateIcon()
    {
        IPopupResult<IconPropertys> result = await this.ShowPopupAsync<IconPropertys>(new IconSelecterModal(ProcessIcon.iconImage, ProcessIcon.iconColor),PopupOptions.Empty,CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup)
        {
            await verification.WaringPopup("Alterações descartadas!", "As alterações foram perdidas", this);
            return;
        }

        if (result.Result == null)
        {
            await verification.WaringPopup("Selecione um icone valido!","Por favor, refaça o icone", this);
            return;
        }

        ProcessIcon.iconColor = result.Result!.color;
        ProcessIcon.iconImage = result.Result.image;
    }

    private async Task<bool> CreateProcess()
    {
        ToyotaProcess newProcess = new (ProcessTitleLabel.Text, ProcessDescriptionLabel.Text, new IconPropertys(ProcessIcon.iconImage, ProcessIcon.iconColor));

        if (verification.CheckSameProcess(newProcess, [..processList]))
        {
            await verification.WaringPopup(WarningTokens.Existing,this);
            return false;
        }

        processList.Add(newProcess);

        ClearFilds();
         
        return true;
    }

    private async Task SowProcess(ToyotaProcess? toyotaProcess)
    {
        if (toyotaProcess == null)
        {
            await verification.WaringPopup("Ocorreu um erro", "Ocorreu um erro ao exibir o processo, por favor, tente novamente", this);
            return;
        }

        IPopupResult<ToyotaProcess> result = await this.ShowPopupAsync<ToyotaProcess>(new ProcessDescriptionModal(toyotaProcess), PopupOptions.Empty, CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup)
            return;
    }

    private async void DeleteProcess(ToyotaProcess toyotaProcess)
    {
        if (await verification.ConfirmPopup(WarningTokens.Delete, this))
            return;

        processList.Remove(toyotaProcess);
    }

    public void UpdateProcess(ToyotaProcess toyotaProcess)
    {
        currentProcessInEdit = toyotaProcess;

        UpdateScreen();

        LoadFilds(toyotaProcess);
    }

    public async void SaveUpdate()
    {
        if (!CheckIfAnythingHasChanged())
        {
            UpdateScreen();
            ClearFilds();
            return;
        }

        if(await verification.ConfirmPopup(WarningTokens.Change, this))
            return;

        if(await CreateProcess())
            await verification.WaringPopup(WarningTokens.UpdateSuccess, this);

        processList.Remove(currentProcessInEdit!);

        CreateScreen();
    }

    public async void CancelUpdateProcess()
    {

        if (!CheckIfAnythingHasChanged())
        {
            CreateScreen();
            ClearFilds();
            return;
        }

        if (await verification.ConfirmPopup("Descartar alterações?","As alterações não ficam salvas!", this))
            return;

        CreateScreen();

        ClearFilds();
    }

    //ferramentas-------------------------------------------
    private bool CheckIfAnythingHasChanged()
    {
        if (ProcessTitleLabel.Text == currentProcessInEdit!.title &&
            ProcessDescriptionLabel.Text == currentProcessInEdit.description &&
            ProcessIcon.iconImage == currentProcessInEdit.icon.image &&
            ProcessIcon.iconColor == currentProcessInEdit.icon.color)
            return false;

        else
            return true;
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

    private void CreateScreen()
    {
        CreateButton.IsVisible = true;
        EditButtons.IsVisible = false;

        TitleLabel.Text = "Criar Processo";
    }

    private void UpdateScreen()
    {
        CreateButton.IsVisible = true;
        EditButtons.IsVisible = false;

        TitleLabel.Text = "Criar Processo";
    }
}