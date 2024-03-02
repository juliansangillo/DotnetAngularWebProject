FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DotnetAngularWebProject.API/DotnetAngularWebProject.API.csproj", "DotnetAngularWebProject.API/"]
RUN dotnet restore "./DotnetAngularWebProject.API/./DotnetAngularWebProject.API.csproj"
COPY . .
WORKDIR "/src/DotnetAngularWebProject.API"
RUN dotnet build "./DotnetAngularWebProject.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotnetAngularWebProject.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetAngularWebProject.API.dll"]