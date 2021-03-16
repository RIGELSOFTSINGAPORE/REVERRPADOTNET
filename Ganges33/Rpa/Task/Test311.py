list1 = [95,12, 13, 14, 15, 16, 1187, 17, 18, 19, 21, 22, 23, 24, 25, 26, 27,
          28, 29, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,13, 14, 31, 31, 37,
          56, 75, 23, 565]
listcount=list1.count(31)
print(listcount)


list1 = [95,12, 13, 14, 15, 16, 1187, 17, 18, 19, 21, 22, 23, 24, 25, 26, 27,
          28, 29, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,13, 14, 31, 31, 37,
          56, 75, 23, 565]
print(len(list1))

str1 = "ba1bc#23@%s0_ma#d+ra$"
alphabets = digits = special = 0

for i in range(len(str1)):
    if(str1[i] >= 'a' and str1[i] <= 'z'): 
        alphabets = alphabets + 1 
    elif(str1[i] >= '0' and str1[i] <= '9'):
        digits = digits + 1
    else:
        special = special + 1
        
print("\nTotal Number of Alphabets in this String :  ", alphabets)
print("Total Number of Digits in this String :  ", digits)
print("Total Number of Special Characters in this String :  ", special)

