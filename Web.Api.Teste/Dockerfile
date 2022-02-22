#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
ARG source

SHELL ["powershell", "-NoProfile", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

WORKDIR /inetpub/wwwroot

ARG CACHEBUSTER=10

COPY /bin/Fonts/ c:/windows/fonts/
COPY /bin/Resources/FontLink.reg c:/registries/
COPY /bin/Resources/FontsReg.reg c:/registries/

CMD reg import C:\registries\FontsReg.reg
CMD reg import C:\registries\FontLink.reg

COPY ${source:-obj/Docker/publish} .

#COPY /bin/Fonts/ c:/inetpub/wwwroot/fonts/
#COPY /bin/Resources/FontInstall2.ps1 c:/windows/fonts/
#RUN C:\windows\fonts\FontInstall2.ps1 "C:/inetpub/wwwroot/Fonts/"

#RUN powershell.exe -Command \
  #$ErrorActionPreference = 'Stop'; \
  #Start-Process 'C:\\Inetpub\\wwwroot\\Fonts\\FontInstall.ps1';

#WORKDIR /
##ADD /bin/Fonts/arial*.ttf c:/windows/fonts/
#COPY /bin/Resources/FontInstall.ps1 c:/windows/fonts/
#ARG CACHEBUSTER=7
#WORKDIR /Windows/Fonts

#RUN ["powershell.exe", "C:\\Inetpub\\wwwroot\\Fonts\\FontInstall.ps1"]