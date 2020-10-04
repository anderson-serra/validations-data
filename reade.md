## Requirements
* Dotnet Core 3.1 or higher 
* Visual Studio 2019

## Code Coverage
```
dotnet test .\Validations.Data.Tests\Validations.Data.Tests.csproj 
            /p:CollectCoverage=true 
            /p:CoverletOutput=..\coverage 
            /p:CoverletOutputFormat=cobertura 

reportgenerator "-reports:.\coverage.cobertura.xml" "-targetdir:.\report" -reporttypes:Html
```