FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Unians.Web.Api/Unians.Web.Api.csproj", "Unians.Web.Api/"]
RUN dotnet restore "Unians.Web.Api/Unians.Web.Api.csproj"
COPY . .
WORKDIR "/src/Unians.Web.Api"
RUN dotnet build "Unians.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Unians.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Unians.Web.Api.dll"]