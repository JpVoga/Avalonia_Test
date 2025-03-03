using System;
using Avalonia.Svg.Skia;

namespace Avalonia_Test;

public partial class SettingsPageViewModel: PageViewModel {
    public SvgImage SettingsPageHeaderBackground => new SvgImage() {Source = SvgSource.Load("avares://Avalonia_Test/assets/images/background-settings.svg")};

    public SettingsPageViewModel() {
        //System.Diagnostics.Trace.WriteLine("Made instance of settings!");
        Page = Page.Settings;
        ;
    }
}