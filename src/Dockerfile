FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101 AS build
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

WORKDIR /app/ManageUsersAPI.Data
COPY ManageUsersAPI.Data/*.csproj .

COPY ManageUsersAPI.Data/ .

WORKDIR /app/ManageUsers.API
COPY ManageUsers.API/*.csproj .
RUN dotnet restore 

COPY ManageUsers.API/ .

RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101
WORKDIR /app
COPY --from=build /app/ManageUsers.API/out .
ENTRYPOINT ["dotnet", "ManageUsers.API.dll"]
