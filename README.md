
# TrainManagement
.NET project 3rd year

 Steps to be followed when configuring SSL Certificate and integrate Facebook register

1. Presentation -> Manage NuGet Packages 
-> browse and install : Microsoft.Extensions.Configuration.UserSecrets +  Microsoft.Extensions.SecretManager.Tools

2. Presentation -> Right Click -> Properties -> Debug -> Enable SSL And change App URL to https://localhost:44329/ 
3.  Run SecretsInit.ps1 powershell script from the Presentation folder to add the UserSecrets and initialize the SSL certificate

4. ???
5. Profit
