FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Api/Ecommerce.Product.Api/Ecommerce.Product.Api.csproj", "src/Api/Ecommerce.Product.Api/"]
RUN dotnet restore "src/Api/Ecommerce.Product.Api/Ecommerce.Product.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/Ecommerce.Product.Api"
RUN dotnet build "Ecommerce.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.Product.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Product.Api.dll"]
