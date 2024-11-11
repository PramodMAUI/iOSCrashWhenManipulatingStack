using iOSNavStackRemoveCrash.Interfaces;
using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash
{
    public partial class App : Application
    {
        private readonly INavigationService navigationService;

        public App(INavigationService navigationService)
        {
            InitializeComponent();
            this.navigationService = navigationService;
            MainPage = new NavigationPage(new MainPage(this.navigationService));//new NavigationPage(new FirstPage());//new AppShell();
            //PageNavigation();
        }

        private async void PageNavigation()
        {
            await navigationService.PushToRootAsync<FirstViewModel>(vm => vm.Init());
        }
    }
}
