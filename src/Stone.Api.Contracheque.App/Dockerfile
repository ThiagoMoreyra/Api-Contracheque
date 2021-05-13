#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Stone.Api.Contracheque.App/Stone.Api.Contracheque.App.csproj", "src/Stone.Api.Contracheque.App/"]
COPY ["src/Stone.Api.Contracheque.Repository/Stone.Api.Contracheque.Repository.csproj", "src/Stone.Api.Contracheque.Repository/"]
COPY ["src/Stone.Api.Contracheque.Domain/Stone.Api.Contracheque.Domain.csproj", "src/Stone.Api.Contracheque.Domain/"]
RUN dotnet restore "src/Stone.Api.Contracheque.App/Stone.Api.Contracheque.App.csproj"
COPY . .
WORKDIR "/src/src/Stone.Api.Contracheque.App"
RUN dotnet build "Stone.Api.Contracheque.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stone.Api.Contracheque.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stone.Api.Contracheque.App.dll"]
