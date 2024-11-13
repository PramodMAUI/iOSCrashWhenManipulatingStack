using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash;

public partial class ThirdPage : ContentPage
{
    public ThirdPage(ThirdViewModel VM)
    {
        InitializeComponent();
        BindingContext = VM;
    }
}
