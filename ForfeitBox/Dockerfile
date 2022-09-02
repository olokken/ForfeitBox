#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ForfeitBox.Web/ForfeitBox.Web.csproj", "ForfeitBox.Web/"]
COPY ["ForfeitBox.Entities/ForfeitBox.Entities.csproj", "ForfeitBox.Entities/"]
COPY ["ForfeitBox.Service/ForfeitBox.Service.csproj", "ForfeitBox.Service/"]
COPY ["ForfeitBox.Repository/ForfeitBox.Repository.csproj", "ForfeitBox.Repository/"]
RUN dotnet restore "ForfeitBox.Web/ForfeitBox.Web.csproj"
COPY . .
WORKDIR "/src/ForfeitBox.Web"
RUN dotnet build "ForfeitBox.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ForfeitBox.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForfeitBox.Web.dll"]
