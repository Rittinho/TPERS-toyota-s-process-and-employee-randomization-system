using TPERS.View.Pages.Principal;

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
            return new Window(new NavigationPage(new ProcessView()));
            //return new Window(new AppShell());
        }
    }
}