using iOSNavStackRemoveCrash.Interfaces;
using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash
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
            //Navigation.PushAsync(new FirstPage());
            await navigationService.PushToRootAsync<FirstViewModel>(vm => vm.Init());
        }
    }

}
