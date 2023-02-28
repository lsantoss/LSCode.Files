# LSCode.Files

 ## Application:
Offers codes to facilitate the manipulation of files and directories in projects produced by LSCode.

[![NuGet version (LSCode.Files)](https://img.shields.io/nuget/v/LSCode.Files.svg?style=flat-square)](https://www.nuget.org/packages/LSCode.Files)

---

## Frameworks:
- .Net Standard 2.1

---

## Current features:
- Directory manipulation
- File manipulation
- FTP functionalities

---

## Dependencies:
- Magick.NET-Q8-AnyCPU
- Microsoft.Extensions.DependencyInjection.Abstractions

---

## Dependencies (Test projects):
- Microsoft.NET.Test.Sdk
- NUnit
- NUnit3TestAdapter
- NUnit.Analyzers
- coverlet.collector

---

## How to install:
- Click on the following link and see here some ways to install: [click here](https://www.nuget.org/packages/LSCode.Files "LSCode.Files page on nuget.org").

---

## How to use directory manipulation service:
First install the package, for example:

```xml
<PackageReference Include="LSCode.Files" Version="x.x.x" />
```

In the file where the services used in the application are added (`Startup.cs`, `Program.cs` or others), you must import the following namespace:

```c#
using LSCode.Files.Directories.Extensions;
```

Then add the following line to register the service:

```c#
services.AddDirectoryService();

//or

builder.Services.AddDirectoryService();
```

In the file that you want to use the service, you must import the following namespace:

```c#
using LSCode.Files.Directories.Interfaces;
```

Then add the interface in the constructor:

```c#
using LSCode.Files.Directories.Interfaces;

namespace MyNamespace
{
  public class MyClass
  {
    private readonly IDirectoryService _service;

    public MyClass(IDirectoryService service) => _service = service;
  }
}
```

The following link contains the list of functionalities present in the service. 

Each method has a description of itself, its parameters and return: 

Link: [click here](https://github.com/lsantoss/LSCode.Files/blob/main/src/LSCode.Files/Directories/Interfaces/IDirectoryService.cs "IDirectoryService.cs page on github.com").

---

## How to use file manipulation service:
First install the package, for example:

```xml
<PackageReference Include="LSCode.Files" Version="x.x.x" />
```

In the file where the services used in the application are added (`Startup.cs`, `Program.cs` or others), you must import the following namespace:

```c#
using LSCode.Files.Files.Extensions;
```

Then add the following line to register the service:

```c#
services.AddFileService();

//or

builder.Services.AddFileService();
```

In the file that you want to use the service, you must import the following namespace:

```c#
using LSCode.Files.Files.Interfaces;
```

Then add the interface in the constructor:

```c#
using LSCode.Files.Files.Interfaces;

namespace MyNamespace
{
  public class MyClass
  {
    private readonly IFileService _service;

    public MyClass(IFileService service) => _service = service;
  }
}
```

The following link contains the list of functionalities present in the service. 

Each method has a description of itself, its parameters and return: 

Link: [click here](https://github.com/lsantoss/LSCode.Files/blob/main/src/LSCode.Files/Files/Interfaces/IFileService.cs "IFileService.cs page on github.com").

---

## How to use ftp service:
First install the package, for example:

```xml
<PackageReference Include="LSCode.Files" Version="x.x.x" />
```

In the file where the services used in the application are added (`Startup.cs`, `Program.cs` or others), you must import the following namespace:

```c#
using LSCode.Files.FTP.Extensions;
```

Then add the following line to register the service:

```c#
services.AddFTPService("user", "password");

//or

builder.Services.AddFTPService("user", "password");
```

In the file that you want to use the service, you must import the following namespace:

```c#
using LSCode.Files.FTP.Interfaces;
```

Then add the interface in the constructor:

```c#
using LSCode.Files.FTP.Interfaces;

namespace MyNamespace
{
  public class MyClass
  {
    private readonly IFTPService _service;

    public MyClass(IFTPService service) => _service = service;
  }
}
```

The following link contains the list of functionalities present in the service. 

Each method has a description of itself, its parameters and return: 

Link: [click here](https://github.com/lsantoss/LSCode.Files/blob/main/src/LSCode.Files/FTP/Interfaces/IFTPService.cs "IFTPService.cs page on github.com").

---