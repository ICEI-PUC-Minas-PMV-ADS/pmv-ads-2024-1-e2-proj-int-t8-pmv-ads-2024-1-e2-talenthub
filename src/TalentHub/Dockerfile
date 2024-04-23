FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["TalentHub.csproj", "./"]
RUN dotnet restore "TalentHub.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TalentHub.csproj" -c Release -o /app/build

FROM build AS migrate
WORKDIR /app
COPY --from=build /app/build .
RUN dotnet ef database update --project TalentHub.csproj

FROM build AS publish
RUN dotnet publish "TalentHub.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TalentHub.dll"]
