#!/bin/bash

dotnet dev-certs https --clean
dotnet dev-certs https -ep ~/.aspnet/https/aspnetapp.pfx -p admin
dotnet dev-certs https --trust
docker-compose up --build -d