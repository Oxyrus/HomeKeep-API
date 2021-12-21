# HomeKeep-API
[![Master](https://github.com/Oxyrus/HomeKeep-API/actions/workflows/master_homekeep.yml/badge.svg)](https://github.com/Oxyrus/HomeKeep-API/actions/workflows/master_homekeep.yml)

HomeKeep API

## Working with migrations

Because the startup project and the migrations project are different, first we have to change directory into the infrastructure project. All the commands must use the `--startup-project ../HomeKeep.Api` flag.

For example

```
HomeKeep.Infrastructure> dotnet ef --startup-project ../HomeKeep.Api migrations add Initial
```
