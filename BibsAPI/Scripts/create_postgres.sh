#!/bin/sh

set -e -u #Exit immediately if a command exits with a non-zero status.

echo "Executing script!"

docker run --name postgresql \
    -e POSTGRES_USER=dbUser \
    -e POSTGRES_PASSWORD=dbPassword \
    -p 5432:5432 \
    -d postgres

echo "App Complete!"
