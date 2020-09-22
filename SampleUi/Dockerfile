FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet publish -c Release -o output

# Build runtime image
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build /app/output/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

