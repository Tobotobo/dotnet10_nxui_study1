#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0
#:package DialogHost.Avalonia@0.9.3

// DialogHost.Avalonia
// https://github.com/AvaloniaUtils/DialogHost.Avalonia

using DialogHostAvalonia;

Window Build()
{
    var dialogHost = new DialogHost();
    dialogHost.DialogContent = StackPanel().Children(
        Label().Content("NXUI"),
        Button().Content("閉じる").OnClick((_, o) => o.Subscribe(_ => dialogHost.IsOpen = false))
    );
    // dialogHost.CloseOnClickAway = true;

    return Window().Styles(new DialogHostStyles())
        .Content(dialogHost.Content(
            Button().Content("開く").OnClick((_, o) => o.Subscribe(_ => dialogHost.IsOpen = true))
        )); 
}

NXUI.Desktop.NXUI.Run(
    Build, 
    "NXUI", 
    args, 
    ThemeVariant.Dark,
    ShutdownMode.OnLastWindowClose);