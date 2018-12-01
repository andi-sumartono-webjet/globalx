# GlobalX Assessment

This project is GlobalX's Coding Assessment. 

This project is structured in accordance to DDD's Onion Layering Structure
https://www.infoq.com/news/2014/10/ddd-onion-architecture

Prerequisites:
> .NET Core 2.1

To run all unit tests
> ```dotnet test```

To run the project run
> ```dotnet run ./Sorting.Console/Sorting.Console.csproj ./unsorted-names-list.txt```

This command will generate an output file at
**./Sorting.Console/sorted-names-list.txt**

Optional parameters:
* ```--method=quick```
* ```--out=[output parameter]```

Providing that you have a file named ```/tmp/unsorted-names-list.txt```, To run through docker
```
$ docker build . -t sorting 
$ docker run -v /tmp/unsorted-names-list:/app/unsorted-names-list.txt sorting
```

