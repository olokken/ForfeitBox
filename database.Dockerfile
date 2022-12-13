# Start with a base image containing MySQL
FROM mysql:8.0

# Add the SQL script that you want to run when the container starts
ADD database.sql /docker-entrypoint-initdb.d/

# Set the default password for the root MySQL user
ENV MYSQL_ROOT_PASSWORD passmajor
