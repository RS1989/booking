#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Cinema.Shows.Booking.Api/Cinema.Shows.Booking.Api.csproj", "Cinema.Shows.Booking.Api/"]
COPY ["Cinema.Shows.Booking/Cinema.Shows.Booking.csproj", "Cinema.Shows.Booking/"]
RUN dotnet restore "Cinema.Shows.Booking.Api/Cinema.Shows.Booking.Api.csproj"
COPY . .
WORKDIR "/src/Cinema.Shows.Booking.Api"
RUN dotnet build "Cinema.Shows.Booking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cinema.Shows.Booking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cinema.Shows.Booking.Api.dll"]


