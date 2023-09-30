FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MAM.API/MAM.API.csproj", "MAM.API/"]
COPY ["MAM.Users/MAM.Users.csproj", "MAM.Users/"]
COPY ["MAM.Shared/MAM.Shared.csproj", "MAM.Shared/"]
COPY ["MAM.Allergens/MAM.Allergens.csproj", "MAM.Allergens/"]
RUN dotnet restore "MAM.API/MAM.API.csproj"
COPY . .
WORKDIR "/src/MAM.API"
RUN dotnet build "MAM.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MAM.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MAM.API.dll"]
