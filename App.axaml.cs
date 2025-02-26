using System;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia_Test;

public partial class App: Application {
    public override void Initialize() {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted() {
        base.OnFrameworkInitializationCompleted(); // This was called in the end but I moved it to the start, time will tell if this was a good choice
    
        ServiceCollection collection = new();
        collection.AddSingleton<MainViewModel>(); // Contructors of services could now take a 'MainViewModel' instance I think???
        collection.AddSingleton<PageFactory>();
        collection.AddSingleton<PageCreator>(services => page => page switch {
            Page.Unknown or Page.Home => new HomePageViewModel(),
            Page.Process  => services.GetRequiredService<ProcessPageViewModel >(),
            Page.Actions  => services.GetRequiredService<ActionsPageViewModel >(),
            Page.Macros   => services.GetRequiredService<MacrosPageViewModel  >(),
            Page.Reporter => services.GetRequiredService<ReporterPageViewModel>(),
            Page.History  => services.GetRequiredService<HistoryPageViewModel >(),
            Page.Settings => services.GetRequiredService<SettingsPageViewModel>(),
           _ => throw new InvalidDataException($"Invalid page type \"{page}\"")
        });

        collection.AddTransient<ActionsPageViewModel>(); // Transients are created when needed
        collection.AddTransient<HistoryPageViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<MacrosPageViewModel>();
        collection.AddTransient<ProcessPageViewModel>();
        collection.AddTransient<ReporterPageViewModel>();
        collection.AddTransient<SettingsPageViewModel>();

        ServiceProvider services = collection.BuildServiceProvider(); // According to Youtube, shouldn't pass service provider around

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            // Main window is passed here (for desktop at least).
            desktop.MainWindow = new MainView() {
                DataContext = services.GetRequiredService<MainViewModel>() // The 'Required' part ensures it is not null
            };
        }
    }
}

// For MVVM programming must 'dotnet add package CommunityToolkit.Mvvm'