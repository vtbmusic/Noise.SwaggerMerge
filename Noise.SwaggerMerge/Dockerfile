#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Noise.SwaggerMerge/Noise.SwaggerMerge.csproj", "Noise.SwaggerMerge/"]
RUN dotnet restore "Noise.SwaggerMerge/Noise.SwaggerMerge.csproj"
COPY . .
WORKDIR "/src/Noise.SwaggerMerge"
RUN dotnet build "Noise.SwaggerMerge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Noise.SwaggerMerge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Noise.SwaggerMerge.dll"]