using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class HomePageViewModel: ViewModelBase {
    public string Test {get; set;} = "Home Test!";
}