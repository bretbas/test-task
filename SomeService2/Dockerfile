FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SomeService2/SomeService2.csproj", "SomeService2/"]
RUN dotnet restore "SomeService2/SomeService2.csproj"
COPY . .
WORKDIR "/src/SomeService2"
RUN dotnet build "SomeService2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SomeService2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SomeService2.dll"]
