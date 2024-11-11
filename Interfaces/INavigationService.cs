using iOSNavStackRemoveCrash.ViewModels;
namespace iOSNavStackRemoveCrash.Interfaces
{
    public interface INavigationService
    {
        Task PushToRootAsync<TViewModel>(
            Action<TViewModel> activateAction)
            where TViewModel : BaseViewModel;
        Task PagePushAsync<TViewModel>(
            Action<TViewModel> activateAction)
            where TViewModel : BaseViewModel;

        void RemovePage<TViewModel>(
           Action<TViewModel> activateAction)
           where TViewModel : BaseViewModel;

        INavigation GetNavigationService();
        void ManipulateNavStack(Common.Enums.PageTypeEnum startPageType, Common.Enums.PageTypeEnum endPageType);

    }
}
