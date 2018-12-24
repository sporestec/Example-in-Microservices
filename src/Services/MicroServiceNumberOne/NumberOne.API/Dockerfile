FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52523
EXPOSE 44316

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/MicroServiceNumberOne/NumberOne.API/NumberOne.API.csproj src/Services/MicroServiceNumberOne/NumberOne.API/
RUN dotnet restore src/Services/MicroServiceNumberOne/NumberOne.API/NumberOne.API.csproj
COPY . .
WORKDIR /src/src/Services/MicroServiceNumberOne/NumberOne.API
RUN dotnet build NumberOne.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NumberOne.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NumberOne.API.dll"]
