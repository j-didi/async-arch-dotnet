FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AsyncArch.Worker/AsyncArch.Worker.csproj", "AsyncArch.Worker/"]
COPY ["src/AsyncArch.Infra/AsyncArch.Infra.csproj", "AsyncArch.Infra/"]
COPY ["src/AsyncArch.Core/AsyncArch.Core.csproj", "AsyncArch.Core/"]
RUN dotnet restore "/src/AsyncArch.Worker/AsyncArch.Worker.csproj"
COPY . .
WORKDIR "src/AsyncArch.Worker"
RUN dotnet build "AsyncArch.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsyncArch.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AsyncArch.Worker.dll"]
