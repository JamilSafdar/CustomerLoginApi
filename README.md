# Customer Login API
 Before you can use this app you will need to add your own connection string from a DB, and enter 'dotnet run' in the terminal before calling endpoints in Insomnia/Postman
 ## urls:

### add user
POST https://localhost:44380/api/Customer

### delete user
DELETE https://localhost:44380/api/Customer/{CustomerId}

### update user
PUT https://localhost:44380/api/Customer/

### login
GET https://localhost:44380/api/Customer/{CustomerId}
