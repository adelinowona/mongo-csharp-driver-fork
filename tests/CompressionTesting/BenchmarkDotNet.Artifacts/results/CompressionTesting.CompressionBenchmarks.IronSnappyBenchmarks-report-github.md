``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8259CL CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                     Method | Categories |      which_data |           Mean |         Error |        StdDev |         Median | Ratio | RatioSD |
|--------------------------- |----------- |---------------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|
|          **UnmanagedCompress** |   **Compress** | **156kB_text_file** |   **2,296.084 μs** |     **4.4959 μs** |     **4.2055 μs** |   **2,293.706 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress | 156kB_text_file |   1,098.062 μs |     1.3946 μs |     1.2363 μs |   1,098.111 μs |  0.48 |    0.00 |
|   IronSnappyCompressStream |   Compress | 156kB_text_file |   1,588.488 μs |     2.7696 μs |     2.3128 μs |   1,588.666 μs |  0.69 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress | 156kB_text_file |   1,031.660 μs |     1.7465 μs |     1.5482 μs |   1,031.298 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress | 156kB_text_file |     634.622 μs |     1.7398 μs |     1.4528 μs |     634.661 μs |  0.62 |    0.00 |
| IronSnappyDecompressStream | Decompress | 156kB_text_file |     486.997 μs |     0.3386 μs |     0.3002 μs |     487.043 μs |  0.47 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** | **2.9mb_text_file** |  **41,211.230 μs** |   **412.2883 μs** |   **385.6548 μs** |  **41,345.556 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress | 2.9mb_text_file |  17,903.072 μs |    15.2791 μs |    14.2920 μs |  17,905.238 μs |  0.43 |    0.00 |
|   IronSnappyCompressStream |   Compress | 2.9mb_text_file |  28,482.657 μs |   171.8345 μs |   160.7341 μs |  28,580.554 μs |  0.69 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress | 2.9mb_text_file |  18,416.645 μs |    15.6578 μs |    14.6463 μs |  18,414.334 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress | 2.9mb_text_file |  10,407.265 μs |   202.8071 μs |   189.7059 μs |  10,568.626 μs |  0.57 |    0.01 |
| IronSnappyDecompressStream | Decompress | 2.9mb_text_file |     572.914 μs |    12.6236 μs |    37.2209 μs |     581.760 μs |  0.03 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** |  **27mb_json_file** | **238,072.954 μs** | **3,743.3508 μs** | **3,501.5326 μs** | **241,059.070 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress |  27mb_json_file | 105,614.567 μs |   327.9367 μs |   306.7522 μs | 105,512.873 μs |  0.44 |    0.01 |
|   IronSnappyCompressStream |   Compress |  27mb_json_file | 195,912.765 μs |   773.3414 μs |   723.3840 μs | 196,177.165 μs |  0.82 |    0.01 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress |  27mb_json_file | 137,081.747 μs |    82.7980 μs |    77.4493 μs | 137,048.979 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress |  27mb_json_file |  61,566.214 μs |    27.8293 μs |    23.2387 μs |  61,568.877 μs |  0.45 |    0.00 |
| IronSnappyDecompressStream | Decompress |  27mb_json_file |   1,796.735 μs |     4.8835 μs |     4.5680 μs |   1,799.658 μs |  0.01 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** |  **39kB_json_file** |     **344.349 μs** |     **0.6846 μs** |     **0.6069 μs** |     **344.343 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress |  39kB_json_file |     125.581 μs |     0.8985 μs |     0.8405 μs |     125.113 μs |  0.36 |    0.00 |
|   IronSnappyCompressStream |   Compress |  39kB_json_file |     247.689 μs |     0.3435 μs |     0.2868 μs |     247.747 μs |  0.72 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress |  39kB_json_file |      87.718 μs |     0.3167 μs |     0.2807 μs |      87.654 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress |  39kB_json_file |      37.774 μs |     0.2970 μs |     0.2480 μs |      37.715 μs |  0.43 |    0.00 |
| IronSnappyDecompressStream | Decompress |  39kB_json_file |     180.980 μs |     0.2456 μs |     0.2298 μs |     180.826 μs |  2.06 |    0.01 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** | **490kB_text_file** |   **8,386.718 μs** |     **7.1911 μs** |     **6.0049 μs** |   **8,387.337 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress | 490kB_text_file |   3,786.526 μs |     6.3810 μs |     5.6566 μs |   3,784.944 μs |  0.45 |    0.00 |
|   IronSnappyCompressStream |   Compress | 490kB_text_file |   5,368.196 μs |     7.7547 μs |     6.8743 μs |   5,367.975 μs |  0.64 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress | 490kB_text_file |   3,871.118 μs |    11.7725 μs |    11.0120 μs |   3,870.923 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress | 490kB_text_file |   2,263.520 μs |     7.8085 μs |     7.3041 μs |   2,259.097 μs |  0.58 |    0.00 |
| IronSnappyDecompressStream | Decompress | 490kB_text_file |     539.768 μs |     0.6967 μs |     0.6176 μs |     539.731 μs |  0.14 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** |  **49mb_json_file** | **537,790.833 μs** | **4,584.6808 μs** | **4,288.5133 μs** | **541,359.806 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress |  49mb_json_file | 247,489.661 μs | 1,775.9872 μs | 1,661.2595 μs | 246,174.121 μs |  0.46 |    0.01 |
|   IronSnappyCompressStream |   Compress |  49mb_json_file | 419,491.114 μs | 4,527.8910 μs | 4,235.3921 μs | 423,026.636 μs |  0.78 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress |  49mb_json_file | 296,584.013 μs |   175.0899 μs |   155.2126 μs | 296,552.735 μs | 1.000 |    0.00 |
|  IronSnappyDecompressBlock | Decompress |  49mb_json_file | 153,802.641 μs |    63.4974 μs |    59.3955 μs | 153,806.510 μs | 0.519 |    0.00 |
| IronSnappyDecompressStream | Decompress |  49mb_json_file |   1,474.286 μs |     7.0510 μs |     6.5955 μs |   1,475.913 μs | 0.005 |    0.00 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** |      **randomData** |       **9.736 μs** |     **0.0535 μs** |     **0.0500 μs** |       **9.731 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress |      randomData |       4.503 μs |     0.0849 μs |     0.0753 μs |       4.466 μs |  0.46 |    0.01 |
|   IronSnappyCompressStream |   Compress |      randomData |      37.312 μs |     0.1694 μs |     0.1502 μs |      37.319 μs |  3.83 |    0.02 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress |      randomData |       4.928 μs |     0.0979 μs |     0.1609 μs |       4.900 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress |      randomData |       1.150 μs |     0.0080 μs |     0.0071 μs |       1.150 μs |  0.23 |    0.01 |
| IronSnappyDecompressStream | Decompress |      randomData |      46.957 μs |     0.0516 μs |     0.0483 μs |      46.951 μs |  9.42 |    0.32 |
|                            |            |                 |                |               |               |                |       |         |
|          **UnmanagedCompress** |   **Compress** |  **repetitiveData** |       **8.738 μs** |     **0.1436 μs** |     **0.1343 μs** |       **8.679 μs** |  **1.00** |    **0.00** |
|    IronSnappyCompressBlock |   Compress |  repetitiveData |      15.908 μs |     0.2433 μs |     0.2802 μs |      15.792 μs |  1.83 |    0.05 |
|   IronSnappyCompressStream |   Compress |  repetitiveData |      47.016 μs |     0.1184 μs |     0.0989 μs |      47.018 μs |  5.39 |    0.08 |
|                            |            |                 |                |               |               |                |       |         |
|        UnmanagedDecompress | Decompress |  repetitiveData |      14.079 μs |     0.0517 μs |     0.0431 μs |      14.083 μs |  1.00 |    0.00 |
|  IronSnappyDecompressBlock | Decompress |  repetitiveData |      14.510 μs |     0.0909 μs |     0.0850 μs |      14.468 μs |  1.03 |    0.01 |
| IronSnappyDecompressStream | Decompress |  repetitiveData |      59.596 μs |     0.0226 μs |     0.0211 μs |      59.592 μs |  4.23 |    0.01 |
