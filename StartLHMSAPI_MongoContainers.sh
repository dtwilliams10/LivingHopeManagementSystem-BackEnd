docker stop mongo;

docker stop LHMSAPI;

docker rm mongo;

docker rm LHMSAPI;

docker run -d -p 27017:27017 --name=mongo mongo;

docker run -d -p 5000:5000 --name=LHMSAPI lhmsapi;