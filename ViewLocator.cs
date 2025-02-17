using System;
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
        Type? viewType = Type.GetType($"Avalonia_Test.{viewName}");

        if (viewType is null) throw new ArgumentException($"View model named \"{viewModelName}\" does not have equivalent view \"{viewName}\"");

        object? view = Activator.CreateInstance(viewType);
        if (view is Control control) return control;
        else throw new ArgumentException($"Class \"{viewName}\" must be a view type constructible with no parameters.");
    }

    public bool Match(object? data) {
        return data is ViewModelBase;
    }
}