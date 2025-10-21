using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPERS.ViewModel.Pages.MainPages;
public class ProcessViewModel
{
    private async Task<bool> CreateProcess()
    {
        ToyotaProcess newProcess = new(ProcessTitleLabel.Text, ProcessDescriptionLabel.Text, new IconPropertys(ProcessIcon.iconImage, ProcessIcon.iconColor));

        if (verification.CheckSameProcess(newProcess, [.. processList]))
        {
            await verification.WaringPopup(WarningTokens.Existing, this);
            return false;
        }

        processList.Add(newProcess);

        ClearFilds();

        return true;
    }
}