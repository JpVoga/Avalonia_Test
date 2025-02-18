using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace Avalonia_Test;

public class ViewLocator: IDataTemplate
{
    public Control? Build(object? data) { // Return expected view based on view model
        if (data is null) throw new ArgumentNullException("Data to build view must not be null!");

        string viewModelName = data.GetType().Name;
        if (!viewModelName.EndsWith("ViewModel")) throw new ArgumentException("View model name must end in \"ViewModel\"");

        string viewName = viewModelName.Replace("ViewModel", "View", StringComparison.InvariantCulture);
        var namespaces = Assembly.GetExecutingAssembly().GetTypes().Select(t => t.Namespace).Distinct();
        Type? viewType = null;
        foreach (var @namespace in namespaces) {
            if (@namespace is not null) viewType = Type.GetType($"{@namespace}.{viewName}");
            if (viewType is not null) break;
        }

        if (viewType is null) throw new ArgumentException($"View model named \"{viewModelName}\" does not have equivalent view \"{viewName}\"");

        object? view = Activator.CreateInstance(viewType);
        if (view is Control control) {
            control.DataContext = data; // Set view's view model
            return control;
        }
        else throw new ArgumentException($"Class \"{viewName}\" must be a view type constructible with no parameters.");
    }

    public bool Match(object? data) {
        return data is ViewModelBase;
    }
}