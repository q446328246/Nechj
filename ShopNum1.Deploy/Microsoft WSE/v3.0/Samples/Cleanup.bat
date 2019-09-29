echo off

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
