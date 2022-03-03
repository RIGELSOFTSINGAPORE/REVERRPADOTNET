import pyodbc
'''
conn1 = pyodbc.connect('Driver={SQL Server};'
                      'Server=192.168.101.101\SQLEXPRESS,57334;'
                      'Database=SV2;'
                      'User ID=test;Password=hogehoge;Trusted_Connection=no;')
'''
conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=MOHAN\SQLEXPRESS01;'
                      'Database=SV1;'
                      'Trusted_Connection=yes;')

def getExecuteCount(TaskName):
        import datetime
        year = datetime.datetime.today().strftime('%Y')
        month = datetime.datetime.today().strftime('%m')
        StartDate = str(year)+ "-" + str(month) + "-01"
        EndDate = str(year)+ "-" + str(month) + "-03"
        ExecuteCount = 0
        ExecuteDateTime = ""
        cursor = conn.cursor()
        cursor.execute("select StartDateTime from RpaLiveStatus where TaskName='" + str(TaskName) + "' AND LEFT(CONVERT(VARCHAR, STARTDATETIME, 111), 10) >= '" + str(StartDate) +"' AND LEFT(CONVERT(VARCHAR, STARTDATETIME, 111), 10) <= '" + str(EndDate)+ "'")
        records = cursor.fetchall()
        for row in records:
            ExecuteCount = ExecuteCount + 1
            ExecuteDateTime = ExecuteDateTime + "," + str(row[0])
        cursor.close()
        return (ExecuteCount,ExecuteDateTime)
'''
def getValidMonth():
    import re
    import datetime
    import time

    day = int(datetime.datetime.today().strftime('%d'))
    now = datetime.datetime.now()
    dayname = now.strftime("%A")
    #day = 1
    #dayname = "Saturday"
    #day = 2
    #dayname = "Sunday"
    #day = 3
    #dayname = "Monday"
    print("day="+str(day))
    MonthRestriction = 1
    if ( day == 1 ) and  ( (dayname == "Monday") or (dayname == "Tuesday") or (dayname == "Wednesday") or (dayname == "Thursday") or (dayname == "Friday") ):
        MonthRestriction = 0
    elif ( day == 2 ) and  ( (dayname == "Monday") or (dayname == "Tuesday") or (dayname == "Wednesday") or (dayname == "Thursday") or (dayname == "Friday") ):
        MonthRestriction = 0
    elif ( day == 3 ) and  ( (dayname == "Monday") or (dayname == "Tuesday") or (dayname == "Wednesday") or (dayname == "Thursday") or (dayname == "Friday") ):
        MonthRestriction = 0
    else:
        MonthRestriction = 1
    return MonthRestriction
    '''

'''
conn=getconnection()
cursor = conn.cursor()
#cursor.execute('SELECT * FROM dbo.Sample')
cursor.execute(
INSERT INTO rpalog (TaskName,sscname,status,date,starttime,createdby,created_date)
 values('drsdaily','SSC1','NO RECORDS','09/04/2020','13:00:00','Mamatha','09/04/2020')
 )

conn.commit()

import pymysql

# Open database connection
db = pymysql.connect('Admin',"ADMIN/Administrator","","RPASelenium" )

# prepare a cursor object using cursor() method
cursor = db.cursor()

# execute SQL query using execute() method.
cursor.execute("SELECT VERSION()")

# Fetch a single row using fetchone() method.
data = cursor.fetchone()
print ("Database version : %s " % data)

# disconnect from server
db.close()
'''
