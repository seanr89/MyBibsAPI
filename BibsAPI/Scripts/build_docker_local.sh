#!/bin/sh

set -e -u #Exit immediately if a command exits with a non-zero status.

echo "Executing script!"

docker build . --file Dockerfile --tag latest

echo "App Complete!"
