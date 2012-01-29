@ECHO OFF
Echo gac.exe /i EasyHook.dll
"%CD%\gac.exe" /i "%CD%\EasyHook.dll"
Echo gac.exe /i ScreenshotInject.dll
"%CD%\gac.exe" /i "%CD%\ScreenshotInject.dll"
Echo gac.exe /i SlimDX.dll
"%CD%\gac.exe" /i "%CD%\SlimDX.dll"
Echo.
Echo.
Echo Done.
Echo Note: To complete installation, please do not forget to restart your machine...
Pause