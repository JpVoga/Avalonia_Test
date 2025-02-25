using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Styling;

namespace Avalonia_Test;

// Code behind for the window. Shouldn't do data logic in code behind, only UI related things!
public partial class MainView: Window {
    public MainViewModel MainViewModel => (DataContext as MainViewModel)!;

    public MainView() {
        InitializeComponent();

        // Seems that for button pointer pressed events, MUST manually subscribe LIKE THIS in code behind!
        HomeButton.AddHandler(PointerPressedEvent, OnHomeButtonClicked, handledEventsToo: true);
        ProcessButton.AddHandler(PointerPressedEvent, OnProcessButtonClicked, handledEventsToo: true);
        ActionsButton.AddHandler(PointerPressedEvent, OnActionsButtonClicked, handledEventsToo: true);
        MacrosButton.AddHandler(PointerPressedEvent, OnMacrosButtonClicked, handledEventsToo: true);
        ReporterButton.AddHandler(PointerPressedEvent, OnReporterButtonClicked, handledEventsToo: true);
        HistoryButton.AddHandler(PointerPressedEvent, OnHistoryButtonClicked, handledEventsToo: true);
        SettingsButton.AddHandler(PointerPressedEvent, OnSettingsButtonClicked, handledEventsToo: true);
    }

    private void OnSideMenuImageClicked(object? sender, PointerPressedEventArgs args) {
        if (args.ClickCount >= 2) {
            MainViewModel.SideMenuResizeCommand?.Execute(null);
        }
    }

    private void OnHomeButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToHomeCommand?.Execute(null);
    }

    private void OnProcessButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToProcessCommand?.Execute(null);
    }

    private void OnActionsButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToActionsCommand?.Execute(null);
    }

    private void OnMacrosButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToMacrosCommand?.Execute(null);
    }

    private void OnReporterButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToReporterCommand?.Execute(null);
    }

    private void OnHistoryButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToHistoryCommand?.Execute(null);
    }

    private void OnSettingsButtonClicked(object? sender, PointerPressedEventArgs args) {
        MainViewModel?.GoToSettingsCommand?.Execute(null);
    }
}