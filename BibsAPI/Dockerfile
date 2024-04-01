FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# Step 2: Copy project file to the ./ container folder
# COPY *.csproj ./
COPY . ./
# Step 3: Run a restore to download dependencies
RUN dotnet restore

# Step 4: Copy app code to the container
COPY . .
# Step 5: Build the app in Release mode
# Step 6: Publish the application
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine-arm64v8 as runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BibsAPI.dll"]