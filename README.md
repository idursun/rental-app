# rental-app

An incomplete application that demonstrates essential parts of _ports and adapters_ pattern.

## Domain

Contains core domain definitions

## Application

Has a dependency on `Domain` and defines the actual application use cases. Ports needed by the application to carry its tasks but free of the infrastructe code.

## Adapters

Implementations of driver and driven ports against particular infrastructure. (e.g. web, cli, EF Core, etc).
