using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPERS.View.Pages;

namespace TPERS.View.Services.Injections.Contract;
public interface IVerificationServices
{
    public Task WaringPopup(Tuple<string, string> token, ContentPage currentPage);
    public Task WaringPopup(string title, string description, ContentPage currentPage);

    public Task<bool> ConfirmPopup(Tuple<string, string> token, ContentPage currentPage);
    public Task<bool> ConfirmPopup(string title, string description, ContentPage currentPage);

    public bool CheckSameProcess(ToyotaProcess toyotaProcess, List<ToyotaProcess> list);
}
