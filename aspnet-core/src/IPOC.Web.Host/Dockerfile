FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/IPOC.Web.Host/IPOC.Web.Host.csproj", "src/IPOC.Web.Host/"]
COPY ["src/IPOC.Web.Core/IPOC.Web.Core.csproj", "src/IPOC.Web.Core/"]
COPY ["src/IPOC.Application/IPOC.Application.csproj", "src/IPOC.Application/"]
COPY ["src/IPOC.Core/IPOC.Core.csproj", "src/IPOC.Core/"]
COPY ["src/IPOC.EntityFrameworkCore/IPOC.EntityFrameworkCore.csproj", "src/IPOC.EntityFrameworkCore/"]
WORKDIR "/src/src/IPOC.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/IPOC.Web.Host", "src/IPOC.Web.Host"]
COPY ["src/IPOC.Web.Core", "src/IPOC.Web.Core"]
COPY ["src/IPOC.Application", "src/IPOC.Application"]
COPY ["src/IPOC.Core", "src/IPOC.Core"]
COPY ["src/IPOC.EntityFrameworkCore", "src/IPOC.EntityFrameworkCore"]
WORKDIR "/src/src/IPOC.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "IPOC.Web.Host.dll"]
