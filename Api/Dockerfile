FROM mcr.microsoft.com/dotnet/sdk:3.1.422-alpine3.16 AS build
WORKDIR /src

COPY */Brands.StudioSol.TechLeadTest.csproj ./
COPY */Brands.StudioSol.TechLeadTest.GraphQL.csproj ./
COPY */Brands.StudioSol.TechLeadTest.Models.csproj ./
COPY */Brands.StudioSol.TechLeadTest.Services.csproj ./

RUN dotnet restore "Brands.StudioSol.TechLeadTest.csproj"
COPY . .
WORKDIR /src/Brands.StudioSol.TechLeadTest
RUN dotnet build "Brands.StudioSol.TechLeadTest.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Brands.StudioSol.TechLeadTest.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1.28-alpine3.16
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brands.StudioSol.TechLeadTest.dll"]