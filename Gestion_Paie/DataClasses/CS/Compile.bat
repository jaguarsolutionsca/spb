@ECHO OFF
ECHO --------------------- DELETING FILE
IF EXIST Gestion_Paie.DataClasses.dll del /Q Gestion_Paie.DataClasses.*
ECHO.
ECHO.

ECHO --------------------- CREATING BIN AND PublicPrivateKey DIRECTORIES
IF NOT EXIST "..\..\Bin" MD "..\..\Bin"
if errorlevel 1 goto ERROR
IF NOT EXIST "..\..\PublicPrivateKey" MD "..\..\PublicPrivateKey"
if errorlevel 1 goto ERROR
ECHO.

ECHO --------------------- CREATING STRONG NAME
IF NOT EXIST "..\..\PublicPrivateKey\Gestion_Paie.snk" "%OLYMARS_LATEST_FXSDK%\sn.exe" -k "..\..\PublicPrivateKey\Gestion_Paie.snk"
if errorlevel 1 goto ERROR
IF NOT EXIST "..\..\PublicPrivateKey\PublicKey.snk" "%OLYMARS_LATEST_FXSDK%\sn.exe" -p "..\..\PublicPrivateKey\Gestion_Paie.snk" "..\..\PublicPrivateKey\PublicKey.snk"
if errorlevel 1 goto ERROR
COPY "..\..\PublicPrivateKey\PublicKey.snk" "..\..\Bin"
COPY "..\..\PublicPrivateKey\PublicKey.snk" "."
if errorlevel 1 goto ERROR
ECHO.

ECHO --------------------- COMPILING C# CODE
"%OLYMARS_LATEST_FXBIN%\csc.exe" /debug /doc:..\Gestion_Paie.DataClasses.XML /t:library /r:System.dll /r:System.Data.dll /r:System.Xml.dll /r:System.EnterpriseServices.dll /out:Gestion_Paie.DataClasses.dll Common\*.cs *.cs ..\..\Version\CS\*.cs
if errorlevel 1 goto ERROR
ECHO.

ECHO --------------------- TURNING OFF SIGNATURE VERIFICATION
"%OLYMARS_LATEST_FXSDK%\sn.exe" -Vr Gestion_Paie.DataClasses.dll
if errorlevel 1 goto ERROR
ECHO.

ECHO --------------------- RESIGNING ASSEMBLY
ECHO YOU WILL NEED TO SIGN THIS ASSEMBLY USING THE
ECHO FOLLOWING COMMAND LINE:
ECHO "%OLYMARS_LATEST_FXSDK%\sn.exe" -R Gestion_Paie.DataClasses.dll ..\..\PublicPrivateKey\Gestion_Paie.snk

ECHO.
ECHO.

GOTO END

:ERROR
ECHO.
ECHO.
ECHO.
ECHO --------------------- WARNING !!!!! AN ERROR HAS OCCURED !
ECHO.


:END
if "%1" == "" pause
