#!/bin/bash
set -e

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Capture the PID of the SQL Server process
pid="$!"

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
sleep 15

# Optionally, you can use a loop to check when SQL Server is ready
# until /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Jaider123# -Q "SELECT 1" > /dev/null 2>&1; do
#     echo "Waiting for SQL Server to be available..."
#     sleep 1
# done

# Run the initialization script
echo "Running the initialization script..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Jaider123# -i /init.sql

# Wait on the SQL Server process
wait $pid