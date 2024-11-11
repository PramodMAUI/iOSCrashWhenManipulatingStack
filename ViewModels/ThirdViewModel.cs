using iOSNavStackRemoveCrash.Common.Enums;
using iOSNavStackRemoveCrash.Interfaces;

namespace iOSNavStackRemoveCrash.ViewModels
{
    public class ThirdViewModel : BaseViewModel
    {
        public ThirdViewModel(INavigationService navigationService) : base(navigationService)
        {
            PageType = PageTypeEnum.Page3;
        }
        public async Task InitAsync()
        {
            base.NavigationService.ManipulateNavStack(PageTypeEnum.Page1, PageTypeEnum.Page3);

        }
    }
}
