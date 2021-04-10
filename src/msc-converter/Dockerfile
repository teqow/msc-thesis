FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /src
COPY *.sln .
COPY msc-converter/*.csproj msc-converter/
RUN dotnet restore "msc-converter/msc-converter.csproj"

COPY . .
WORKDIR "/src/msc-converter"
RUN dotnet build "msc-converter.csproj" -c Release -o /app

RUN dotnet publish "msc-converter.csproj" -c Release -o /app

EXPOSE 80
EXPOSE 57840
ENV ASPNETCORE_URLS=http://*:57840
WORKDIR /app
ENTRYPOINT ["dotnet", "msc-converter.dll"]