FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY *.sln .
COPY ToDo.Core/*.csproj ./ToDo.Core/
COPY ToDo.Data/*.csproj ./ToDo.Data/
COPY ToDo.Infrastructure/*.csproj ./ToDo.Infrastructure/
COPY ToDo.Web/*.csproj ./ToDo.Web/

RUN dotnet restore ToDo.Web/ToDo.Web.csproj

COPY ToDo.Core/. ./ToDo.Core/
COPY ToDo.Data/. ./ToDo.Data/
COPY ToDo.Infrastructure/. ./ToDo.Infrastructure/
COPY ToDo.Web/. ./ToDo.Web/

RUN dotnet publish ToDo.Web/ToDo.Web.csproj -c Release -o ./out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "ToDo.Web.dll"]