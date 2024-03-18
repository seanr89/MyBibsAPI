#!/bin/sh

set -e -u #Exit immediately if a command exits with a non-zero status.

echo "Executing script!"

docker run --name postgresbibs \
    -e POSTGRES_USER=postgres_user \
    -e POSTGRES_PASSWORD=4y7sV96vA9wv46VR \
    -e POSTGRES_DB=bibsDb \
    -p 5432:5432 \
    -d postgres

echo "App Complete!"
