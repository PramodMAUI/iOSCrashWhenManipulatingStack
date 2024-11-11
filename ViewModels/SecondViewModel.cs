using iOSNavStackRemoveCrash.Common.Enums;
using iOSNavStackRemoveCrash.Interfaces;
using System.Windows.Input;

namespace iOSNavStackRemoveCrash.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        public ICommand ButtonClickCommand { get; }
        public SecondViewModel(INavigationService navigationService) : base(navigationService)
        {
            ButtonClickCommand = new Command(OnButtonClicked);
            PageType = PageTypeEnum.Page2;
        }

        public async Task InitAsync()
        {

        }
        private async void OnButtonClicked()
        {
            await this.NavigationService.PagePushAsync<ThirdViewModel>(async vm => await vm.InitAsync());

        }
    }

}
