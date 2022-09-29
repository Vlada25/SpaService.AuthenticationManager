#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuthenticationManager.API/AuthenticationManager.API.csproj", "AuthenticationManager.API/"]
COPY ["AuthenticationManager.Database/AuthenticationManager.Database.csproj", "AuthenticationManager.Database/"]
COPY ["AuthenticationManager.Domain/AuthenticationManager.Domain.csproj", "AuthenticationManager.Domain/"]
COPY ["AuthenticationManager.DTO/AuthenticationManager.DTO.csproj", "AuthenticationManager.DTO/"]
COPY ["AuthenticationManager.Interfaces/AuthenticationManager.Interfaces.csproj", "AuthenticationManager.Interfaces/"]
RUN dotnet restore "AuthenticationManager.API/AuthenticationManager.API.csproj"
COPY . .
WORKDIR "/src/AuthenticationManager.API"
RUN dotnet build "AuthenticationManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthenticationManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationManager.API.dll"]