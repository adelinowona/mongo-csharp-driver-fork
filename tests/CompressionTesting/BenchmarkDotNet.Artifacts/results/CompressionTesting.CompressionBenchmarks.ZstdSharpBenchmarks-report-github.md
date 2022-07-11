``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8259CL CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|               Method | Categories |      which_data |           Mean |          Error |          StdDev |         Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |     Allocated |
|--------------------- |----------- |---------------- |---------------:|---------------:|----------------:|---------------:|------:|--------:|---------:|---------:|---------:|--------------:|
|    **UnmanagedCompress** |   **Compress** | **156kB_text_file** |   **2,666.584 μs** |      **5.7751 μs** |       **4.8224 μs** |   **2,667.557 μs** |  **1.00** |    **0.00** |  **27.3438** |  **27.3438** |  **27.3438** |     **140,142 B** |
|    ZstdCompressBlock |   Compress | 156kB_text_file |   4,079.665 μs |     10.3638 μs |       9.1872 μs |   4,077.877 μs |  1.53 |    0.00 |  46.8750 |  46.8750 |  46.8750 |     152,782 B |
|   ZstdCompressStream |   Compress | 156kB_text_file |   4,028.560 μs |     12.2921 μs |      11.4980 μs |   4,025.719 μs |  1.51 |    0.00 |        - |        - |        - |         118 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress | 156kB_text_file |     265.251 μs |      1.2792 μs |       1.1340 μs |     265.291 μs |  1.00 |    0.00 | 110.8398 | 110.8398 | 110.8398 |     395,377 B |
|  ZstdDecompressBlock | Decompress | 156kB_text_file |     433.150 μs |      2.8368 μs |       2.6536 μs |     432.905 μs |  1.63 |    0.01 |  47.3633 |  47.3633 |  47.3633 |     152,177 B |
| ZstdDecompressStream | Decompress | 156kB_text_file |     384.344 μs |      0.2719 μs |       0.2123 μs |     384.393 μs |  1.45 |    0.01 |        - |        - |        - |         115 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** | **2.9mb_text_file** |  **43,137.925 μs** |    **151.1582 μs** |     **141.3935 μs** |  **43,147.938 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |   **1,417,716 B** |
|    ZstdCompressBlock |   Compress | 2.9mb_text_file |  57,951.367 μs |    686.7076 μs |     642.3467 μs |  57,981.084 μs |  1.34 |    0.01 |        - |        - |        - |   2,910,969 B |
|   ZstdCompressStream |   Compress | 2.9mb_text_file |  60,126.751 μs |    286.3020 μs |     267.8071 μs |  60,076.033 μs |  1.39 |    0.01 |        - |        - |        - |         203 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress | 2.9mb_text_file |   7,844.653 μs |     40.5621 μs |      37.9418 μs |   7,852.052 μs |  1.00 |    0.00 | 218.7500 | 218.7500 | 218.7500 |   8,265,215 B |
|  ZstdDecompressBlock | Decompress | 2.9mb_text_file |   6,625.819 μs |     43.1540 μs |      40.3663 μs |   6,636.019 μs |  0.84 |    0.01 | 125.0000 | 125.0000 | 125.0000 |   2,899,625 B |
| ZstdDecompressStream | Decompress | 2.9mb_text_file |   6,027.631 μs |    110.7478 μs |      92.4794 μs |   5,990.526 μs |  0.77 |    0.01 |        - |        - |        - |         113 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **27mb_json_file** | **449,960.492 μs** | **30,052.7705 μs** |  **88,611.2720 μs** | **503,135.686 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |  **11,401,600 B** |
|    ZstdCompressBlock |   Compress |  27mb_json_file | 624,086.932 μs | 37,623.9242 μs | 110,934.9895 μs | 680,862.221 μs |  1.46 |    0.46 |        - |        - |        - |  27,292,128 B |
|   ZstdCompressStream |   Compress |  27mb_json_file | 625,634.840 μs | 52,207.7735 μs | 153,935.7982 μs | 499,112.553 μs |  1.47 |    0.55 |        - |        - |        - |         928 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  27mb_json_file |  80,069.158 μs |  6,403.7719 μs |  18,881.6658 μs |  67,191.489 μs |  1.00 |    0.00 | 250.0000 | 250.0000 | 250.0000 |  67,038,299 B |
|  ZstdDecompressBlock | Decompress |  27mb_json_file |  52,546.324 μs |    522.6516 μs |     488.8887 μs |  52,415.922 μs |  0.52 |    0.10 |        - |        - |        - |  27,188,383 B |
| ZstdDecompressStream | Decompress |  27mb_json_file |  44,161.151 μs |    117.4124 μs |     104.0830 μs |  44,157.351 μs |  0.42 |    0.06 |        - |        - |        - |         180 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **39kB_json_file** |     **576.336 μs** |      **0.5853 μs** |       **0.5475 μs** |     **576.512 μs** |  **1.00** |    **0.00** |   **1.9531** |        **-** |        **-** |      **38,905 B** |
|    ZstdCompressBlock |   Compress |  39kB_json_file |     702.424 μs |     13.8504 μs |      31.5444 μs |     693.672 μs |  1.27 |    0.10 |   1.9531 |        - |        - |      39,505 B |
|   ZstdCompressStream |   Compress |  39kB_json_file |     782.901 μs |      0.9443 μs |       0.8371 μs |     782.758 μs |  1.36 |    0.00 |        - |        - |        - |         113 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  39kB_json_file |      48.621 μs |      0.0716 μs |       0.0670 μs |      48.639 μs |  1.00 |    0.00 |   2.1362 |   0.2441 |        - |      40,280 B |
|  ZstdDecompressBlock | Decompress |  39kB_json_file |      76.956 μs |      0.0489 μs |       0.0458 μs |      76.960 μs |  1.58 |    0.00 |   2.0752 |        - |        - |      39,305 B |
| ZstdDecompressStream | Decompress |  39kB_json_file |      69.510 μs |      0.0454 μs |       0.0425 μs |      69.496 μs |  1.43 |    0.00 |        - |        - |        - |         113 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** | **490kB_text_file** |   **8,956.688 μs** |     **40.0086 μs** |      **37.4241 μs** |   **8,950.492 μs** |  **1.00** |    **0.00** |  **62.5000** |  **62.5000** |  **62.5000** |     **379,193 B** |
|    ZstdCompressBlock |   Compress | 490kB_text_file |  13,936.161 μs |     24.2471 μs |      22.6807 μs |  13,941.211 μs |  1.56 |    0.01 |  93.7500 |  93.7500 |  93.7500 |     483,874 B |
|   ZstdCompressStream |   Compress | 490kB_text_file |  13,884.347 μs |     23.4129 μs |      21.9004 μs |  13,886.361 μs |  1.55 |    0.01 |        - |        - |        - |         125 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress | 490kB_text_file |     860.965 μs |      3.1510 μs |       2.9474 μs |     860.491 μs |  1.00 |    0.00 | 248.0469 | 248.0469 | 248.0469 |     921,558 B |
|  ZstdDecompressBlock | Decompress | 490kB_text_file |   1,318.524 μs |      3.4521 μs |       3.0602 μs |   1,318.147 μs |  1.53 |    0.01 | 121.0938 | 121.0938 | 121.0938 |     482,000 B |
| ZstdDecompressStream | Decompress | 490kB_text_file |   1,296.079 μs |      1.0974 μs |       1.0265 μs |   1,295.830 μs |  1.51 |    0.01 |        - |        - |        - |         119 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **49mb_json_file** | **701,031.509 μs** |  **3,145.2643 μs** |   **2,942.0821 μs** | **700,608.461 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |  **33,256,280 B** |
|    ZstdCompressBlock |   Compress |  49mb_json_file | 835,771.051 μs |  3,153.3564 μs |   2,949.6516 μs | 835,764.402 μs |  1.19 |    0.01 |        - |        - |        - |  49,753,624 B |
|   ZstdCompressStream |   Compress |  49mb_json_file | 981,058.307 μs |  2,389.7991 μs |   2,118.4946 μs | 980,897.801 μs |  1.40 |    0.01 |        - |        - |        - |       4,240 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  49mb_json_file | 130,109.200 μs |    461.3159 μs |     431.5152 μs | 130,120.411 μs |  1.00 |    0.00 |        - |        - |        - | 134,196,910 B |
|  ZstdDecompressBlock | Decompress |  49mb_json_file |  97,216.046 μs |    283.6071 μs |     265.2863 μs |  97,129.975 μs |  0.75 |    0.00 |        - |        - |        - |  49,556,225 B |
| ZstdDecompressStream | Decompress |  49mb_json_file |  90,701.858 μs |     58.9719 μs |      49.2442 μs |  90,699.159 μs |  0.70 |    0.00 |        - |        - |        - |         248 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |      **randomData** |     **301.434 μs** |      **0.3642 μs** |       **0.3407 μs** |     **301.480 μs** |  **1.00** |    **0.00** |   **1.4648** |        **-** |        **-** |      **30,888 B** |
|    ZstdCompressBlock |   Compress |      randomData |      75.933 μs |      0.0566 μs |       0.0529 μs |      75.921 μs |  0.25 |    0.00 |   0.4883 |        - |        - |      10,160 B |
|   ZstdCompressStream |   Compress |      randomData |     167.209 μs |      0.1807 μs |       0.1690 μs |     167.145 μs |  0.55 |    0.00 |        - |        - |        - |         112 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |      randomData |       6.625 μs |      0.0404 μs |       0.0378 μs |       6.621 μs |  1.00 |    0.00 |   0.5875 |   0.0153 |        - |      11,024 B |
|  ZstdDecompressBlock | Decompress |      randomData |       1.947 μs |      0.0775 μs |       0.2136 μs |       1.915 μs |  0.29 |    0.03 |   0.5360 |        - |        - |      10,048 B |
| ZstdDecompressStream | Decompress |      randomData |       1.352 μs |      0.0046 μs |       0.0038 μs |       1.351 μs |  0.20 |    0.00 |   0.0057 |        - |        - |         112 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **repetitiveData** |     **261.553 μs** |      **0.4789 μs** |       **0.4480 μs** |     **261.623 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |       **1,080 B** |
|    ZstdCompressBlock |   Compress |  repetitiveData |      12.509 μs |      0.0705 μs |       0.0659 μs |      12.497 μs |  0.05 |    0.00 |   0.5341 |        - |        - |      10,160 B |
|   ZstdCompressStream |   Compress |  repetitiveData |     124.392 μs |      0.5227 μs |       0.4889 μs |     124.314 μs |  0.48 |    0.00 |        - |        - |        - |         112 B |
|                      |            |                 |                |                |                 |                |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  repetitiveData |       8.256 μs |      0.0555 μs |       0.0519 μs |       8.243 μs |  1.00 |    0.00 |   0.5798 |   0.0153 |        - |      11,024 B |
|  ZstdDecompressBlock | Decompress |  repetitiveData |       4.161 μs |      0.0827 μs |       0.1104 μs |       4.133 μs |  0.51 |    0.01 |   0.5341 |        - |        - |      10,048 B |
| ZstdDecompressStream | Decompress |  repetitiveData |       2.960 μs |      0.0040 μs |       0.0037 μs |       2.961 μs |  0.36 |    0.00 |   0.0038 |        - |        - |         112 B |
