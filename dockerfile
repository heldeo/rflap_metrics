FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore && dotnet add package Microsoft.CodeAnalysis.Analyzers 

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out 
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "rflap_metrics.dll"]



EXPOSE 80