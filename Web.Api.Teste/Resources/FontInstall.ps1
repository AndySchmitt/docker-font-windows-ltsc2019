$sOriginFolder = "C:\Inetpub\wwwroot\Fonts";
$sDestinyFolder = "C:\Windows\Fonts";
$sRegPath = "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";

$objShell = New-Object -ComObject Shell.Application;

$objFolder = $objShell.namespace($sOriginFolder);
$exclude = Get-ChildItem $sDestinyFolder;

foreach ($objFile in $objFolder.items()) 
{
    $objFileType = $($objFolder.getDetailsOf($objFile, 2));
    $sFontName = $($objFolder.getDetailsOf($objFile, 21));
    $sRegKeyName = $sFontName, "(Open Type)" -join " ";
    $sRegKeyValue = $objFile.Name;

    Copy-Item $objFile.Path $sDestinyFOlder -Exclude $exclude;
    $null = New-ItemProperty -Path $sRegPath -Name $sRegKeyName -Value $sRegKeyValue -PropertyType String -Force;
}