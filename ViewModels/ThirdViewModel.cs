using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace iOSNavStackRemoveCrash.ViewModels
{
    public partial class ThirdViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Navigate(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
