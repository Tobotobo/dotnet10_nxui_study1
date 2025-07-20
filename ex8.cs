#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

BehaviorSubject<State> _state = new(new("12345", []));

Window MainWindow() => Window()
    .Title("NXUI memo app sample").Width(500).Height(300)
    .Content(StackPanel().Children(
        TextBox()
            .Text(_state.Select(x => x.Text))
            .OnText((_, o) => o.Subscribe(x => UpdateState(UpdateText(_state.Value, x))))
            .Errors(_state.Select(x => x.Errors))
    ));

NXUI.Desktop.NXUI.Run(
    MainWindow, 
    "NXUI", 
    args, 
    ThemeVariant.Default,
    ShutdownMode.OnLastWindowClose);

void UpdateState(State state) => _state.OnNext(state);
State UpdateText(State state, string? text)
{
    List<string> errors = [];
    if (!String.IsNullOrEmpty(text)) {
        if (!Double.TryParse(text, out var _))
        {
            errors.Add("数値で入力してください。");
        }
    }
    return state with
        {
            Text = errors.Count == 0 ? text : state.Text,
            Errors = errors.ToArray()
        };
}

record State(
    string? Text,
    string[] Errors
);

