#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0
#:package DialogHost.Avalonia@0.9.3

// DialogHost.Avalonia
// https://github.com/AvaloniaUtils/DialogHost.Avalonia

using DialogHostAvalonia;

NXUI.Desktop.NXUI.Run(
    () => Window().Styles(new DialogHostStyles())
        .Content(DialogHost(out var dialogHost).DialogContent(StackPanel().Children(
            Label().Content("NXUI"),
            Button().Content("閉じる").OnClick((_, o) => o.Subscribe(_ => dialogHost.IsOpen(false)))
        )).Content(
            Button().Content("開く").OnClick((_, o) => o.Subscribe(_ => dialogHost.IsOpen(true)))
        )), 
    "NXUI", 
    args, 
    ThemeVariant.Dark,
    ShutdownMode.OnLastWindowClose);


// DialogHost DialogHost() => new DialogHost();
DialogHost DialogHost(out DialogHost @ref) => @ref = new DialogHost();
static class Extensions
{
    public static DialogHost DialogContent(this DialogHost source, object? value)
    {
        source.DialogContent = value;
        return source;
    }

    public static DialogHost IsOpen(this DialogHost source, bool value)
    {
        source.IsOpen = value;
        return source;
    }
}