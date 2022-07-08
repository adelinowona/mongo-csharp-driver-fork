``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8259CL CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|               Method | Categories |      which_data |           Mean |         Error |        StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |     Allocated |
|--------------------- |----------- |---------------- |---------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|--------------:|
|    **UnmanagedCompress** |   **Compress** | **156kB_text_file** |   **2,940.598 μs** |    **32.8609 μs** |    **43.8683 μs** |  **1.00** |    **0.00** |  **23.4375** |  **23.4375** |  **23.4375** |     **193,454 B** |
|    ZstdCompressBlock |   Compress | 156kB_text_file |   4,182.227 μs |    13.7311 μs |    12.1722 μs |  1.41 |    0.02 |  46.8750 |  46.8750 |  46.8750 |     152,782 B |
|   ZstdCompressStream |   Compress | 156kB_text_file |   1,660.142 μs |     0.4463 μs |     0.3484 μs |  0.56 |    0.01 |   1.9531 |        - |        - |      48,634 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress | 156kB_text_file |     320.253 μs |     1.8497 μs |     1.7303 μs |  1.00 |    0.00 | 147.9492 | 147.9492 | 147.9492 |     547,448 B |
|  ZstdDecompressBlock | Decompress | 156kB_text_file |     460.913 μs |     0.4109 μs |     0.3642 μs |  1.44 |    0.01 |  47.3633 |  47.3633 |  47.3633 |     152,178 B |
| ZstdDecompressStream | Decompress | 156kB_text_file |     368.886 μs |     0.2155 μs |     0.2015 μs |  1.15 |    0.01 |        - |        - |        - |         113 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** | **2.9mb_text_file** |  **46,427.050 μs** |   **286.2345 μs** |   **267.7440 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |   **2,103,293 B** |
|    ZstdCompressBlock |   Compress | 2.9mb_text_file |  59,083.369 μs |   971.0127 μs | 1,038.9727 μs |  1.27 |    0.02 |        - |        - |        - |   2,910,963 B |
|   ZstdCompressStream |   Compress | 2.9mb_text_file |  25,101.677 μs |   102.4266 μs |    95.8099 μs |  0.54 |    0.00 |        - |        - |        - |     772,730 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress | 2.9mb_text_file |   6,292.051 μs |    25.3045 μs |    22.4318 μs |  1.00 |    0.00 | 273.4375 | 273.4375 | 273.4375 |  11,165,564 B |
|  ZstdDecompressBlock | Decompress | 2.9mb_text_file |   6,321.241 μs |    33.5497 μs |    29.7409 μs |  1.00 |    0.01 | 125.0000 | 125.0000 | 125.0000 |   2,899,625 B |
| ZstdDecompressStream | Decompress | 2.9mb_text_file |   5,902.730 μs |    69.2345 μs |    61.3746 μs |  0.94 |    0.01 |        - |        - |        - |         118 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **27mb_json_file** | **308,290.394 μs** | **5,567.7222 μs** | **5,208.0508 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |  **15,979,748 B** |
|    ZstdCompressBlock |   Compress |  27mb_json_file | 396,491.877 μs | 2,881.8806 μs | 2,695.7129 μs |  1.29 |    0.03 |        - |        - |        - |  27,295,368 B |
|   ZstdCompressStream |   Compress |  27mb_json_file | 185,296.452 μs |   433.8508 μs |   384.5974 μs |  0.60 |    0.01 |        - |        - |        - |   4,920,504 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  27mb_json_file |  81,076.494 μs | 1,141.3454 μs | 1,067.6152 μs |  1.00 |    0.00 | 285.7143 | 285.7143 | 285.7143 |  94,225,161 B |
|  ZstdDecompressBlock | Decompress |  27mb_json_file |  51,713.849 μs |    58.1229 μs |    51.5245 μs |  0.64 |    0.01 |        - |        - |        - |  27,187,078 B |
| ZstdDecompressStream | Decompress |  27mb_json_file |  43,563.691 μs |   347.8477 μs |   325.3769 μs |  0.54 |    0.01 |        - |        - |        - |         180 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **39kB_json_file** |     **578.802 μs** |     **1.4280 μs** |     **1.2659 μs** |  **1.00** |    **0.00** |   **1.9531** |        **-** |        **-** |      **51,617 B** |
|    ZstdCompressBlock |   Compress |  39kB_json_file |     695.329 μs |     2.6491 μs |     2.4779 μs |  1.20 |    0.01 |   1.9531 |        - |        - |      39,505 B |
|   ZstdCompressStream |   Compress |  39kB_json_file |     302.301 μs |     0.3051 μs |     0.2996 μs |  0.52 |    0.00 |        - |        - |        - |         112 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  39kB_json_file |      54.205 μs |     0.2787 μs |     0.2607 μs |  1.00 |    0.00 |   4.2114 |   0.6714 |        - |      79,560 B |
|  ZstdDecompressBlock | Decompress |  39kB_json_file |      76.823 μs |     0.0536 μs |     0.0501 μs |  1.42 |    0.01 |   2.0752 |        - |        - |      39,304 B |
| ZstdDecompressStream | Decompress |  39kB_json_file |      69.427 μs |     0.0340 μs |     0.0301 μs |  1.28 |    0.01 |        - |        - |        - |         112 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** | **490kB_text_file** |   **9,041.928 μs** |    **54.0751 μs** |    **50.5819 μs** |  **1.00** |    **0.00** | **109.3750** | **109.3750** | **109.3750** |     **562,263 B** |
|    ZstdCompressBlock |   Compress | 490kB_text_file |  13,764.031 μs |    75.8071 μs |    70.9100 μs |  1.52 |    0.01 |  93.7500 |  93.7500 |  93.7500 |     483,874 B |
|   ZstdCompressStream |   Compress | 490kB_text_file |   6,040.368 μs |     7.8919 μs |     6.9959 μs |  0.67 |    0.00 |  31.2500 |  31.2500 |  31.2500 |     157,795 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress | 490kB_text_file |   1,083.900 μs |     3.4341 μs |     3.0443 μs |  1.00 |    0.00 | 335.9375 | 335.9375 | 335.9375 |   1,401,933 B |
|  ZstdDecompressBlock | Decompress | 490kB_text_file |   1,246.489 μs |     2.4633 μs |     2.1837 μs |  1.15 |    0.00 | 121.0938 | 121.0938 | 121.0938 |     481,998 B |
| ZstdDecompressStream | Decompress | 490kB_text_file |   1,234.127 μs |     7.5783 μs |     7.0887 μs |  1.14 |    0.01 |        - |        - |        - |         115 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **49mb_json_file** | **712,109.200 μs** | **3,743.0946 μs** | **3,125.6535 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |  **42,841,216 B** |
|    ZstdCompressBlock |   Compress |  49mb_json_file | 839,062.660 μs | 4,468.8017 μs | 3,961.4763 μs |  1.18 |    0.01 |        - |        - |        - |  49,771,584 B |
|   ZstdCompressStream |   Compress |  49mb_json_file | 382,923.292 μs | 1,710.2480 μs | 1,599.7670 μs |  0.54 |    0.00 |        - |        - |        - |  10,856,648 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  49mb_json_file | 157,335.091 μs |   952.6091 μs |   891.0711 μs |  1.00 |    0.00 |        - |        - |        - | 183,753,136 B |
|  ZstdDecompressBlock | Decompress |  49mb_json_file |  97,786.720 μs |   226.2035 μs |   211.5909 μs |  0.62 |    0.00 |        - |        - |        - |  49,556,120 B |
| ZstdDecompressStream | Decompress |  49mb_json_file |  93,597.513 μs |   226.8913 μs |   189.4645 μs |  0.59 |    0.00 |        - |        - |        - |         248 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |      **randomData** |     **312.670 μs** |     **0.4873 μs** |     **0.4558 μs** |  **1.00** |    **0.00** |   **1.9531** |        **-** |        **-** |      **40,928 B** |
|    ZstdCompressBlock |   Compress |      randomData |      76.066 μs |     0.1893 μs |     0.1770 μs |  0.24 |    0.00 |   0.4883 |        - |        - |      10,160 B |
|   ZstdCompressStream |   Compress |      randomData |      38.717 μs |     0.4663 μs |     0.4134 μs |  0.12 |    0.00 |        - |        - |        - |         112 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |      randomData |       8.435 μs |     0.0977 μs |     0.0816 μs |  1.00 |    0.00 |   1.1139 |   0.0763 |        - |      21,048 B |
|  ZstdDecompressBlock | Decompress |      randomData |       1.572 μs |     0.0306 μs |     0.0495 μs |  0.19 |    0.01 |   0.5360 |        - |        - |      10,048 B |
| ZstdDecompressStream | Decompress |      randomData |       1.366 μs |     0.0065 μs |     0.0061 μs |  0.16 |    0.00 |   0.0057 |        - |        - |         112 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|    **UnmanagedCompress** |   **Compress** |  **repetitiveData** |     **255.598 μs** |     **0.3037 μs** |     **0.2840 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |       **1,128 B** |
|    ZstdCompressBlock |   Compress |  repetitiveData |      12.173 μs |     0.0729 μs |     0.0682 μs |  0.05 |    0.00 |   0.5341 |        - |        - |      10,160 B |
|   ZstdCompressStream |   Compress |  repetitiveData |      27.877 μs |     0.5484 μs |     0.5386 μs |  0.11 |    0.00 |        - |        - |        - |         112 B |
|                      |            |                 |                |               |               |       |         |          |          |          |               |
|  UnmanagedDecompress | Decompress |  repetitiveData |      10.042 μs |     0.0909 μs |     0.0850 μs |  1.00 |    0.00 |   1.1139 |   0.0763 |        - |      21,048 B |
|  ZstdDecompressBlock | Decompress |  repetitiveData |       3.807 μs |     0.0439 μs |     0.0410 μs |  0.38 |    0.00 |   0.5341 |        - |        - |      10,048 B |
| ZstdDecompressStream | Decompress |  repetitiveData |       2.860 μs |     0.0564 μs |     0.0554 μs |  0.29 |    0.01 |   0.0038 |        - |        - |         112 B |
