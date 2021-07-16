# NuGet restore
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY book.test/*.csproj book.test/
COPY bookapi/*.csproj bookapi/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/bookapi
RUN dotnet build
WORKDIR /src/book.test
RUN dotnet test

# publish
FROM build AS publish
WORKDIR /src/bookapi
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "EmployeeApi.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet bookapi.dll