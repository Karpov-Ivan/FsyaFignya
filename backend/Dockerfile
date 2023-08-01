FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ./FsyaFignya/FsyaFignya.csproj ./FsyaFignya/
COPY ./FsyaFignya.Adapter/FsyaFignya.Adapter/FsyaFignya.Adapter.csproj ./FsyaFignya.Adapter/FsyaFignya.Adapter/
COPY ./FsyaFignya.Common/FsyaFignya.Interfaces/FsyaFignya.Interfaces.csproj ./FsyaFignya.Common/FsyaFignya.Interfaces/
COPY ./FsyaFignya.Common/FsyaFignya.Models/FsyaFignya.Models.csproj ./FsyaFignya.Common/FsyaFignya.Models/
COPY ./FsyaFignya.Adapter/FsyaFignya.DataBase/FsyaFignya.DataBase.csproj ./FsyaFignya.Adapter/FsyaFignya.DataBase/
COPY ./FsyaFignya.Adapter/FsyaFignya.DataBase.Models/FsyaFignya.DataBase.Models.csproj ./FsyaFignya.Adapter/FsyaFignya.DataBase.Models/
COPY ./GettingDataViaAPI/GettingDataViaAPI.csproj ./GettingDataViaAPI/
COPY ./FsyaFignya.Common/FsyaFignya.Common/FsyaFignya.Common.csproj ./FsyaFignya.Common/FsyaFignya.Common/
RUN dotnet restore FsyaFignya/FsyaFignya.csproj

COPY . .

WORKDIR /app/FsyaFignya
RUN dotnet build -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

COPY --from=build /app/build .

ENTRYPOINT ["dotnet", "FsyaFignya.dll"]
