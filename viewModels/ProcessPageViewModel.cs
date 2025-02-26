using System;

namespace Avalonia_Test;

public partial class ProcessPageViewModel: PageViewModel {
    public string Test {get; set;} = "Process Test!";

    public ProcessPageViewModel() {
        Page = Page.Process;
    }
}