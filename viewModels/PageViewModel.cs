using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class PageViewModel: ViewModelBase {
    [ObservableProperty]
    private Page page;
}