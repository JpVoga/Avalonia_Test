using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class MainViewModel: ViewModelBase {

    // Seems to be how you observe properties
    /*private string _testProp = "prop 0";
    public string TestProp {
        get => _testProp;
        set {
            SetProperty(ref _testProp, value);
        }
    }*/

    [ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(SomeProp))] // Update binding value when this changes
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    private ViewModelBase _currentPage;

    private readonly HomePageViewModel testHomePage = new();
    private readonly ProcessPageViewModel testProcessPage = new();

    public MainViewModel() {
        CurrentPage = testHomePage;
    }

    [RelayCommand]
    private void SideMenuResize() {
        SideMenuExpanded = !SideMenuExpanded;
    }
}