FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Sorting.Console/Sorting.Console.csproj", "Sorting.Console/"]
RUN dotnet restore "Sorting.Console/Sorting.Console.csproj"
COPY . .
WORKDIR "/src/Sorting.Console"
RUN dotnet build "Sorting.Console.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sorting.Console.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sorting.Console.dll", "./unsorted-names-list.txt"]
