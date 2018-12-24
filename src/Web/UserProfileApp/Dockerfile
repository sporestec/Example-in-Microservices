FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55747
EXPOSE 44345

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["../UserProfileApp/UserProfileApp.csproj", "../UserProfileApp/"]
RUN dotnet restore "../UserProfileApp/UserProfileApp.csproj"
COPY . .
WORKDIR "/src/../UserProfileApp"
RUN dotnet build "UserProfileApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserProfileApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserProfileApp.dll"]