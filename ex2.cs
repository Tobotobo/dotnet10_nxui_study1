#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

var count = 0;

NXUI.Desktop.NXUI.Run(
    () => Window()
        .Title("NXUI").Width(400).Height(300)
        .Content(StackPanel().Children(
            Button(out var button)
                .Content("Click Me!")
                .Content(button.ObserveOnClick().Select(_ => ++count).Select(x => $"現在のカウントは {x} です。"))
    )), 
    "NXUI", 
    args, 
    ThemeVariant.Dark,
    ShutdownMode.OnLastWindowClose);