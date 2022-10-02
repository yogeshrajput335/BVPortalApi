# RUN API APPLICATION

** dotnet run ** 
#### Swagger Link (change port number as required)
> https://localhost:7037/swagger/index.html
# REFERENCE
```
https://jasonwatmore.com/post/2021/10/26/net-5-connect-to-mysql-database-with-entity-framework-core
https://www.c-sharpcorner.com/article/rest-api-with-asp-net-6-and-mysql/
```

# MIGRATION 

```
dotnet tool install -g dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef database update YourMigrationName
```

# XAMPP
![Alt text](./Images/XAMPP_ControlPanel.jpg?raw=true "XAMPP Control Panel")
```
Download XAMPP from below link
https://www.apachefriends.org/
Start Apache & MySql
Click ADMIN from Control Panel or http://localhost/phpmyadmin/ in Browser
```

# MYSQL 
```
Database name : blueverseportaldb
Username : bvdbuser
Password : bvdbuser
Global privileges : Check all
```
![Alt text](./Images/CreateServerUser.jpg?raw=true "Create Server User")

# EMAIL SERVICE

* https://jasonwatmore.com/post/2022/03/11/net-6-send-an-email-via-smtp-with-mailkit
* https://ethereal.email/ > jedidiah.hamill63@ethereal.email (uq1xRSC6FzCehSU1dA)


