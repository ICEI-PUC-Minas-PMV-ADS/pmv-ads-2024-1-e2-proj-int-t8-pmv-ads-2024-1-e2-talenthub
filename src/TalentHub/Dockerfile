FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:latest AS sdk
WORKDIR /src
COPY ["TalentHub.csproj", "./"]
RUN dotnet restore "TalentHub.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TalentHub.csproj" -c Release -o /app/build

FROM sdk AS migration
WORKDIR /app
COPY --from=sdk /app/build .
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

FROM sdk AS publish
RUN dotnet publish "TalentHub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TalentHub.dll"]
