```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                | MaxProducts | Mean       | Error      | StdDev     |
|---------------------- |------------ |-----------:|-----------:|-----------:|
| **RunTranslatorStrategy** | **10000**       |   **5.426 ms** |  **0.0647 ms** |  **0.0606 ms** |
| RunAutoMapperStrategy | 10000       |   5.722 ms |  0.0637 ms |  0.0596 ms |
| **RunTranslatorStrategy** | **100000**      |  **62.027 ms** |  **0.8415 ms** |  **0.7871 ms** |
| RunAutoMapperStrategy | 100000      |  65.941 ms |  1.3010 ms |  2.1376 ms |
| **RunTranslatorStrategy** | **1000000**     | **690.400 ms** |  **8.9536 ms** |  **8.3752 ms** |
| RunAutoMapperStrategy | 1000000     | 699.385 ms | 11.8753 ms | 10.5271 ms |
