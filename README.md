.net webapi 8 with entity framework to postgres db in docker container

demo: https://portfolio-webapi-hkh9cjbkepbha3gu.eastus-01.azurewebsites.net/swagger/index.html



<!-- build image
docker build -t todoapi . 
publish container
docker run -d -p 5001:8080 --name TodoApi TodoApi -->



//create certificate
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p <password>
dotnet dev-certs https --trust

//create application secrets
dotnet user-secrets init -p TodoApi.csproj
dotnet user-secrets -p TodoApi.csproj set "Kestrel:Certificates:Development:Password" "<password>"

<!-- //build and run image and container for ssl
docker pull mcr.microsoft.com/dotnet/samples:aspnetapp
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORTS=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="<password>" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v ${HOME}/.aspnet/https:/https/ mcr.microsoft.com/dotnet/samples:aspnetapp -->

//build and publish image and container for project
docker build --pull -t todoapi .
docker run --rm -it -p 8001:8001 -e ASPNETCORE_HTTPS_PORTS=8001 -e ASPNETCORE_ENVIRONMENT=Development -v ${HOME}/.microsoft/usersecrets/:/root/.microsoft/usersecrets -v ${HOME}/.aspnet/https:/root/.aspnet/https/ todoapi