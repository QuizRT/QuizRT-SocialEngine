#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:81"

until dotnet ef migrations add InitialMigrations; do
>&2 echo "SQL Server is starting up"
sleep 1
done

dotnet ef database update

./wait-for-it.sh -t 0 neo4j:7474 -- echo "neo4j is up"

>&2 echo "SQL Server is up - executing command"
exec $run_cmd
