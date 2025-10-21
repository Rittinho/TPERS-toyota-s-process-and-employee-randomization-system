using TPERS.View.Pages.Principal;
using TPERS.View.Services.Injections.Contract;

namespace TPERS.View
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var verificationServices = MauiProgram.ServiceProvider.GetRequiredService<IVerificationServices>();
            return new Window(new NavigationPage(new ProcessView(verificationServices)));
            //return new Window(new AppShell());
        }
    }
}