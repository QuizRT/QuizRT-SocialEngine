FROM microsoft/dotnet:sdk AS build-env

COPY . /socialapp

WORKDIR /socialapp

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

RUN chmod +x ./entrypoint.sh
RUN chmod +x ./wait-for-it.sh

CMD /bin/bash ./entrypoint.sh
