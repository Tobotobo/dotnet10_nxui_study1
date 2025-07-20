#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0
#:package MessageBox.Avalonia@3.2.0

// https://docs.avaloniaui.net/docs/basics/user-interface/messagebox
// https://github.com/AvaloniaCommunity/MessageBox.Avalonia

using MsBox.Avalonia;

BehaviorSubject<string> text = new("");

Window MainWindow() => Window(out var window)
    .Title("NXUI memo app sample").Width(500).Height(300)
    .Content(StackPanel().VerticalAlignmentCenter().HorizontalAlignmentCenter().Children(
        Label()
            .Content(text.Select(x => $"Result = {x}")),
        Button()
            .Content("ShowAsync")
            .OnClick((_, o) => o.Subscribe(async _ => await MsgBoxShowAsync())),
        Button()
            .Content("ShowWindowAsync")
            .OnClick((_, o) => o.Subscribe(async _ => await MsgBoxShowWindowAsync())),
        Button()
            .Content("ShowAsPopupAsync")
            .OnClick((_, o) => o.Subscribe(async _ => await MsgBoxShowAsPopupAsync(window))),
        Button()
            .Content("ShowWindowDialogAsync")
            .OnClick((_, o) => o.Subscribe(async _ => await MsgBoxShowWindowDialogAsync(window)))

    ));

async Task MsgBoxShowAsync()
{
    var msgBox = MessageBoxManager.GetMessageBoxStandard("タイトル", "メッセージ", MsBox.Avalonia.Enums.ButtonEnum.OkCancel, MsBox.Avalonia.Enums.Icon.Info);
    var result = await msgBox.ShowAsync();
    text.OnNext(result.ToString());
}

async Task MsgBoxShowWindowAsync()
{
    var msgBox = MessageBoxManager.GetMessageBoxStandard("タイトル", "メッセージ", MsBox.Avalonia.Enums.ButtonEnum.OkAbort, MsBox.Avalonia.Enums.Icon.Warning);
    var result = await msgBox.ShowWindowAsync();
    text.OnNext(result.ToString());
}

async Task MsgBoxShowAsPopupAsync(ContentControl owner)
{
    var msgBox = MessageBoxManager.GetMessageBoxStandard("タイトル", "メッセージ", MsBox.Avalonia.Enums.ButtonEnum.YesNo, MsBox.Avalonia.Enums.Icon.Error);
    var result = await msgBox.ShowAsPopupAsync(owner);
    text.OnNext(result.ToString());
}

async Task MsgBoxShowWindowDialogAsync(Window owner)
{
    var msgBox = MessageBoxManager.GetMessageBoxStandard("タイトル", "メッセージ", MsBox.Avalonia.Enums.ButtonEnum.YesNoCancel, MsBox.Avalonia.Enums.Icon.Question);
    var result = await msgBox.ShowWindowDialogAsync(owner);
    text.OnNext(result.ToString());
}


NXUI.Desktop.NXUI.Run(
    MainWindow, 
    "NXUI", 
    args, 
    ThemeVariant.Default,
    ShutdownMode.OnLastWindowClose);
