#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
ARG source

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .

WORKDIR /
#ADD /bin/Fonts/arial*.ttf c:/windows/fonts/
COPY /bin/Resources/FontInstall.ps1 c:/windows/fonts/
ARG CACHEBUSTER=7
WORKDIR /Windows/Fonts

RUN ["powershell.exe", "C:\\Inetpub\\wwwroot\\Fonts\\FontInstall.ps1"]