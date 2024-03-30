# custom-dotnet-types-grpc-example

Example of how to share protobuf definitions of custom C# types via nuget

# Example README with instructions on how to use this library

## Grpc

To send custom types like `Money` or `MyCustomType` via gRPC include the `MyCompany.Internal.Types.Grpc` package:

```xml
<PackageReference Include="MyCompany.Internal.Types.Grpc" Version="1.0.0" GeneratePathProperty="true" />
```

Use the MSBuild property `$(Pkg{Package_Name})` to reference the path of the `MyCompany.Internal.Types.Grpc` package and add the package's `Protos` directory to the `AdditionalImportDirs` of protobuf.

```xml
<ItemGroup>
   <Protobuf Include="Protos\*.proto" GrpcServices="Server" AdditionalImportDirs="$(PkgMyCompany_Internal_Types_Grpc)\content\Protos" />
</ItemGroup>
```

Now you can import the `mycompany/internal/types.proto` file to use MyCompany.Internal Types in your Grpc contracts.

- Note: The protobuf plugin of your Jetbrains IDE might complain about not being able to find this directory. To fix this you can click the error and tell the plugin to add the directory to it's settings.

```protobuf
syntax = "proto3";

option csharp_namespace = "MyProject.Api";

import "mycompany/internal/types.proto";

package myproject.api;

service MyService {
  rpc GetOrderAmount (GetOrderAmountRequest) returns (AmountReply);
}

message GetOrderAmountRequest {
  string debt_id = 1;
}

message AmountReply {
  mycompany.internal.types.Money amount = 1;
}
```

The `MyCompany.Internal.Types.Grpc` package also implements the generated types from `mycompany/internal/types.proto` and defines implicit operators for them.
This means you can freely assign a `MyCompany.Internal.Types.Money` to a `MyCompany.Internal.Types.Grpc.Money` and vice-versa.

```c#
var reply = new AmountReply
{
    Amount = new MyCompany.Internal.Types.Money(5, Currency.EUR)
}
```
