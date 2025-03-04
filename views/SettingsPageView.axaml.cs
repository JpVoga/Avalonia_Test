using System.IO;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Avalonia_Test;

public partial class SettingsPageView: UserControl {
    public SettingsPageView() {
        InitializeComponent();

        // How to convert and show
        /*using Stream HeaderBackground = ImageConvert.SvgToPng("assets/images/background-settings.svg");
        HeaderBackgroundPanel.Background = new ImageBrush() {
            Source = new Bitmap(HeaderBackground),
            Stretch = Stretch.UniformToFill
        };*/
    }
}