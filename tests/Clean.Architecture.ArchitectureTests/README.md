## ArchitectureTests

1. Presentazione solution

2. EventTests

  * test naming convention
  * con extension method per mostrare i tipi che falliscono

3. ValueObjectTests

  * VO deve essere sealed
  * VO non può avere proprietà con set pubblici => meet custom rule

4. AggregatesTests

  * AggregateRoot non può avere costruttore default pubblico

5. CoreTests

  * Core non ha dipendenze da Infrastucture, ...

6. CommandTests

  * Comandi solo nel progetto UseCase
  * Comando deve seguire naming convention
  * Comando deve essere un record
