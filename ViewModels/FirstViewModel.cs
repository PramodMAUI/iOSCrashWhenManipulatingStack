using iOSNavStackRemoveCrash.Common.Enums;
using iOSNavStackRemoveCrash.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace iOSNavStackRemoveCrash.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public ICommand ButtonClickCommand { get; }

        public FirstViewModel(INavigationService navigationService) : base(navigationService)
        {
            ButtonClickCommand = new Command(OnButtonClicked);
            PageType = PageTypeEnum.Page1;
        }

        public void Init()
        {
        }
        public async void OnButtonClicked()
        {
            await this.NavigationService.PagePushAsync<SecondViewModel>(async vm => await vm.InitAsync());

        }
    }
}
