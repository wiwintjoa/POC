### POC
this is research project for some modules

###Books
use WebAPIThrottle and code first, including local db, just run migrations file and then acces the api:
```
/api/books
```
```
#/api/books/id
```
```
#/api/books/fantasy
```
```
#/api/books/id/details
```

note: the sample api controller based on https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/create-a-rest-api-with-attribute-routing

###Throttle
use actionfilter to implement throttle by limit api end point hit.
```
To access the api, use POSTMAN by do this step:

- Get token from http://jwtauthzsrv.azurewebsites.net/oauth2/token.

- Use this token to get list of users: http://localhost:64589/api/users/GetAll. 

"You must wait 5 seconds before accessing this url again."

sample POSTMAN can be seen in this file: Capture Testing Using Postman.PNG

```

###WebApiThrottle
use WebApiThrottle nuget package to limit api end point hit.

