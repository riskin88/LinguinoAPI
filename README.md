# Backend webové aplikace na učení se angličtiny Linguino

## Spuštění

Spuštění aplikace je poměrně přímočaré, stačí v prostředí .NET 8 spustit soubor s řešením `LinguinoAPI.sln`. Případně je možné využít kontejnerizaci přes docker-compose, což kromě image s API vytvoří i MSSQL databázi.

## Konfigurační proměnné

Kromě konfiguračních proměnných, které jsou uvedeny v souboru `appsettings.json`, je potřeba pro plnou funkčnost aplikace nadefinovat několik dalších proměnných, které je v zájmu bezpečnosti vhodné udržovat pouze lokálně jako User Secrets. 
Jsou jimi:

- `ConnectionStrings:MSSQL_DB` - připojovací řetězec k MSSQL databázi
- `SecuritySettings:Key` - klíč pro podepisování JWT tokenů, v textové podobě, doporučuji náhodný řetězec o délce alespoň 64 bytů
- `EmailSettings:Password` - heslo k e-mailové schránce specifikované v `appsettings.json`, ze které jsou odesílány autentizační tokeny
- `SubscriptionSettings:StripeApiKey` - klíč pro komunikaci se službou Stripe
- `SubscriptionSettings:WebhookSecret` - klíč pro využívání webhooků služby Stripe

