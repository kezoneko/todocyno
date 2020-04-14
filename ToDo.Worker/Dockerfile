FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY *.sln .
COPY ToDo.Core/*.csproj ./ToDo.Core/
COPY ToDo.Data/*.csproj ./ToDo.Data/
COPY ToDo.Infrastructure/*.csproj ./ToDo.Infrastructure/
COPY ToDo.Worker/*.csproj ./ToDo.Worker/

RUN dotnet restore ToDo.Worker/ToDo.Worker.csproj

COPY ToDo.Core/. ./ToDo.Core/
COPY ToDo.Data/. ./ToDo.Data/
COPY ToDo.Infrastructure/. ./ToDo.Infrastructure/
COPY ToDo.Worker/. ./ToDo.Worker/

RUN dotnet publish ToDo.Worker/ToDo.Worker.csproj -c Release -o ./out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ToDo.Worker.dll"]