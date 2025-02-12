using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace Avalonia_Test;

public partial class MainView: Window
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnSideMenuImageClicked(object sender, PointerPressedEventArgs args) {
        if (args.ClickCount >= 2) {
            // Double click!
            // Stopped on video 3, at 3:00
        }
    }
}