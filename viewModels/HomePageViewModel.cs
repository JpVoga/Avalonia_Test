using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class HomePageViewModel: PageViewModel {
    public string Test {get; set;} = "Home Test!";

    public HomePageViewModel() {
        Page = Page.Home;
    }
}