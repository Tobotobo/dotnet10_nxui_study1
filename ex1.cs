#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

NXUI.Desktop.NXUI.Run(
    () => Window().Content(Label().Content("NXUI")), 
    "NXUI", 
    args, 
    ThemeVariant.Dark,
    ShutdownMode.OnLastWindowClose);
