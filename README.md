# dotnet10_nxui_study1

## 概要
* .NET 10 で追加されるファイルベースアプリで NXUI を試す

NXUI (next-gen UI)  
https://github.com/wieslawsoltes/NXUI  

## 詳細

### 実行方法
```sh
dotnet ex1.cs
```

### ビルド方法
```sh
dotnet publish ex1.cs -o ./bin/ex1
```
Windows
```
./bin/ex1/ex1.exe
```
Linux
```
./bin/ex1/ex1
```

### ex1
公式サンプルまま

![alt text](docs/images/1752971557364.png)

### ex2
ほぼ公式サンプルのカウンター

![alt text](docs/images/1752971872479.png)

### ex3
カウンターの値保持に BehaviorSubject を使ったサンプル

![alt text](docs/images/1752971924342.png)

### ex4
カウンターの値保持に BehaviorSubject + State を使ったサンプル
※ボタン中央寄せ

![alt text](docs/images/1752972027753.png)

### ex5
ex4 にカウントダウン追加

![alt text](docs/images/1752972161588.png)

### ex6
【NXUI】C#でワンライナー・クロスプラットホームデスクトップアプリ【AvaloniaUI】
https://zenn.dev/inuinu/articles/528550aab764e8

![alt text](docs/images/1752972226008.png)

### ex7
ex6 を BehaviorSubject + State に変えたり少しアレンジ

![alt text](docs/images/1752972309688.png)

### ex8
入力チェック

![alt text](docs/images/1752972402728.png)

### ex9
同じ値を参照するコントロールの連動の確認

![alt text](docs/images/1752972486088.png)

### ex10
MessageBox.Avalonia を試す

![alt text](docs/images/1752972569931.png)  
![alt text](docs/images/1752972619653.png)

### ex11, ex12
DialogHost.Avalonia を試す  
※ex12 はメソッドチェーンで書いてみたやつ

![alt text](docs/images/1753135651798.png)  
![alt text](docs/images/1753135680533.png)

