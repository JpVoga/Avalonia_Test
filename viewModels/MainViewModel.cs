using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class MainViewModel: ViewModelBase {
    [ObservableProperty()] // Class has to be partial for this!
    private string test = "hello";
}