# Wolftech-CC

Programming Challenge C# 
Given a file with departments and child departments 
OID,Title,Color,DepartmentParent_OID 1,US News,#F52612, 2,Crime + Justice,#F52612,1 3,Energy + Environment,#F52612,1 4,Extreme Weather,#F52612,1 5,Space + Science,#F52612,1 6,International News,#EB5F25, 7,Africa,#EB5F25,6 8,Americas,#EB5F25,6 9,Asia,#EB5F25,6 10,Europe,#EB5F25,6 
Create an API using .NET WebApi that will output the department hiearcy as a JSON document. For each node give a count of the descendants. NOTE: The number of descendants is not only the number of children, but the number of children, the childrens children and so on. 
[ 
{ 
"Oid": 1, "Title": "US News", "NumDecendants": 4, "Color": "#F52612", "Departments": [ 
{ 
"Oid": 2, "Title": "Crime + Justice", "NumDecendants": 0, "Color": "#F52612", "Departments": [] }, { 
"Oid": 3, "Title": "Energy + Environment", "NumDecendants": 0, "Color": "#F52612", "Departments": [] }, { 
"Oid": 4, "Title": "Extreme Weather", "NumDecendants": 0, "Color": "#F52612", 
"Departments": [] }, { 
"Oid": 5, "Title": "Space + Science", "NumDecendants": 0, "Color": "#F52612", "Departments": [] } ] }, { 
"Oid": 6, "Title": "International News", "NumDecendants": 4, "Color": "#EB5F25", "Departments": [ 
{ 
"Oid": 7, "Title": "Africa", "NumDecendants": 0, "Color": "#EB5F25", "Departments": [] }, { 
"Oid": 8, "Title": "Americas", "NumDecendants": 0, "Color": "#EB5F25", "Departments": [] }, { 
"Oid": 9, "Title": "Asia", "NumDecendants": 0, "Color": "#EB5F25", "Departments": [] }, { 
"Oid": 10, "Title": "Europe", "NumDecendants": 0, "Color": "#EB5F25", "Departments": [] } 
] } ] 
The implementation 
1. Read the file from disk 
2. Should support in the department hierarchy structure. any depth 
3. Should have tests 
4. Should give a message if parsing of the file fails 
