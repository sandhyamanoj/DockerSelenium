FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out
COPY ./chrome/chromedriver /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
RUN mkdir /app/chrome
COPY --from=build-env /app/out/chromedriver /app/chrome/

# Below is to make chromedriver work in Debian linux container

RUN apt-get update
RUN apt-get install libglib2.0-dev -y
RUN apt-get install libnss3-dev -y

RUN apt-get install wget -y
RUN apt-get install gnupg -y
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN echo 'deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main' |  tee /etc/apt/sources.list.d/google-chrome.list
RUN apt-get update
RUN apt-get install google-chrome-stable -y

ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
