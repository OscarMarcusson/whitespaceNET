# WhitespaceNET

This utility enables easy parsing of significant whitespace text, like python or yaml files. It is a useful base for creating custom file formats or programming languages that utilises indentation for scope.

## Full text scan

```csharp
var doc = Hierarchy.FromString(@"
    example: yaml
    with-hierarchy:
        a: 3
        b: Example
    ");
Console.WriteLine(doc.Length);              // 2
Console.WriteLine(doc[0].text);             // example: yaml
Console.WriteLine(doc[1].text);             // width-hierarchy:
Console.WriteLine(doc[1].content.Count);    // 2
Console.WriteLine(doc[1].content[0].text);  // a: 3
Console.WriteLine(doc[1].content[1].text);  // b: Example
```

## Indentation of a single line

```csharp
var indentation = WhitespaceReader.IndentationOf("\t\tHello World");
Console.WriteLine(indentation); // 2
```

It is also possible to supply custom parsing rules with the settings class:

```csharp
var indentation = WhitespaceReader.IndentationOf("      Hello World", new Settings
{
    tabSizeInSpaces = 2
});
Console.WriteLine(indentation); // 3
```
