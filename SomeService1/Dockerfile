FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SomeService1/SomeService1.csproj", "SomeService1/"]
RUN dotnet restore "SomeService1/SomeService1.csproj"
COPY . .
WORKDIR "/src/SomeService1"
RUN dotnet build "SomeService1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SomeService1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SomeService1.dll"]
