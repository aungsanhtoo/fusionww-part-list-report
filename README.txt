1) How to run App
..\bin\Debug\net7.0\
dotnet run or double click fusionPriceList.exe
Then visit: http://localhost:5000

2) Debug Configuration 
Configure `launch.json` for debugging under Run and Debug panel in VS Code.

3) Folder structure 

fusionPriceList/
 │
 ├─ Shared
 │ 	 ├─ _Layout.cshtml
 ├─ Pages
 │   └─  Shared
 │		└─ _Layout.cshtml
 │		└─ _ValidationScriptsPartial.cshtml
 │   └─  _ViewImports.cshtml
 │   └─  _ViewState.cshtml
 │   └─  Error.cshtml
 │		└─ Error.cshtml.cs
 │       └─ErrorModel
 │   └─  Index.cshtml
 │		└─ Index.cshtml.cs
 │       └─IndexModel
 │   └─  Privacy.cshtml
 │		└─ Privacy.cshtml.cs
 │       └─PrivacyModel
 ├─ Program.cs
 ├─ appsettings.json
 └─ fusionPriceList.csproj
