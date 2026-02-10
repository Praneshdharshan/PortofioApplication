FROM mcr.microsoft.com/dotnet/nightly/sdk:10.0 AS build
WORKDIR /src

COPY PortofioApplication/ ./PortofioApplication/
WORKDIR /src/PortofioApplication

RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/nightly/aspnet:10.0
WORKDIR /app
COPY --from=build /app .

EXPOSE 8080
ENTRYPOINT ["dotnet", "PortofioApplication.dll"]
