# ASP.NET BoilerplateのTemplate
- [Startup Templates](https://aspnetboilerplate.com/Templates)で作成

## ASP.Net MVC 5.xのTemplate
- ASP.Net MVC5で作成したTemplateを元に利用Packageの更新後、動作確認を行った際のファイルを初版として登録
- 現在はAsp.Net WebHooksの検証用試作プロジェクトを追加
  - ASP.Net WebHoolsについては、以下を参照
    - GitHub
      - https://github.com/aspnet/AspNetWebHooks
    - ドキュメント
      - https://docs.microsoft.com/en-us/aspnet/webhooks/

#### 動作確認での事前準備
- RDB(SQL Server)にデータベース名「ABPTemplate」でデータベースを作成する。
  - ※データベース名はconnectionStringsと一致していれば任意の名前で良い。
- ABPTemplate.WebプロジェクトのWeb.configにあるconnectionStringsをDBに合わせて設定する。
- ABPTemplate.Webプロジェクトをスタートアッププロジェクトに設定する。

#### 初回起動時に「Abp.AbpException: No language defined!」エラーとなった場合の対応方法
- パッケージマネージャでABPTemplate.EntityFrameworkプロジェクトに対して以下のコマンドを実行する。
```
Update-Database -verbose
```
  - ※参考：https://github.com/aspnetboilerplate/aspnetboilerplate/issues/1192

## ASP.Net Core 2.xのTemplate
- 作成後の状態

