# Students Must Have App

## GETTING STARTED

```
# run the docker container with mssql
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=root" \
    -p 1433:1433 --name students_mssql \
    --platform linux/amd64 \
    -v sqlserver-data:/var/opt/mssql \
    -d mcr.microsoft.com/mssql/server:2022-latest
```
