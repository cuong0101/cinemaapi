

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CinemaManagement.csproj", "."]
RUN dotnet restore "./CinemaManagement.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CinemaManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CinemaManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish
ENTRYPOINT ["dotnet", "CinemaManagement.dll"]