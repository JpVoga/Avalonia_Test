using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class SettingsPageViewModel: PageViewModel {

    [ObservableProperty]
    private List<string> locationPaths;

    public SettingsPageViewModel() {
        //System.Diagnostics.Trace.WriteLine("Made instance of settings!");
        Page = Page.Settings;
        locationPaths = [
            "C:/Users/Joao/Downloads/TestActions",
            "C:/Users/Joao/Documents/Avalonia_Test",
            "C:/Users/Shared/Avalonia_Test/Templates"
        ];
    }
}