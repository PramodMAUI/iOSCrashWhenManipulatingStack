using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash;

public partial class FirstPage : ContentPage
{
    public FirstPage(FirstViewModel VM)
    {
        InitializeComponent();
        BindingContext = VM;
    }
}
