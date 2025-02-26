using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_Test;

public partial class MainViewModel: ViewModelBase {
    private const string buttonActiveClass = "ActivePageButton";

    // Seems to be how you observe properties
    /*private string _testProp = "prop 0";
    public string TestProp {
        get => _testProp;
        set {
            SetProperty(ref _testProp, value);
        }
    }*/

    private readonly PageFactory pageFactory;

    [ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(SomeProp))] // Update binding value when this changes
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ActionsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(MacrosPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ReporterPageIsActive))]
    [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
    [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
    private PageViewModel currentPage = null!; // Certain that it will be set in constructor

    public bool HomePageIsActive => GetPageIsActive(Page.Home);
    public bool ProcessPageIsActive => GetPageIsActive(Page.Process);
    public bool ActionsPageIsActive => GetPageIsActive(Page.Actions);
    public bool MacrosPageIsActive => GetPageIsActive(Page.Macros);
    public bool ReporterPageIsActive => GetPageIsActive(Page.Reporter);
    public bool HistoryPageIsActive => GetPageIsActive(Page.History);
    public bool SettingsPageIsActive => GetPageIsActive(Page.Settings);

    public MainViewModel(PageFactory pageFactory) {
        this.pageFactory = pageFactory;
        GoToHome();
    }

    [RelayCommand]
    private void SideMenuResize() => SideMenuExpanded = !SideMenuExpanded;

    [RelayCommand]
    private void GoToHome() => CurrentPage = pageFactory.GetPageViewModel(Page.Home);

    [RelayCommand]
    private void GoToProcess() => CurrentPage = pageFactory.GetPageViewModel(Page.Process);

    [RelayCommand]
    private void GoToActions() => CurrentPage = pageFactory.GetPageViewModel(Page.Actions);

    [RelayCommand]
    private void GoToMacros() => CurrentPage = pageFactory.GetPageViewModel(Page.Macros);

    [RelayCommand]
    private void GoToReporter() => CurrentPage = pageFactory.GetPageViewModel(Page.Reporter);

    [RelayCommand]
    private void GoToHistory() => CurrentPage = pageFactory.GetPageViewModel(Page.History);

    [RelayCommand]
    private void GoToSettings() => CurrentPage = pageFactory.GetPageViewModel(Page.Settings);

    private bool GetPageIsActive(Page page) => page == CurrentPage.Page;
}