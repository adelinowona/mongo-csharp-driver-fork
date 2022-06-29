``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8259CL CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|               Method | Categories |      which_data |           Mean |         Error |        StdDev |         Median | Ratio | RatioSD |
|--------------------- |----------- |---------------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|
|    **UnmanagedCompress** |   **Compress** | **156kB_text_file** |   **2,293.749 μs** |     **3.9079 μs** |     **3.6555 μs** |   **2,292.164 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress | 156kB_text_file |   4,011.837 μs |     4.4593 μs |     4.1713 μs |   4,010.137 μs |  1.75 |    0.00 |
|   ZstdCompressStream |   Compress | 156kB_text_file |   1,753.820 μs |     6.0290 μs |     5.6396 μs |   1,755.266 μs |  0.76 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress | 156kB_text_file |   1,025.917 μs |     1.4334 μs |     1.1969 μs |   1,025.503 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress | 156kB_text_file |     416.710 μs |     0.7344 μs |     0.6870 μs |     416.399 μs |  0.41 |    0.00 |
| ZstdDecompressStream | Decompress | 156kB_text_file |     381.747 μs |     0.5288 μs |     0.4415 μs |     381.730 μs |  0.37 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** | **2.9mb_text_file** |  **41,313.023 μs** |    **91.2188 μs** |    **85.3261 μs** |  **41,281.048 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress | 2.9mb_text_file |  55,216.622 μs |    55.3258 μs |    46.1996 μs |  55,198.633 μs |  1.34 |    0.00 |
|   ZstdCompressStream |   Compress | 2.9mb_text_file |  25,765.573 μs |    32.6084 μs |    27.2295 μs |  25,764.035 μs |  0.62 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress | 2.9mb_text_file |  18,670.149 μs |     7.2710 μs |     6.4455 μs |  18,670.864 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress | 2.9mb_text_file |   5,517.704 μs |     7.7474 μs |     6.0487 μs |   5,517.148 μs |  0.30 |    0.00 |
| ZstdDecompressStream | Decompress | 2.9mb_text_file |   6,789.399 μs |   135.4948 μs |   288.7504 μs |   7,053.763 μs |  0.36 |    0.02 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** |  **27mb_json_file** | **237,348.093 μs** |   **954.7184 μs** |   **893.0442 μs** | **237,882.763 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress |  27mb_json_file | 387,949.418 μs |   606.2260 μs |   567.0641 μs | 388,040.340 μs |  1.63 |    0.01 |
|   ZstdCompressStream |   Compress |  27mb_json_file | 189,173.254 μs |   704.4032 μs |   658.8992 μs | 189,113.288 μs |  0.80 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress |  27mb_json_file | 130,769.554 μs | 2,522.0252 μs | 2,904.3680 μs | 130,763.279 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress |  27mb_json_file |  50,404.241 μs |    73.0118 μs |    68.2953 μs |  50,387.855 μs |  0.39 |    0.01 |
| ZstdDecompressStream | Decompress |  27mb_json_file |  51,931.553 μs |    89.2998 μs |    83.5311 μs |  51,912.587 μs |  0.40 |    0.01 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** |  **39kB_json_file** |     **343.623 μs** |     **0.6042 μs** |     **0.5356 μs** |     **343.477 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress |  39kB_json_file |     692.383 μs |     0.2079 μs |     0.1945 μs |     692.377 μs |  2.01 |    0.00 |
|   ZstdCompressStream |   Compress |  39kB_json_file |     316.461 μs |     2.8290 μs |     2.6463 μs |     317.713 μs |  0.92 |    0.01 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress |  39kB_json_file |      87.245 μs |     0.2023 μs |     0.1689 μs |      87.232 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress |  39kB_json_file |      73.465 μs |     0.1735 μs |     0.1623 μs |      73.533 μs |  0.84 |    0.00 |
| ZstdDecompressStream | Decompress |  39kB_json_file |      73.984 μs |     0.1177 μs |     0.1101 μs |      74.007 μs |  0.85 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** | **490kB_text_file** |   **8,275.767 μs** |    **24.9403 μs** |    **22.1089 μs** |   **8,268.352 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress | 490kB_text_file |  13,659.949 μs |    11.6510 μs |    10.8984 μs |  13,655.334 μs |  1.65 |    0.00 |
|   ZstdCompressStream |   Compress | 490kB_text_file |   5,989.391 μs |    49.0770 μs |    45.9066 μs |   6,004.172 μs |  0.72 |    0.01 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress | 490kB_text_file |   3,736.421 μs |     3.0506 μs |     2.5474 μs |   3,736.770 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress | 490kB_text_file |   1,242.546 μs |     2.1973 μs |     1.9478 μs |   1,243.271 μs |  0.33 |    0.00 |
| ZstdDecompressStream | Decompress | 490kB_text_file |   1,319.675 μs |     6.8092 μs |     6.3693 μs |   1,315.479 μs |  0.35 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** |  **49mb_json_file** | **539,161.133 μs** | **4,750.2679 μs** | **4,443.4035 μs** | **542,696.813 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress |  49mb_json_file | 818,794.244 μs | 1,836.6794 μs | 1,718.0311 μs | 818,587.959 μs |  1.52 |    0.01 |
|   ZstdCompressStream |   Compress |  49mb_json_file | 387,569.842 μs | 2,790.8364 μs | 2,610.5501 μs | 389,129.511 μs |  0.72 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress |  49mb_json_file | 282,413.482 μs |   104.3409 μs |    92.4955 μs | 282,451.182 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress |  49mb_json_file |  95,955.522 μs |    37.9404 μs |    33.6332 μs |  95,949.495 μs |  0.34 |    0.00 |
| ZstdDecompressStream | Decompress |  49mb_json_file | 105,218.651 μs |    23.0359 μs |    20.4207 μs | 105,217.176 μs |  0.37 |    0.00 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** |      **randomData** |      **10.043 μs** |     **0.2002 μs** |     **0.2226 μs** |       **9.932 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress |      randomData |      77.260 μs |     0.1140 μs |     0.0952 μs |      77.240 μs |  7.67 |    0.18 |
|   ZstdCompressStream |   Compress |      randomData |      46.232 μs |     0.3306 μs |     0.3093 μs |      46.184 μs |  4.59 |    0.12 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress |      randomData |       4.680 μs |     0.0281 μs |     0.0263 μs |       4.682 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress |      randomData |       1.222 μs |     0.0059 μs |     0.0055 μs |       1.225 μs |  0.26 |    0.00 |
| ZstdDecompressStream | Decompress |      randomData |       2.361 μs |     0.0424 μs |     0.0435 μs |       2.339 μs |  0.50 |    0.01 |
|                      |            |                 |                |               |               |                |       |         |
|    **UnmanagedCompress** |   **Compress** |  **repetitiveData** |       **8.858 μs** |     **0.1022 μs** |     **0.0956 μs** |       **8.839 μs** |  **1.00** |    **0.00** |
|    ZstdCompressBlock |   Compress |  repetitiveData |      12.338 μs |     0.1675 μs |     0.1485 μs |      12.336 μs |  1.39 |    0.02 |
|   ZstdCompressStream |   Compress |  repetitiveData |      30.537 μs |     0.4389 μs |     0.4106 μs |      30.525 μs |  3.45 |    0.06 |
|                      |            |                 |                |               |               |                |       |         |
|  UnmanagedDecompress | Decompress |  repetitiveData |      14.029 μs |     0.0884 μs |     0.0739 μs |      14.014 μs |  1.00 |    0.00 |
|  ZstdDecompressBlock | Decompress |  repetitiveData |       3.217 μs |     0.0113 μs |     0.0088 μs |       3.217 μs |  0.23 |    0.00 |
| ZstdDecompressStream | Decompress |  repetitiveData |       3.768 μs |     0.0639 μs |     0.0567 μs |       3.746 μs |  0.27 |    0.00 |
