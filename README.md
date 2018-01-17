# TrainManagement
.NET project 3rd year

 Steps to be followed when configuring SSL Certificate and integrate Facebook register

1. Presentation -> Manage NuGet Packages 
-> browse and install : Microsoft.Extensions.Configuration.UserSecrets +  Microsoft.Extensions.SecretManager.Tools
Observation: Run Powershell with administrator rights, having the path to the Presentation csproj 
(example: powershell > cd C:\Users\Elisa\Desktop\NET Proiect\TrainManagement\Presentation)
2. dotnet restore
3. dotnet user-secrets set Authentication:Facebook:AppId 917787695067549 
4. user-secrets set Authentication:Facebook:AppSecret 2fd3dc20dc40073a23691c0ae7516216
5. copy + paste in powershell the following script:

```
# setup certificate properties including the commonName (DNSName) property for Chrome 58+
$certificate = New-SelfSignedCertificate `
    -Subject localhost `
    -DnsName localhost `
    -KeyAlgorithm RSA `
    -KeyLength 2048 `
    -NotBefore (Get-Date) `
    -NotAfter (Get-Date).AddYears(2) `
    -CertStoreLocation "cert:CurrentUser\My" `
    -FriendlyName "Localhost Certificate for .NET Core" `
    -HashAlgorithm SHA256 `
    -KeyUsage DigitalSignature, KeyEncipherment, DataEncipherment `
    -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1") 
$certificatePath = 'Cert:\CurrentUser\My\' + ($certificate.ThumbPrint)  

# create temporary certificate path
$tmpPath = "C:\tmp"
If(!(test-path $tmpPath))
{
New-Item -ItemType Directory -Force -Path $tmpPath
}

# set certificate password here
$pfxPassword = ConvertTo-SecureString -String "YourSecurePassword" -Force -AsPlainText
$pfxFilePath = "c:\tmp\localhost.pfx"
$cerFilePath = "c:\tmp\localhost.cer"

# create pfx certificate
Export-PfxCertificate -Cert $certificatePath -FilePath $pfxFilePath -Password $pfxPassword
Export-Certificate -Cert $certificatePath -FilePath $cerFilePath

# import the pfx certificate
Import-PfxCertificate -FilePath $pfxFilePath Cert:\LocalMachine\My -Password $pfxPassword -Exportable

# trust the certificate by importing the pfx certificate into your trusted root
Import-Certificate -FilePath $cerFilePath -CertStoreLocation Cert:\CurrentUser\Root

# optionally delete the physical certificates (don’t delete the pfx file as you need to copy this to your app directory)
# Remove-Item $pfxFilePath
Remove-Item $cerFilePath
```

6. Login with Facebook :)
