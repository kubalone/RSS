``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.590 (1803/April2018Update/Redstone4)
Intel Core2 Duo CPU E7200 2.53GHz, 1 CPU, 2 logical and 2 physical cores
Frequency=2473956 Hz, Resolution=404.2109 ns, Timer=TSC
.NET Core SDK=3.0.100-preview-010184
  [Host]     : .NET Core ? (CoreCLR 4.6.27129.04, CoreFX 4.6.27129.04), 32bit RyuJIT
  DefaultJob : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 32bit RyuJIT


```
|        Method |     Mean |    Error |   StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|-------------- |---------:|---------:|---------:|------------:|------------:|------------:|--------------------:|
| AddToDatabase | 686.4 us | 31.26 us | 89.70 us |           - |           - |           - |            23.23 KB |
