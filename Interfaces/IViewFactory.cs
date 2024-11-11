using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash.Interfaces
{
    public interface IViewFactory
    {
        Page CreatePage<TViewModel>(Action<TViewModel> activateAction = null)
            where TViewModel : BaseViewModel;
    }
}
