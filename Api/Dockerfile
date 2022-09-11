FROM mcr.microsoft.com/dotnet/sdk:3.1.422-alpine3.16 AS build-env
WORKDIR /app

COPY */*.csproj ./
RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1.28-alpine3.16
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Brands.StudioSol.TechLeadTest.dll"]