#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

BehaviorSubject<State> state = new(new(0));

Window MainWindow() => Window()
    .Title("NXUI").Width(400).Height(300)
    .Content(StackPanel().VerticalAlignmentCenter().HorizontalAlignmentCenter().Children(
        Button(out var button)
            .OnClickHandler((_, _) => state.OnNext(state.Value with { Count = state.Value.Count + 1 }))
            .Content(state.Select(x => $"現在のカウントは {x.Count} です。"))
    ));

NXUI.Desktop.NXUI.Run(
    MainWindow, 
    "NXUI", 
    args, 
    ThemeVariant.Dark,
    ShutdownMode.OnLastWindowClose);

record State(
    int Count
);