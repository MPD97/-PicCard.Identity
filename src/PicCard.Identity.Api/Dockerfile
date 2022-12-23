FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PicCard.Identity.Api/PicCard.Identity.Api.csproj", "src/PicCard.Identity.Api/"]
RUN dotnet restore "src/PicCard.Identity.Api/PicCard.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/PicCard.Identity.Api"
RUN dotnet build "PicCard.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PicCard.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PicCard.Identity.Api.dll"]