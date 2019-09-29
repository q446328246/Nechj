echo off
REM **
echo ************
echo NOTE: This batch file must be run from a Visual Studio 2005 Command Prompt
echo ************

REM ** This batch file
REM ** 1) Sets the directories and file access privilege depending on the OS.
REM **    This is necessary so that the WSE trace files can be successfully written
REM ** 2) Generates and installs sample certificates into the certificate stores
REM ** 	  for use with the Quickstart samples. 
REM ** 

echo ******* Important ******* 
echo By default ASP.NET v2.0 is not set as the active
echo version when .NET v2.0 is installed on a machine that has either .NET v1.0 or
echo .NET v1.1 already installed.
echo To check which ASP.NET is the default, run the following command from a VS2005 command prompt;
echo aspnet_regiis.exe /lv 
echo and check which version has the (root) name associated with it.
echo If this is not v2.0, then ASP.NET v2.0 can be enabled with the following command;
echo aspnet_regiis.exe /i /e
echo See the Quickstart readme.htm in this directory for more details.
echo ******* Important ******* 

pause

REM ** Access priviledges
echo ************
echo Setting the access privileges on the Quickstart sample directories 
echo so that the account that ASP.NET is running under can write WSE trace/diagnostic files.
echo ************

REM ** This version check only works on English machines.
set WP_ACCOUNT=NT AUTHORITY\NETWORK SERVICE
(ver | findstr "5.1") && set WP_ACCOUNT=%COMPUTERNAME%\ASPNET
cacls.exe . /T /E /G "%WP_ACCOUNT%":F > nul

REM ** Set up the Certificates
set SERVER_NAME=WSE2QuickStartServer
set CLIENT_NAME=WSE2QuickStartClient
set ROUTER_NAME=WSEQuickStartRouter

echo ************
echo Removing any WSE certificates that are already installed
echo ************

REM Server Certs
certmgr -del -r CurrentUser -s AddressBook -c -n %SERVER_NAME%
certmgr -del -r LocalMachine -s My -c -n %SERVER_NAME%

REM Client Cert
certmgr -del -r CurrentUser -s My -c -n %CLIENT_NAME%

REM Router Cert
certmgr -del -r LocalMachine -s My -c -n %ROUTER_NAME%

echo ************
echo Server cert setup starting
echo %SERVER_NAME%
echo ************
echo Making server cert
echo ************
makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe
echo ************
echo Copying server cert to client's CurrentUser store
echo ************
certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s AddressBook

echo ************
echo Client cert setup starting
echo %CLIENT_NAME%
echo ************
echo Making client cert
echo ************
makecert.exe -sr CurrentUser -ss My -a sha1 -n CN=%CLIENT_NAME% -sky exchange -pe
echo ************

echo ************
echo Router cert setup starting
echo %ROUTER_NAME%
echo ************
echo Making router cert
echo ************
makecert.exe -sr LocalMachine -ss My -a sha1 -n CN=%ROUTER_NAME% -sky exchange -pe
echo ************

echo ************
echo Setting access privileges on the certificates depending on the OS
echo ************
echo ************
echo Accessing the LocalMachine Personal Store For the Server Cert.
echo ************
set WP_ACCOUNT=NETWORK SERVICE
(ver | findstr "5.1") && set WP_ACCOUNT=%COMPUTERNAME%\ASPNET
winhttpcertcfg -g -c LOCAL_MACHINE\My -s %SERVER_NAME% -a "%WP_ACCOUNT%"

echo ************
echo Accessing the LocalMachine Personal Store For Router Cert.
echo This is used by the SecureRoutingToUltimateReceiver sample.
echo ************
winhttpcertcfg -g -c LOCAL_MACHINE\My -s %ROUTER_NAME% -a "%WP_ACCOUNT%"

echo ************
echo Restart IIS.
echo ************
iisreset