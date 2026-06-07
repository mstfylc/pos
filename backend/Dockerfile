FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY backend/Mansis.Pos.slnx ./backend/Mansis.Pos.slnx
COPY backend/src/Mansis.Pos.Api/Mansis.Pos.Api.csproj ./backend/src/Mansis.Pos.Api/
COPY backend/src/Mansis.Pos.Application/Mansis.Pos.Application.csproj ./backend/src/Mansis.Pos.Application/
COPY backend/src/Mansis.Pos.Contracts/Mansis.Pos.Contracts.csproj ./backend/src/Mansis.Pos.Contracts/
COPY backend/src/Mansis.Pos.Domain/Mansis.Pos.Domain.csproj ./backend/src/Mansis.Pos.Domain/
COPY backend/src/Mansis.Pos.Infrastructure/Mansis.Pos.Infrastructure.csproj ./backend/src/Mansis.Pos.Infrastructure/
COPY backend/src/Mansis.Pos.Workers/Mansis.Pos.Workers.csproj ./backend/src/Mansis.Pos.Workers/
COPY backend/tests/Mansis.Pos.Application.Tests/Mansis.Pos.Application.Tests.csproj ./backend/tests/Mansis.Pos.Application.Tests/

RUN dotnet restore backend/Mansis.Pos.slnx

COPY backend ./backend
RUN dotnet publish backend/src/Mansis.Pos.Api/Mansis.Pos.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Mansis.Pos.Api.dll"]
