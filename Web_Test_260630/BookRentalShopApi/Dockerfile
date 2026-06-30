FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["BookRentalShopApi.csproj", "./"]
RUN dotnet restore "BookRentalShopApi.csproj"

COPY . .
RUN dotnet publish "BookRentalShopApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:9090
EXPOSE 9090

ENTRYPOINT ["dotnet", "BookRentalShopApi.dll"]