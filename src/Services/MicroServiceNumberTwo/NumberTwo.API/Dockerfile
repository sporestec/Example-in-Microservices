FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52526
EXPOSE 44376

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/MicroServiceNumberTwo/NumberTwo.API/NumberTwo.API.csproj src/Services/MicroServiceNumberTwo/NumberTwo.API/
RUN dotnet restore src/Services/MicroServiceNumberTwo/NumberTwo.API/NumberTwo.API.csproj
COPY . .
WORKDIR /src/src/Services/MicroServiceNumberTwo/NumberTwo.API
RUN dotnet build NumberTwo.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NumberTwo.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NumberTwo.API.dll"]
