# DeutscheBankDraw
Deutsche Bank Coding Assignment

## Getting Started

### Prerequisites

It is possible to run this application without the need to install [DotNetCore](https://dotnet.microsoft.com/download) but docker is required and network access to [Microsoft docker registry](https://mcr.microsoft.com).

* [Windows](https://docs.docker.com/windows/started)
* [OS X](https://docs.docker.com/mac/started/)
* [Linux](https://docs.docker.com/linux/started/)


## Running the tests

I have implemented only unit tests

To run all tests execute*
```
docker run --rm -i -v $(PWD):/app -w /app mcr.microsoft.com/dotnet/core/sdk sh -c 'dotnet test'
```
Or (Only tested on Windows gitbash)
```
./test.sh
```

## Running the application

To run the application*
```
docker run --rm -i -v $(PWD):/app -w /app mcr.microsoft.com/dotnet/core/sdk sh -c 'dotnet run --project ./deutscheBankDraw/deutscheBankDraw.csproj'
```
Or (Only tested on Windows gitbash)
```
./test.sh
```

*On windows access to the drive in which the application has been checkedout from is required [instructions](https://blogs.msdn.microsoft.com/wael-kdouh/2017/06/26/enabling-drive-sharing-with-docker-for-windows/)