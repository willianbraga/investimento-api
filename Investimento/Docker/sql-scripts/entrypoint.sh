#!/bin/bash

echo "Aguardando SQL iniciar..."
until /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "P4ssW0rd" -C -Q "SELECT 1" &> /dev/null
do
    echo "Aguardando SQL..."
    sleep 5
done

echo "SQL iniciado, executando scripts..."

# Executa os scripts SQL de inicializacao
/opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "P4ssW0rd" -C -d master -i /docker-entrypoint-initdb.d/init-db.sql

echo "Banco de dados inicializado"