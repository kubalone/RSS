``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.590 (1803/April2018Update/Redstone4)
Intel Core2 Duo CPU E7200 2.53GHz, 1 CPU, 2 logical and 2 physical cores
Frequency=2473956 Hz, Resolution=404.2109 ns, Timer=TSC
.NET Core SDK=3.0.100-preview-010184
  [Host] : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 32bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Core   : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 32bit RyuJIT


```
|       Method |  Job | Runtime |     Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------- |----- |-------- |---------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| StringEquals |  Clr |     Clr | 76.47 ns | 0.3209 ns | 0.3002 ns |           - |           - |           - |                   - |
| StringEquals | Core |    Core | 91.98 ns | 0.2583 ns | 0.2416 ns |           - |           - |           - |                   - |
