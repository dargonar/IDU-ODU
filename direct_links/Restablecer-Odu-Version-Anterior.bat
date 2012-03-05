@Echo off
taskkill /IM Odu.exe /F
rename "C:\Archivos de programa\Diventi\Odu.exe" "Odu_bkp_%date:/=_%.exe"
rename "C:\Archivos de programa\Diventi\Odu_bkp.exe" Odu.exe

Echo\
Echo Odu ha sido restablecido a la versión anterior. Presione una tecla para continuar e iniciar la aplicación...
Echo\
pause

CALL "C:\Archivos de programa\Diventi\Odu.exe"

pause
exit