using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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


    [RelayCommand]
    private void SideMenuResize() {
        SideMenuExpanded = !SideMenuExpanded;
    }
}