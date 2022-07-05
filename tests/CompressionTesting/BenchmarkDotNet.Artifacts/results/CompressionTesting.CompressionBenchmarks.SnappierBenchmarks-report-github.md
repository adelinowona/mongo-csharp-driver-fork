``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8259CL CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                   Method | Categories |      which_data |             Mean |           Error |          StdDev |           Median | Ratio | RatioSD |
|------------------------- |----------- |---------------- |-----------------:|----------------:|----------------:|-----------------:|------:|--------:|
|        **UnmanagedCompress** |   **Compress** | **156kB_text_file** |   **2,222,276.3 ns** |     **1,821.87 ns** |     **1,704.18 ns** |   **2,221,289.6 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress | 156kB_text_file |     716,321.7 ns |       343.09 ns |       320.92 ns |     716,295.9 ns |  0.32 |    0.00 |
|   SnappierCompressStream |   Compress | 156kB_text_file |     782,159.0 ns |       515.85 ns |       457.29 ns |     782,105.1 ns |  0.35 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress | 156kB_text_file |     948,613.3 ns |        49.10 ns |        41.00 ns |     948,609.7 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress | 156kB_text_file |     392,714.3 ns |        64.36 ns |        60.20 ns |     392,722.1 ns |  0.41 |    0.00 |
| SnappierDecompressStream | Decompress | 156kB_text_file |     416,349.0 ns |     1,491.43 ns |     1,395.08 ns |     415,839.4 ns |  0.44 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** | **2.9mb_text_file** |  **37,340,792.1 ns** |     **7,130.63 ns** |     **6,670.00 ns** |  **37,342,002.8 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress | 2.9mb_text_file |  12,323,391.6 ns |    16,238.95 ns |    15,189.92 ns |  12,329,361.6 ns |  0.33 |    0.00 |
|   SnappierCompressStream |   Compress | 2.9mb_text_file |  14,960,647.2 ns |    24,357.71 ns |    22,784.22 ns |  14,958,889.9 ns |  0.40 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress | 2.9mb_text_file |  14,272,326.9 ns |    12,320.28 ns |    10,921.61 ns |  14,270,792.3 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress | 2.9mb_text_file |   6,532,698.4 ns |    17,206.88 ns |    14,368.53 ns |   6,527,629.9 ns |  0.46 |    0.00 |
| SnappierDecompressStream | Decompress | 2.9mb_text_file |   8,076,592.5 ns |     9,464.29 ns |     8,852.90 ns |   8,076,206.3 ns |  0.57 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** |  **27mb_json_file** | **206,621,122.2 ns** |    **38,118.54 ns** |    **29,760.45 ns** | **206,628,028.5 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress |  27mb_json_file |  66,947,659.6 ns |    27,133.79 ns |    25,380.97 ns |  66,941,120.5 ns |  0.32 |    0.00 |
|   SnappierCompressStream |   Compress |  27mb_json_file |  84,887,333.3 ns |   108,164.84 ns |   101,177.46 ns |  84,885,259.3 ns |  0.41 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress |  27mb_json_file |  86,225,539.5 ns |    18,089.87 ns |    16,921.28 ns |  86,223,077.8 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress |  27mb_json_file |  43,578,080.5 ns |    65,393.62 ns |    61,169.23 ns |  43,591,766.8 ns |  0.51 |    0.00 |
| SnappierDecompressStream | Decompress |  27mb_json_file |  55,776,870.2 ns |    39,256.66 ns |    36,720.70 ns |  55,784,689.6 ns |  0.65 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** |  **39kB_json_file** |     **324,749.3 ns** |        **68.48 ns** |        **60.70 ns** |     **324,751.3 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress |  39kB_json_file |      66,827.6 ns |        78.24 ns |        73.18 ns |      66,821.2 ns |  0.21 |    0.00 |
|   SnappierCompressStream |   Compress |  39kB_json_file |      76,164.4 ns |        53.81 ns |        50.33 ns |      76,167.1 ns |  0.23 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress |  39kB_json_file |      73,034.8 ns |        34.78 ns |        32.53 ns |      73,038.0 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress |  39kB_json_file |      33,159.2 ns |        51.52 ns |        48.19 ns |      33,161.8 ns |  0.45 |    0.00 |
| SnappierDecompressStream | Decompress |  39kB_json_file |      44,352.6 ns |       537.93 ns |       503.18 ns |      44,352.6 ns |  0.61 |    0.01 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** | **490kB_text_file** |   **7,897,094.8 ns** |     **1,704.74 ns** |     **1,511.21 ns** |   **7,897,305.6 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress | 490kB_text_file |   2,506,555.8 ns |     5,098.51 ns |     4,769.15 ns |   2,507,877.3 ns |  0.32 |    0.00 |
|   SnappierCompressStream |   Compress | 490kB_text_file |   2,846,679.0 ns |    14,162.05 ns |    13,247.19 ns |   2,848,494.7 ns |  0.36 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress | 490kB_text_file |   3,503,296.3 ns |       511.43 ns |       478.39 ns |   3,503,281.4 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress | 490kB_text_file |   1,335,516.8 ns |       156.30 ns |       146.20 ns |   1,335,556.8 ns |  0.38 |    0.00 |
| SnappierDecompressStream | Decompress | 490kB_text_file |   1,603,587.0 ns |     4,498.31 ns |     4,207.73 ns |   1,604,366.8 ns |  0.46 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** |  **49mb_json_file** | **487,671,912.9 ns** |   **124,540.76 ns** |   **116,495.51 ns** | **487,692,108.0 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress |  49mb_json_file | 163,000,513.7 ns |    40,260.83 ns |    37,660.00 ns | 162,992,740.5 ns |  0.33 |    0.00 |
|   SnappierCompressStream |   Compress |  49mb_json_file | 201,089,091.8 ns | 3,334,155.38 ns | 3,118,771.01 ns | 198,429,976.7 ns |  0.41 |    0.01 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress |  49mb_json_file | 190,664,628.3 ns |    58,126.43 ns |    51,527.57 ns | 190,659,722.3 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress |  49mb_json_file |  96,572,913.5 ns |    84,316.28 ns |    78,869.50 ns |  96,578,097.3 ns |  0.51 |    0.00 |
| SnappierDecompressStream | Decompress |  49mb_json_file | 117,632,188.1 ns |    29,054.53 ns |    27,177.62 ns | 117,633,829.2 ns |  0.62 |    0.00 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** |      **randomData** |       **4,809.2 ns** |        **20.50 ns** |        **19.17 ns** |       **4,814.7 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress |      randomData |       2,333.4 ns |         6.96 ns |         6.52 ns |       2,332.5 ns |  0.49 |    0.00 |
|   SnappierCompressStream |   Compress |      randomData |       5,642.8 ns |        77.19 ns |        72.21 ns |       5,655.4 ns |  1.17 |    0.01 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress |      randomData |         462.9 ns |         0.39 ns |         0.37 ns |         462.9 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress |      randomData |         449.0 ns |         3.09 ns |         2.89 ns |         448.8 ns |  0.97 |    0.01 |
| SnappierDecompressStream | Decompress |      randomData |       3,560.5 ns |        61.95 ns |        51.73 ns |       3,563.3 ns |  7.69 |    0.11 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|        **UnmanagedCompress** |   **Compress** |  **repetitiveData** |       **6,166.0 ns** |        **53.87 ns** |        **50.39 ns** |       **6,173.9 ns** |  **1.00** |    **0.00** |
|    SnappierCompressBlock |   Compress |  repetitiveData |       2,644.3 ns |         1.07 ns |         0.95 ns |       2,644.1 ns |  0.43 |    0.00 |
|   SnappierCompressStream |   Compress |  repetitiveData |       4,804.9 ns |         5.77 ns |         5.12 ns |       4,804.8 ns |  0.78 |    0.01 |
|                          |            |                 |                  |                 |                 |                  |       |         |
|      UnmanagedDecompress | Decompress |  repetitiveData |      10,679.3 ns |         2.67 ns |         2.36 ns |      10,680.0 ns |  1.00 |    0.00 |
|  SnappierDecompressBlock | Decompress |  repetitiveData |       1,993.0 ns |         1.10 ns |         1.03 ns |       1,993.0 ns |  0.19 |    0.00 |
| SnappierDecompressStream | Decompress |  repetitiveData |       4,754.8 ns |        93.04 ns |       130.43 ns |       4,802.8 ns |  0.45 |    0.01 |
