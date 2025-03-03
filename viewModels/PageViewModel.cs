using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public abstract partial class PageViewModel: ViewModelBase {
    [ObservableProperty]
    private Page page;
}