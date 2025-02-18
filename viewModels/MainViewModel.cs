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
    [NotifyPropertyChangedFor(nameof(HomePageIsActive), nameof(ProcessPageIsActive))]
    private ViewModelBase _currentPage = null!; // Certain that it will be set in constructor

    #region Home
        private readonly HomePageViewModel homePage = new();
        public bool HomePageIsActive => GetPageIsActive(homePage);
    #endregion

    #region Process
        private readonly ProcessPageViewModel processPage = new();
        public bool ProcessPageIsActive => GetPageIsActive(processPage);
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

    private bool GetPageIsActive(ViewModelBase page) => page == CurrentPage;
}