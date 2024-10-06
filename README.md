# Students Must Have App

## GETTING STARTED

```
# run the docker container with mssql
docker pull mcr.microsoft.com/azure-sql-edge
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=reallyStrongPwd123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=students_mssql mcr.microsoft.com/azure-sql-edge
```
