#!/bin/bash

docker-compose up -d

timeout  /t 10 /nobreak

docker exec -it mongo.primary mongosh --eval "rs.initiate({_id:'dbrs', members: [{_id:0, host: 'mongo.primary'},{_id:1, host: 'mongo.replica.one'},{_id:2, host: 'mongo.replica.two'}]})"