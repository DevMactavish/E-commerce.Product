# E-commerce.Product

## Instrunctions
- [ ] Firstly run this docker command. This command Create Db Docker container.(This code commented at docker-compose file. Because Db container created but did not warm-up.)
```
docker run  --name db -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=SU2orange!' -p 1433:1433  -d mcr.microsoft.com/azure-sql-edge:latest;   
```
- [ ] Wait 30 seconds.
- [ ] Go to Solution file path.
- [ ] Run this command()
```
docker compose up   
```

### Notes
- All containers going to run on docker.
- For Kibana wait 2-3 minutes for configuration.
- Elastic index will be added automatically.
- You can change index name on appsettings.json if you want.

# Have Fun