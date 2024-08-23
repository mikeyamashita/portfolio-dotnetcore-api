.net webapi 8 with entity framework to postgres db in docker container

demo: https://portfolio-webapi-hkh9cjbkepbha3gu.eastus-01.azurewebsites.net/swagger/index.html



<!-- build image
docker build -t todoapi . 
publish container
docker run -d -p 5001:8080 --name TodoApi TodoApi -->

//github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md

//create certificate
macos/linux:
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p <password>
windows: 
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p <password>
dotnet dev-certs https --trust

//create application secrets
dotnet user-secrets init -p TodoApi.csproj
dotnet user-secrets -p TodoApi.csproj set "Kestrel:Certificates:Development:Password" "<password>"

<!-- //build and run image and container for ssl
docker pull mcr.microsoft.com/dotnet/samples:aspnetapp
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORTS=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="<password>" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v ${HOME}/.aspnet/https:/https/ mcr.microsoft.com/dotnet/samples:aspnetapp -->

//build and publish image and container for project
MacOS/Linux:
docker build --pull -t todoapi .
docker run --rm -it -p 8001:8001 -e ASPNETCORE_HTTPS_PORTS=8001 -e ASPNETCORE_ENVIRONMENT=Development -v ${HOME}/.microsoft/usersecrets/:/root/.microsoft/usersecrets -v ${HOME}/.aspnet/https:/root/.aspnet/https/ todoapi

Windows:
docker build --pull -t todoapi .
docker run --rm -it -p 8001:443 -e ASPNETCORE_URLS="https://+" -e ASPNETCORE_HTTPS_PORTS=8001 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_Kestrel__Certificates__Default__Password="<password>" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v $env:USERPROFILE\.aspnet\https:/https/ todoapi

// create postgres docker container
postgres setup:
docker run --name postgresCont -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -d postgres
dotnet tool install --global dotnet-ef
dotnet ef database update
