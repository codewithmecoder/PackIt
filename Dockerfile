FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5490

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY PackIt.sln ./

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore -v n
COPY . ./
RUN dotnet build -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "PackIT.Api/PackIT.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5490
ENTRYPOINT ["dotnet", "PackIT.Api.dll"]