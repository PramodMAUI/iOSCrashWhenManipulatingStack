using iOSDisplayAlertHiddenIssue.Interfaces;
using iOSDisplayAlertHiddenIssue.ViewModels;

namespace iOSDisplayAlertHiddenIssue
{
    public partial class MainPage : ContentPage
    {
        private readonly INavigationService navigationService;
        public MainPage(INavigationService navigationService)
        {
            InitializeComponent();
            this.navigationService = navigationService;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await this.navigationService.PagePushAsync<StockControlViewModel>(vm => vm.Init());

        }
    }

}
