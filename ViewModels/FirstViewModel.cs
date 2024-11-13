using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace iOSNavStackRemoveCrash.ViewModels
{
    public partial class FirstViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Navigate(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
