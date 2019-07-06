FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Unians.Web.Api/Unians.Web.Api.csproj", "Unians.Web.Api/"]
COPY ["Unians.Web.Api.Data/Unians.Web.Api.Data.csproj", "Unians.Web.Api.Data/"]
COPY ["Unians.Web.Api.GraphQL.Data/Unians.Web.Api.GraphQL.Data.csproj", "Unians.Web.Api.GraphQL.Data/"]
COPY ["Unians.Web.Clients/Unians.Web.Clients.csproj", "Unians.Web.Clients/"]
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