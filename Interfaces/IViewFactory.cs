using iOSDisplayAlertHiddenIssue.ViewModels;

namespace iOSDisplayAlertHiddenIssue.Interfaces
{
    public interface IViewFactory
    {
        Page CreatePage<TViewModel>(Action<TViewModel> activateAction = null)
            where TViewModel : BaseViewModel;
    }
}
