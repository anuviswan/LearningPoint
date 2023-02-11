#!/bin/bash

mongo <<EOF
var config = {
    "_id": "dbrs",
    "version": 1,
    "members": [
        {
            "_id": 1,
            "host": "mongo.primary:20000",
            "priority": 3
        },
        {
            "_id": 2,
            "host": "mongo.replica.one:20001",
            "priority": 2
        },
        {
            "_id": 3,
            "host": "mongo.replica.two:20002",
            "priority": 1
        }
    ]
};
rs.initiate(config, { force: true });
rs.status();
EOF