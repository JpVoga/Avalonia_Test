using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace Avalonia_Test;

// Code behind for the window. Shouldn't do data logic in code behind, only UI related things!
public partial class MainView: Window
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnSideMenuImageClicked(object sender, PointerPressedEventArgs args) {
        if (DataContext is MainViewModel mainViewModel) {
            if (args.ClickCount >= 2) {
                mainViewModel.SideMenuResizeCommand?.Execute(null);
            }
        }
        else throw new NotImplementedException();
    }
}