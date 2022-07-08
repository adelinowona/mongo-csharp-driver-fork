``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8259CL CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                   Method | Categories |      which_data |             Mean |           Error |          StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 |   Gen 2 |    Allocated |
|------------------------- |----------- |---------------- |-----------------:|----------------:|----------------:|------:|--------:|--------:|--------:|--------:|-------------:|
|        **UnmanagedCompress** |   **Compress** | **156kB_text_file** |   **2,214,492.2 ns** |       **829.97 ns** |       **735.75 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **68 B** |
|    SnappierCompressBlock |   Compress | 156kB_text_file |     714,700.9 ns |       436.83 ns |       408.61 ns |  0.32 |    0.00 |       - |       - |       - |         73 B |
|   SnappierCompressStream |   Compress | 156kB_text_file |     748,904.7 ns |       259.20 ns |       229.77 ns |  0.34 |    0.00 |  3.9063 |       - |       - |     75,625 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress | 156kB_text_file |     949,913.8 ns |        69.12 ns |        53.96 ns |  1.00 |    0.00 |       - |       - |       - |         65 B |
|  SnappierDecompressBlock | Decompress | 156kB_text_file |     370,294.4 ns |       278.91 ns |       232.91 ns |  0.39 |    0.00 |       - |       - |       - |        153 B |
| SnappierDecompressStream | Decompress | 156kB_text_file |     390,355.0 ns |       168.25 ns |       149.15 ns |  0.41 |    0.00 |       - |       - |       - |        337 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** | **2.9mb_text_file** |  **37,345,742.4 ns** |    **13,277.52 ns** |    **11,770.17 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |        **146 B** |
|    SnappierCompressBlock |   Compress | 2.9mb_text_file |  12,266,232.0 ns |    11,457.61 ns |    10,156.87 ns |  0.33 |    0.00 |       - |       - |       - |         90 B |
|   SnappierCompressStream |   Compress | 2.9mb_text_file |  12,977,981.3 ns |    16,192.79 ns |    13,521.71 ns |  0.35 |    0.00 |       - |       - |       - |  1,501,379 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress | 2.9mb_text_file |  14,413,752.6 ns |    11,662.11 ns |     9,738.39 ns |  1.00 |    0.00 |       - |       - |       - |         82 B |
|  SnappierDecompressBlock | Decompress | 2.9mb_text_file |   6,540,169.3 ns |    10,457.95 ns |     9,782.38 ns |  0.45 |    0.00 |       - |       - |       - |        161 B |
| SnappierDecompressStream | Decompress | 2.9mb_text_file |   6,577,401.7 ns |    19,705.40 ns |    18,432.45 ns |  0.46 |    0.00 |       - |       - |       - |        345 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** |  **27mb_json_file** | **206,711,292.1 ns** |    **44,107.92 ns** |    **39,100.52 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |        **637 B** |
|    SnappierCompressBlock |   Compress |  27mb_json_file |  66,676,932.2 ns |    21,017.42 ns |    18,631.39 ns |  0.32 |    0.00 |       - |       - |       - |        216 B |
|   SnappierCompressStream |   Compress |  27mb_json_file |  74,616,962.4 ns |   301,725.67 ns |   282,234.38 ns |  0.36 |    0.00 |       - |       - |       - |  8,771,118 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress |  27mb_json_file |  86,717,775.7 ns |    15,625.23 ns |    12,199.15 ns |  1.00 |    0.00 |       - |       - |       - |        256 B |
|  SnappierDecompressBlock | Decompress |  27mb_json_file |  45,467,726.0 ns |    63,396.62 ns |    59,301.24 ns |  0.52 |    0.00 |       - |       - |       - |        248 B |
| SnappierDecompressStream | Decompress |  27mb_json_file |  45,857,054.6 ns |    64,108.25 ns |    59,966.89 ns |  0.53 |    0.00 |       - |       - |       - |        441 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** |  **39kB_json_file** |     **324,851.5 ns** |        **73.47 ns** |        **68.73 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **65 B** |
|    SnappierCompressBlock |   Compress |  39kB_json_file |      67,462.8 ns |       216.62 ns |       202.63 ns |  0.21 |    0.00 |       - |       - |       - |         96 B |
|   SnappierCompressStream |   Compress |  39kB_json_file |      73,947.2 ns |        29.47 ns |        26.12 ns |  0.23 |    0.00 |       - |       - |       - |        320 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress |  39kB_json_file |      73,245.8 ns |        36.32 ns |        32.20 ns |  1.00 |    0.00 |       - |       - |       - |         64 B |
|  SnappierDecompressBlock | Decompress |  39kB_json_file |      32,614.1 ns |        65.57 ns |        54.76 ns |  0.45 |    0.00 |       - |       - |       - |        152 B |
| SnappierDecompressStream | Decompress |  39kB_json_file |      38,162.2 ns |        43.30 ns |        38.38 ns |  0.52 |    0.00 |       - |       - |       - |        336 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** | **490kB_text_file** |   **7,900,151.8 ns** |     **3,171.29 ns** |     **2,811.26 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **83 B** |
|    SnappierCompressBlock |   Compress | 490kB_text_file |   2,488,170.4 ns |     1,827.21 ns |     1,525.80 ns |  0.31 |    0.00 |       - |       - |       - |         77 B |
|   SnappierCompressStream |   Compress | 490kB_text_file |   2,670,732.4 ns |     3,055.29 ns |     2,857.92 ns |  0.34 |    0.00 | 54.6875 | 54.6875 | 54.6875 |    304,050 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress | 490kB_text_file |   3,414,609.0 ns |       722.23 ns |       640.24 ns |  1.00 |    0.00 |       - |       - |       - |         68 B |
|  SnappierDecompressBlock | Decompress | 490kB_text_file |   1,405,838.9 ns |       438.32 ns |       410.00 ns |  0.41 |    0.00 |       - |       - |       - |        154 B |
| SnappierDecompressStream | Decompress | 490kB_text_file |   1,489,878.6 ns |     1,347.15 ns |     1,260.12 ns |  0.44 |    0.00 |       - |       - |       - |        338 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** |  **49mb_json_file** | **488,818,201.9 ns** |   **105,910.90 ns** |    **93,887.25 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |      **1,216 B** |
|    SnappierCompressBlock |   Compress |  49mb_json_file | 163,438,774.9 ns |    41,636.06 ns |    38,946.39 ns |  0.33 |    0.00 |       - |       - |       - |        502 B |
|   SnappierCompressStream |   Compress |  49mb_json_file | 181,734,551.2 ns |    59,474.25 ns |    55,632.25 ns |  0.37 |    0.00 |       - |       - |       - | 19,878,645 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress |  49mb_json_file | 196,369,311.4 ns | 2,096,613.81 ns | 1,961,173.86 ns |  1.00 |    0.00 |       - |       - |       - |      1,717 B |
|  SnappierDecompressBlock | Decompress |  49mb_json_file |  92,781,501.2 ns |    28,881.48 ns |    25,602.68 ns |  0.47 |    0.00 |       - |       - |       - |        439 B |
| SnappierDecompressStream | Decompress |  49mb_json_file |  96,825,663.2 ns |    26,188.24 ns |    23,215.19 ns |  0.49 |    0.01 |       - |       - |       - |        615 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** |      **randomData** |       **4,800.4 ns** |        **40.21 ns** |        **37.62 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **64 B** |
|    SnappierCompressBlock |   Compress |      randomData |       2,374.1 ns |        11.58 ns |        10.84 ns |  0.49 |    0.00 |  0.0038 |       - |       - |         96 B |
|   SnappierCompressStream |   Compress |      randomData |       4,140.6 ns |         8.62 ns |         8.07 ns |  0.86 |    0.01 |  0.0153 |       - |       - |        320 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress |      randomData |         463.9 ns |         1.08 ns |         0.96 ns |  1.00 |    0.00 |  0.0029 |       - |       - |         64 B |
|  SnappierDecompressBlock | Decompress |      randomData |         493.2 ns |        10.10 ns |        18.96 ns |  1.04 |    0.07 |  0.0081 |       - |       - |        152 B |
| SnappierDecompressStream | Decompress |      randomData |       2,286.9 ns |         4.19 ns |         3.92 ns |  4.93 |    0.01 |  0.0153 |       - |       - |        336 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|        **UnmanagedCompress** |   **Compress** |  **repetitiveData** |       **6,225.1 ns** |        **39.14 ns** |        **36.61 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **64 B** |
|    SnappierCompressBlock |   Compress |  repetitiveData |       2,892.4 ns |         1.58 ns |         1.40 ns |  0.46 |    0.00 |  0.0038 |       - |       - |         96 B |
|   SnappierCompressStream |   Compress |  repetitiveData |       4,623.0 ns |         6.42 ns |         6.00 ns |  0.74 |    0.00 |  0.0153 |       - |       - |        320 B |
|                          |            |                 |                  |                 |                 |       |         |         |         |         |              |
|      UnmanagedDecompress | Decompress |  repetitiveData |      10,697.7 ns |         4.68 ns |         4.38 ns |  1.00 |    0.00 |       - |       - |       - |         64 B |
|  SnappierDecompressBlock | Decompress |  repetitiveData |       1,987.9 ns |         0.50 ns |         0.44 ns |  0.19 |    0.00 |  0.0076 |       - |       - |        152 B |
| SnappierDecompressStream | Decompress |  repetitiveData |       3,270.0 ns |         0.99 ns |         0.88 ns |  0.31 |    0.00 |  0.0153 |       - |       - |        336 B |
