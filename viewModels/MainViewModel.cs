using Avalonia.Svg.Skia;
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
    [NotifyPropertyChangedFor(nameof(SideMenuImage))] // Update binding value when this changes
    private bool sideMenuExpanded = true;

    public SvgImage SideMenuImage => new SvgImage{Source = SvgSource.Load($"avares://{nameof(Avalonia_Test)}/assets/images/{(SideMenuExpanded? "logo":"icon")}.svg")};
}