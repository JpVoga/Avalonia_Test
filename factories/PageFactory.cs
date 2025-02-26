using System;

namespace Avalonia_Test;

public class PageFactory(PageCreator pageCreator) {
    public PageViewModel GetPageViewModel(Page page) => pageCreator.Invoke(page);
}