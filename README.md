# README

Project to test out and benchmark the [StronglyTypedId](https://github.com/andrewlock/StronglyTypedId) package.

## Passing an argument through a method

Benchmark results for: [PassTroughArgumentBenchmark.cs](Aviv.StronglyTypedIds.Benchmarks/PassThroughArgumentBenchmark.cs).

* `GetHash` method uses `HashCode.Combine` to test the passing of arguments with different methods.
* `ReadOnly` means that the struct itself uses the keyword `readonly`.
* `InKeyword` means method called uses the `in` keyword.

```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3803/22H2/2022Update)
12th Gen Intel Core i5-1245U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 8.0.100
  [Host] : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                          | Mean      | Error     | StdDev    | Min       | Max       | Ratio | Rank | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |----------:|----------:|----------:|----------:|----------:|------:|-----:|-------:|----------:|------------:|
| GetHash_Guid                    |  5.329 ns | 0.0546 ns | 0.0800 ns |  5.204 ns |  5.470 ns |  0.15 |    1 |      - |         - |        0.00 |
| GetHash_UserIdReadOnlyInKeyword |  5.632 ns | 0.1063 ns | 0.1591 ns |  5.384 ns |  5.945 ns |  0.16 |    2 |      - |         - |        0.00 |
| GetHash_UserIdReadOnly_PreBuilt |  5.687 ns | 0.1187 ns | 0.1777 ns |  5.410 ns |  6.144 ns |  0.16 |    2 |      - |         - |        0.00 |
| GetHash_UserIdReadOnly          |  5.694 ns | 0.1008 ns | 0.1477 ns |  5.452 ns |  5.914 ns |  0.16 |    2 |      - |         - |        0.00 |
| GetHash_UserId                  |  5.731 ns | 0.1205 ns | 0.1767 ns |  5.492 ns |  5.953 ns |  0.16 |    2 |      - |         - |        0.00 |
| GetHash_String                  | 36.234 ns | 0.2365 ns | 0.3541 ns | 35.566 ns | 36.836 ns |  1.00 |    3 | 0.0153 |      96 B |        1.00 |

### Conclusions

* `Guid` is the way to go if speed is key.
* Using a `readonly struct` or `struct` will always be faster than `string`, and without **allocations**.

## System.Text.Json & Deserialization

Benchmark results for: [JsonTextBenchmark.cs](Aviv.StronglyTypedIds.Benchmarks/JsonTextBenchmark.cs).

* Done only with source generators (`JsonContext`).

```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3803/22H2/2022Update)
12th Gen Intel Core i5-1245U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 8.0.100
  [Host] : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                 | Mean     | Error   | StdDev  | Min      | Max      | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|----------------------- |---------:|--------:|--------:|---------:|---------:|------:|--------:|-----:|-------:|----------:|------------:|
| Deserialize            | 222.9 ns | 3.53 ns | 5.28 ns | 214.5 ns | 233.4 ns |  1.00 |    0.00 |    1 | 0.0393 |     248 B |        1.00 |
| Deserialize_WithUserId | 255.3 ns | 2.59 ns | 3.88 ns | 248.4 ns | 262.9 ns |  1.15 |    0.03 |    2 | 0.0458 |     288 B |        1.16 |

### Conclusions

* Deserialization takes **more allocations** and **more time** when using an `readonly struct` generated by `StronglyTypedIds`'s package.