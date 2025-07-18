#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

BehaviorSubject<State> _state = new(new(null));

Window MainWindow() => Window()
    .Title("NXUI memo app sample").Width(500).Height(300)
    .Content(StackPanel().Children(
        TextBox()
            .MinHeight(200)
            .AcceptsReturn(true)
            .Watermark("文字入力ボックス")
            .OnTextChangingHandler((s, _) => UpdateState(UpdateText(_state.Value, s.Text))),
        Button()
            .Content("保存")
            .OnClickHandler(async (s, _) => await SaveText(s, _state.Value.Text))
    ));

async Task SaveText(Control control, string? text)
{
    var top = TopLevel.GetTopLevel(control);
    if (top is null) return;
    var file = await top
        .StorageProvider
        .SaveFilePickerAsync(new() { Title = "テキストの保存" });
    if (file is not null)
    {
        await using var str = await file.OpenWriteAsync();
        using var stw = new StreamWriter(str);
        await stw.WriteAsync(text);
    }
}

NXUI.Desktop.NXUI.Run(
    MainWindow, 
    "NXUI", 
    args, 
    ThemeVariant.Default,
    ShutdownMode.OnLastWindowClose);

void UpdateState(State state) => _state.OnNext(state);
State UpdateText(State state, string? text) => state with { Text = text };

record State(
    string? Text
);

