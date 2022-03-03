echo  %date%-%time% >> C:\QMVAR2.0\LiveSource\Ganges33\\rpa\scheduler\log\queue.txt 
echo scheduler >> TEST_MONTHLY.txt 
echo %date%-%time% >> TEST_MONTHLY.txt 
schtasks /Create /tn "TEST_MONTHLY" /XML C:\QMVAR2.0\LiveSource\Ganges33\\rpa\tasks\DRS_MONTHLY20210617144556.bat.xml /RU REVERPRO /RP ReverGssEv2010 >> C:\QMVAR2.0\LiveSource\Ganges33\\rpa\scheduler\log\queue.txt 
echo  %date%-%time% >> C:\QMVAR2.0\LiveSource\Ganges33\\rpa\scheduler\log\queue.txt 
echo scheduler >> SAW_DISCOUNT_2ND_MONTHLY.txt 
echo %date%-%time% >> SAW_DISCOUNT_2ND_MONTHLY.txt 
schtasks /Create /tn "SAW_DISCOUNT_2ND_MONTHLY" /XML C:\QMVAR2.0\LiveSource\Ganges33\\rpa\tasks\SAW_DISCOUNT_MONTHLY20210702104854.bat.xml /RU REVERPRO /RP ReverGssEv2010 >> C:\QMVAR2.0\LiveSource\Ganges33\\rpa\scheduler\log\queue.txt 
