using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using System.Collections.ObjectModel;
using TPERS.View.Pages;
using TPERS.View.Pages.Components.Modal;
using TPERS.View.Services.Injections.Contract;

namespace TPERS.View.Services.Injections.Implementation;
public class VerificationServices : IVerificationServices
{
    public bool CheckSameProcess(ToyotaProcess toyotaProcess, List<ToyotaProcess> list)
    {
        foreach (var process in list)
        {
            if (process.title == toyotaProcess.title &&
                process.description == toyotaProcess.description &&
                process.icon.image == toyotaProcess.icon.image &&
                process.icon.color == toyotaProcess.icon.color)
                return true;
        }   

        return false;
    }

    public async Task<bool> ConfirmPopup(Tuple<string, string> token, ContentPage currentPage)
    {
        IPopupResult<bool> result = await currentPage.ShowPopupAsync<bool>(new ConfirmActionModal(
          new TokenAction(
              token.Item1,
              token.Item2,
              true)),
              PopupOptions.Empty,
              CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return false;

        return true;
    }

    public async Task<bool> ConfirmPopup(string title, string description, ContentPage currentPage)
    {
        IPopupResult<bool> result = await currentPage.ShowPopupAsync<bool>(new ConfirmActionModal(
          new TokenAction(
              title,
              description,
              true)),
              PopupOptions.Empty,
              CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return false;

        return true;
    }

    public async Task WaringPopup(Tuple<string, string> token , ContentPage currentPage)
    {
        IPopupResult<bool> result = await currentPage.ShowPopupAsync<bool>(new ConfirmActionModal(
        new TokenAction(
            token.Item1,
            token.Item2,
            false)),
            PopupOptions.Empty,
            CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return;

        return;
    }

    public async Task WaringPopup(string title, string description, ContentPage currentPage)
    {
        IPopupResult<bool> result = await currentPage.ShowPopupAsync<bool>(new ConfirmActionModal(
        new TokenAction(
            title,
            description,
            false)),
            PopupOptions.Empty,
            CancellationToken.None);

        if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
            return;

        return;
    }
}
