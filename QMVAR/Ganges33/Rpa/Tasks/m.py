#from dbconn import getValidMonth
from dbconn import getExecuteCount 

ExecuteCount,ExecuteDateTime = getExecuteCount("DRS_MONTHLY")

import datetime
year = datetime.datetime.today().strftime('%Y')
month = datetime.datetime.today().strftime('%m')
day1 = datetime.datetime.today().strftime('%d')
#StartDate = str(year)+ "-" + str(month) + "-01"
#EndDate = str(year)+ "-" + str(month) + "-03"
#day1 = '01'

day = 0

try:
    day = int(day1)
except:
    day = day1
if (day > 0 and day < 4):
    StartDate = str(year)+ "-" + str(month) + "-01"
    EndDate = str(year)+ "-" + str(month) + "-03"
elif (day >= 11 and day <= 13):
    StartDate = str(year)+ "-" + str(month) + "-01"
    EndDate = str(year)+ "-" + str(month) + "-03"
elif (day >= 21 and day <= 23):
    StartDate = str(year)+ "-" + str(month) + "-01"
    EndDate = str(year)+ "-" + str(month) + "-03"
else:
    StartDate = str(year)+ "-" + str(month) + "-01"
    EndDate = str(year)+ "-" + str(month) + "-23"
    
    
print(day)
print(StartDate)
print(EndDate)






    
'''
if (ExecuteCount == 0):
    print("Allow to run")
else:
    print("Not Allowed to run")
    
    

print("ExecuteCount: " + str(ExecuteCount))
print("ExecuteDateTime: " + str(ExecuteDateTime))
'''
'''
if (MonthRestriction == 1):
    print("Not allowed to run")
else:
    print("Allowed to run")

''' 
    
    

