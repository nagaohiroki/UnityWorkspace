FROM ubuntu:latest
RUN apt-get update 
RUN apt-get install -y curl
RUN apt-get install -y unzip
RUN curl -OL https://github.com/nagaohiroki/UnityWorkspace/releases/download/test/server.zip
RUN unzip ./server.zip
RUN chmod +x ./server/server.x86_64
CMD ./server/server.x86_64