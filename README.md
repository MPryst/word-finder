# Word Finder
## 1. Build the solution
```
dotnet publish -c Release
```

## 2. Run the console example
```
 ./Challenge.WordFinder.Console/bin/Release/net8.0/publish/Challenge.WordFinder.Console.exe
 ```

 ## 3. Run the tests
 ```
dotnet test
```

## 4. Usage from other applications
Copy the Challenge.WordFinder.Library solution and add a reference to it, or use the .dll

## 5. Analysis
The WordFinder constructor is O(N^2). It goes through every character once, filling out the frequency dictionary.


The Find function is O(N). For every word, it gets the coordinates matching the first character in it, and then checks for valid occurences. The worst scenario would be to read a full row/column.