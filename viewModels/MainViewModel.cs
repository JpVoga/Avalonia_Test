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
    private ViewModelBase _currentPage = null!; // Certain that it will be set in constructor

    #region Home
        private readonly HomePageViewModel homePage = new();
        public bool HomePageIsActive => GetPageIsActive(homePage);
    #endregion

    #region Process
        private readonly ProcessPageViewModel processPage = new();
        public bool ProcessPageIsActive => GetPageIsActive(processPage);
    #endregion

    #region Actions
        private readonly ActionsPageViewModel actionsPage = new();
        public bool ActionsPageIsActive => GetPageIsActive(actionsPage);
    #endregion

    #region Macros
        private readonly MacrosPageViewModel macrosPage = new();
        public bool MacrosPageIsActive => GetPageIsActive(macrosPage);
    #endregion

    #region Reporter
        private readonly ReporterPageViewModel reporterPage = new();
        public bool ReporterPageIsActive => GetPageIsActive(reporterPage);
    #endregion

    #region History
        private readonly HistoryPageViewModel historyPage = new();
        public bool HistoryPageIsActive => GetPageIsActive(historyPage);
    #endregion

    #region Settings
        private readonly SettingsPageViewModel settingsPage = new();
        public bool SettingsPageIsActive => GetPageIsActive(settingsPage);
    #endregion

    public MainViewModel() {
        CurrentPage = homePage;
    }

    [RelayCommand]
    private void SideMenuResize() {
        SideMenuExpanded = !SideMenuExpanded;
    }

    [RelayCommand]
    private void GoToHome() {
        CurrentPage = homePage;
    }

    [RelayCommand]
    private void GoToProcess() {
        CurrentPage = processPage;
    }

    [RelayCommand]
    private void GoToActions() {
        CurrentPage = actionsPage;
    }

    [RelayCommand]
    private void GoToMacros() {
        CurrentPage = macrosPage;
    }

    [RelayCommand]
    private void GoToReporter() {
        CurrentPage = reporterPage;
    }

    [RelayCommand]
    private void GoToHistory() {
        CurrentPage = historyPage;
    }

    [RelayCommand]
    private void GoToSettings() {
        CurrentPage = settingsPage;
    }

    private bool GetPageIsActive(ViewModelBase page) => page == CurrentPage;
}