FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /src
COPY *.sln .
COPY msc-exchange-rate-provider/*.csproj msc-exchange-rate-provider/
RUN dotnet restore "msc-exchange-rate-provider/msc-exchange-rate-provider.csproj"

COPY . .
WORKDIR "/src/msc-exchange-rate-provider"
RUN dotnet build "msc-exchange-rate-provider.csproj" -c Release -o /app

RUN dotnet publish "msc-exchange-rate-provider.csproj" -c Release -o /app

EXPOSE 80
EXPOSE 44302
ENV ASPNETCORE_URLS=http://*:44302
WORKDIR /app
ENTRYPOINT ["dotnet", "msc-exchange-rate-provider.dll"]