FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["HelloDocker/HelloDocker.csproj", "HelloDocker/"]
COPY ["HelloDocker.Domain/HelloDocker.Domain.csproj", "HelloDocker.Infrastructure/HelloDocker.Infrastructure.csproj", "HelloDocker/"]
COPY ["HelloDocker.Infrastructure/HelloDocker.Infrastructure.csproj", "HelloDocker/"]
RUN dotnet restore "HelloDocker/HelloDocker.csproj"
COPY . .
RUN dotnet build "/src/HelloDocker/HelloDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "/src/HelloDocker/HelloDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HelloDocker.dll"]
