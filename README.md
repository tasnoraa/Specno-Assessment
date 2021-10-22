



## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Illustrations](#illustrations)

## General info
This is a simple web api for Reddit network where people can dive into their interests, hobbies, and passions.
	
## Technologies
Project is created with:
* ASP.Net Core 3.1
* Microsoft SQL
* Visual Studio 2019
	
## Setup
To run this project:
```
checkout the project from the GIT repo
open the project on Visual Studio
in Visual Studio Package Manager Console run the comman:
PM> update-database

in the table [dbo].[AspNetRoles] insert the values:
values(1,'User', 'User', 'test')
```

## Illustrations
* Run the project with Visual Studio
* Paste the URL http://localhost:36357/swagger to show the controller methods
* Open Postman
* Register a user with the URL http://localhost:36357/api/Account/register
* After registering sign in with the URL 'http://localhost:36357/api/Account/signin
* Copy the authorization token from the response
* Create a new request on Postman with the URL http://localhost:36357/api/reddit/users
* Paste the authorization token to the headers of the above URL
* Past the URL http://localhost:36357/api/reddit/ to show posts, comments, and likes

* To create a post run the URL in postman http://localhost:36357/api/reddit/users and don't forget the token
* To create a comment run the URL http://localhost:36357/api/reddit/comment
* To create a like run the URL http://localhost:36357/api/reddit/like






