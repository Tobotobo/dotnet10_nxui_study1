#:property OutputType=WinExe
#:package NXUI.Desktop@11.3.0

// 【NXUI】C#でワンライナー・クロスプラットホームデスクトップアプリ【AvaloniaUI】
// https://zenn.dev/inuinu/articles/528550aab764e8

NXUI.Desktop.NXUI.Run(
  () => Window()
    .Width(500).Height(300).Title("NXUI memo app sample")
    .Content(
      StackPanel()
        .Children(
          TextBox(out var tbox)
            .MinHeight(200)
            .AcceptsReturn(true)
            .Watermark("文字入力ボックス"),
          Button()
            .Content("ボタン")
            .OnClickHandler(async (b, a) =>
            {
                var top = TopLevel.GetTopLevel(b);
                if (top is null) return;
                var file = await top
                  .StorageProvider
                  .SaveFilePickerAsync(new() { Title = "テキストの保存" });
                if (file is not null)
                {
                    await using var str = await file.OpenWriteAsync();
                    using var stw = new StreamWriter(str);
                    await stw.WriteAsync(tbox.Text);
                }
            })
        )
      ),
  "memo app", args);
