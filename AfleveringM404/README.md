# 3Semester
TBU for hand-ins and small projects for my 3rd semester. 
# Afleveringsopgave M4.04

## Formål
Projektet har til formål at give erfaring med **anvendelse og opsætning af Cosmos DB** gennem en Azure-konto.

Brugeren kan:
- Se alle supportmeddelelser, som findes i databasen.
- Tilføje nye supportmeddelelser.

Projektet anses som en **proof-of-concept** og skal bearbejdes yderligere.  
Eksempelvis bør der oprettes en container til kunderne, så man kan se historik og detaljerede oplysninger efter behov.

---

## Opsætning af Cosmos DB (i forbindelse med M4.04)

For at oprette en ny Cosmos DB via **Azure CLI** anvendes følgende kommandoer i **GIT BASH**.  
Forudsætning: Du er logget ind og har oprettet den ønskede **resourcegruppe**.

bash
# Opret Cosmos DB account (gratis tier)
az cosmosdb create --name 'dbaccountname' --resource-group 'resourcegruppenavn' --enable-free-tier true

# Opret SQL database
az cosmosdb sql database create --account-name 'dbaccount' --resource-group 'resourcegruppenavn' --name 'dbnavn'

# Opret SQL container
az cosmosdb sql container create --account-name 'dbaccount' --resource-group 'resourcegruppenavn' --database-name 'dbnavn' --name 'containernavn' --partition-key-path "//'key'"

Account, database, container og partition-key-path kan herefter kontrolleres via **Data Explorer** på Azure-websitet.

---

## Status på M4.04

Jeg synes, jeg nåede fint i mål med opgaven jf. opgavebeskrivelsen.  

**Udfordringer:**
- Arbejde via CLI (oplevede diverse problemer som ikke opstod ved manuel oprettelse)
- Form i Blazor

**Fremtidige forbedringer:**
- Tilføje en indikation på, om henvendelsen bliver behandlet, samt af hvilken medarbejder
- Mulighed for, at kunden kan uploade et billede af problemet
