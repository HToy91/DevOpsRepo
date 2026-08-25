#get container that has .NET 10 SDK so Docker can compile project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

#copy project into container
COPY ["PolicyCancellationTracker.csproj", "./"]

#download NuGet packages
RUN dotnet restore "PolicyCancellationTracker.csproj"

#copy actual program into the container and complile/publish it
COPY . .

#build application for production
RUN dotnet publish "PolicyCancellationTracker.csproj" \
        -c Release \
        -o /app/publish \
        /p:UseAppHost=false 

#create a smaller container that only needs to run finished application
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

#start application
ENTRYPOINT ["dotnet", "PolicyCancellationTracker.dll"]