using System.Diagnostics;
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
        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<ActionsPageViewModel>();
        collection.AddTransient<HistoryPageViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<MacrosPageViewModel>();
        collection.AddTransient<ProcessPageViewModel>();
        collection.AddTransient<ReporterPageViewModel>();
        collection.AddTransient<SettingsPageViewModel>();
        //collection.AddSingleton<MyType>(); // Contructors of services could now take a 'MyType' instance I think???
        // Transients are created when needed

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

// 5 10:40