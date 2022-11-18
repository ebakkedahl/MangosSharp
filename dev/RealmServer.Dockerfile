FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ./Source/ .
RUN dotnet publish ./RealmServer/RealmServer.csproj -c Release -o bin

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/bin .
COPY ./.docker/configuration.json ./configuration.json
ENTRYPOINT ["./RealmServer"]