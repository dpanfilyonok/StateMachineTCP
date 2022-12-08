# StateMachineTCP
[![Build And Test](https://github.com/dpanfilyonok/StateMachineTCP/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/dpanfilyonok/StateMachineTCP/actions/workflows/ci.yml)

Simple state machine for TCP sessions.

## Prerequisites
- .NET SDK 6.0

## Build
Once the repo is created from the terminal run:
```shell
dotnet restore
dotnet build
```

## Run
```shell
dotnet run --project .\src\StateMachineTCP\StateMachineTCP.fsproj
```

## Usage
```
USAGE: StateMachineTCP [--help] [--initial-state <closed|listen|syn-sent|syn-rcvd|established|close-wait|last-ack|fin-wait-1|fin-wait-2|closing|time-wait|error>]
                       [--events [<app-passive-open|app-active-open|app-send|app-close|app-timeout|rcv-syn|rcv-ack|rcv-syn-ack|rcv-fin|rcv-fin-ack>...]]

OPTIONS:

    --initial-state, -s <closed|listen|syn-sent|syn-rcvd|established|close-wait|last-ack|fin-wait-1|fin-wait-2|closing|time-wait|error>
                          Specify initial state of tcp state machine.
    --events, -e [<app-passive-open|app-active-open|app-send|app-close|app-timeout|rcv-syn|rcv-ack|rcv-syn-ack|rcv-fin|rcv-fin-ack>...]
                          Specify list of events.
    --help                display this list of options.
```


## Test
```shell
dotnet test
```