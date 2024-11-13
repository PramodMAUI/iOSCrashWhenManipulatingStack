using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash;

public partial class SecondPage : ContentPage
{
    public SecondPage(SecondViewModel VM)
    {
        InitializeComponent();
        BindingContext = VM;
    }

}