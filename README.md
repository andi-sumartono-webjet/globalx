# GlobalX Assessment

This project is a solution for GlobalX Coding Assessment. 

The project is structured in accordance to DDD's Onion Layering Structure
https://www.infoq.com/news/2014/10/ddd-onion-architecture

Prerequisites:
> .NET Core 2.1 or ```docker```

To run all unit tests use the following command:
> ```dotnet test```

To run the solution use the following command:
> ```dotnet run ./Sorting.Console/Sorting.Console.csproj ./unsorted-names-list.txt```

Running this command will generate an output file ``sorted-names-list.txt`` at the current folder. 

Optional parameters that you can add with the command:
* ```--method=[quick|bubble]```  
* ```--output=[outputfilepath]```

To the solution using a docker container, you will need to prepare the source file path.
Assuming that the source file is located at ```/tmp/unsorted-names-list.txt``` then the docker commands will be:
```
$ docker build . -t sorting 
$ docker run -v /tmp/unsorted-names-list:/app/unsorted-names-list.txt sorting
```

