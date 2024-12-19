# Dominando o Entity Framework Core

Este projeto fornece uma visão dos principais tópicos e episódios relacionados ao Entity Framework Core, cobrindo configuração, operações de banco de dados e estratégias de carregamento de dados.

# [Configuração, Operações e Estratégias de Carregamento de Dados](/FundamentosEF/src/ConsoleApp-EF-01/Readme.md)


Antes de executar o PendingMigrations:

. Set [FundamentosEF.Data] as startup project;
. Incluir as alterações com Add-Migration

```bash
Add-Migration initial -context ApplicationContext
```


