FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ContainerManagement-Microservice/ContainerManagement-Microservice.csproj", "ContainerManagement-Microservice/"]
RUN dotnet restore "ContainerManagement-Microservice/ContainerManagement-Microservice.csproj"
COPY . .
WORKDIR "/src/ContainerManagement-Microservice"
RUN dotnet build "ContainerManagement-Microservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ContainerManagement-Microservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContainerManagement-Microservice.dll"]
