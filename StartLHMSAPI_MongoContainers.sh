docker run -d --name=mongo mongo;

docker run -d -p 5000:5000 --name=LHMSAPI --link mongo lhmsapi;

docker start mongo;

docker start LHMSAPI;
