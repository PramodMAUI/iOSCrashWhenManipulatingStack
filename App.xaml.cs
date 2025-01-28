using iOSDisplayAlertHiddenIssue.Interfaces;
using iOSDisplayAlertHiddenIssue.ViewModels;
using iOSDisplayAlertHiddenIssue.Views;

namespace iOSDisplayAlertHiddenIssue
{
    public partial class App : Application
    {
        private readonly INavigationService navigationService;

        public App(INavigationService navigationService)
        {
            InitializeComponent();
            this.navigationService = navigationService;
            MainPage = new NavigationPage(new MainPage(this.navigationService));
        }

    }
}
