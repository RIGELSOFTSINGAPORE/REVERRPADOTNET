set datetimef=%date%_%time:~0,2%-%time:~3,2%_%time:~6,2%
set datetimef=%datetimef: =0%
del schedulername.txt
echo start >> C:\inetpub\wwwroot\qmvar\rpa\temp\schedulername.txt
echo %date%-%time% >> C:\inetpub\wwwroot\qmvar\rpa\temp\schedulername.txt
echo "Start " %datetimef% >> C:\inetpub\wwwroot\qmvar\rpa\tasks\log\schedulername.log
SET PATH=%PATH%;C:\Users\Administrator\AppData\Local\Programs\Python\Python36
set datetimef2=%date%_%time:~0,2%-%time:~3,2%_%time:~6,2%
set datetimef2=%datetimef2: =0%
"C:\Users\Administrator\AppData\Local\Programs\Python\Python36\python.exe" C:\inetpub\wwwroot\qmvar\rpa\tasks\SAW_DISCOUNT_MONTHLY_V1.py schedulername
echo "End " %datetimef2% >> C:\inetpub\wwwroot\qmvar\rpa\tasks\log\schedulername.log
del schedulername.txt
echo end >> C:\inetpub\wwwroot\qmvar\rpa\temp\schedulername.txt
echo %date%-%time% >> C:\inetpub\wwwroot\qmvar\rpa\temp\schedulername.txt