#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

BehaviorSubject<State> _state = new(new(0));

Window MainWindow() => Window()
    .Title("NXUI").Width(400).Height(300)
    .Content(StackPanel().VerticalAlignmentCenter().HorizontalAlignmentCenter().Children(
        Label()
            .Content(_state.Select(x => $"現在のカウントは {x.Count} です。")),
        Button()
            .Content("カウントアップ")
            .OnClickHandler((_, _) => UpdateState(CountUp(_state.Value))),
        Button()
            .Content("カウントダウン")
            .OnClickHandler((_, _) => UpdateState(CountDown(_state.Value)))
            
    ));

void UpdateState(State state) => _state.OnNext(state); 
State CountUp(State state) => state with { Count = state.Count + 1 };
State CountDown(State state) => state with { Count = state.Count - 1 };

NXUI.Desktop.NXUI.Run(
    MainWindow, 
    "NXUI", 
    args, 
    ThemeVariant.Dark,
    ShutdownMode.OnLastWindowClose);

record State(
    int Count
);

