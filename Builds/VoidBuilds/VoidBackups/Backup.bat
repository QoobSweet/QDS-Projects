set YYYY=%date:~10,4%
set MM=%date:~4,2%
set DD=%date:~7,2%

set HH=%time:~0,2%
if %HH% lss 10 (set HH=0%time:~1,1%)
set NN=%time:~3,2%
set SS=%time:~6,2%

set "TimeStamp=%MM%%DD%%YYYY%_%HH%%NN%"

set arg1=%1
set arg2=%2
H:
cd VoidBackups
rar a backup_%TimeStamp%.rar H:/VoidTmp
