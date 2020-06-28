# Intro to this Microservice

This is an Aspnet microservices that allows you to manage users, you can `add_user, remove_user, set_user_first_name, set_user_last_name, change_user_email, set_user_phone, get_user_first_name`. 

    see swagger docs at http:localhost:5000/

# Dependencies

**ManageUsersMicroservice** depends on the following nuget packages

    - [Microsoft.AspNetCore.Authentication.JwtBearer ](Microsoft.AspNetCore.Authentication.JwtBearer --version 5.0.0-preview.6.20312.15)
    - [Microsoft.EntityFrameworkCore.SqlServer](Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0-preview.6.20312.4)
    - [Microsoft.EntityFrameworkCore.Tools](Microsoft.EntityFrameworkCore.Tools --version 5.0.0-preview.6.20312.4)
    - [Swashbuckle.AspNetCore.Swagger](Swashbuckle.AspNetCore.Swagger --version 5.5.1)

# Installation or Running

If you are using dotnet, Execute the following command in the ManageUsers.API deirectory
    
    dotnet run

if you are using docker, Execute the following commands

    docker-compose up -d --build(if you and running for the first time)

    docker-compose up -d


# Configuring Bearer Token
To configure token, we make a post request to the authentication endpoint with

    https:localhost:5001/Authentication

with 2 Json properties
    
    {
        "UserName" = "Virifortissimi",
        "Password" = "DEV@12345",
    }

A successful response:

    {
        "userId": 1,
        "firstName": "Eghosa",
        "lastName": "Gabriel",
        "password": null,
        "userName": "Virifortissimi",
        "token": "token"
    }

