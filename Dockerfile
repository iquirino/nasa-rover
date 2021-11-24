FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /app
COPY . .
WORKDIR /app/src
RUN dotnet restore
RUN dotnet build "NasaRover.API" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NasaRover.API" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NasaRover.API.dll"]