@Echo off
taskkill /IM Idu.exe /F
rename "C:\Archivos de programa\Diventi\Idu.exe" "Idu_bkp_%date:/=_%.exe"
rename "C:\Archivos de programa\Diventi\Idu_bkp.exe" Idu.exe

Echo\
Echo Idu ha sido restablecido a la versión anterior. Presione una tecla para continuar e iniciar la aplicación...
Echo\
pause

CALL "C:\Archivos de programa\Diventi\Idu.exe"

pause
exit