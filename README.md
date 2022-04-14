# LiteDB Benchmarks

This repository contains benchmark comparison between SQLite and LiteDB.
The test runs inserting records and finding single record by identifier.

## Results
|        Method | ItemCount |  Adapter |         Mean |       Error |      StdDev |       Median |              Rank |     Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|-------------- |---------- |--------- |-------------:|------------:|------------:|-------------:|------------------:|----------:|---------:|---------:|----------:|
| FindByIdAsync |        10 | E-LiteDb |     3.631 ms |   0.1012 ms |   0.2854 ms |     3.520 ms |                 * |   23.4375 |  23.4375 |  23.4375 |    162 KB |
|        Insert |        10 | E-LiteDb |    10.211 ms |   0.1885 ms |   0.1763 ms |    10.190 ms |            ****** |   62.5000 |  62.5000 |  62.5000 |    336 KB |
| FindByIdAsync |        10 | E-Sqlite | 1,239.802 ms | 134.5030 ms | 372.7072 ms | 1,397.670 ms |     ************* |         - |        - |        - |     16 KB |
|        Insert |        10 | E-Sqlite | 1,443.232 ms |  57.5803 ms | 167.9646 ms | 1,463.794 ms |    ************** |         - |        - |        - |    137 KB |
| FindByIdAsync |       100 | E-LiteDb |     4.335 ms |   0.1668 ms |   0.4864 ms |     4.275 ms |               *** |   23.4375 |  23.4375 |  23.4375 |    164 KB |
|        Insert |       100 | E-LiteDb |    11.003 ms |   0.1881 ms |   0.1667 ms |    11.023 ms |           ******* |   46.8750 |  46.8750 |  46.8750 |    306 KB |
| FindByIdAsync |       100 | E-Sqlite |   881.144 ms | 128.9594 ms | 380.2398 ms |   629.004 ms |      ************ |         - |        - |        - |     16 KB |
|        Insert |       100 | E-Sqlite |   640.436 ms |   7.1297 ms |   6.6691 ms |   640.312 ms |        ********** |         - |        - |        - |    160 KB |
| FindByIdAsync |       500 | E-LiteDb |     4.112 ms |   0.0947 ms |   0.2733 ms |     4.049 ms |                ** |   23.4375 |  23.4375 |  23.4375 |    168 KB |
|        Insert |       500 | E-LiteDb |    14.176 ms |   0.2803 ms |   0.5662 ms |    14.218 ms |         ********* |  140.6250 | 140.6250 | 140.6250 |    594 KB |
| FindByIdAsync |       500 | E-Sqlite |   737.320 ms |  13.1132 ms |  10.9501 ms |   736.275 ms |       *********** |         - |        - |        - |     24 KB |
|        Insert |       500 | E-Sqlite | 1,632.913 ms |  72.4453 ms | 206.6905 ms | 1,645.497 ms |  **************** |         - |        - |        - |    597 KB |
| FindByIdAsync |      1000 | E-LiteDb |     4.511 ms |   0.0850 ms |   0.0753 ms |     4.518 ms |              **** |   23.4375 |  23.4375 |  23.4375 |    171 KB |
|        Insert |      1000 | E-LiteDb |    13.040 ms |   0.1757 ms |   0.1557 ms |    12.978 ms |          ******** |  140.6250 | 140.6250 | 140.6250 |    561 KB |
| FindByIdAsync |      1000 | E-Sqlite | 1,581.859 ms |  30.4984 ms |  31.3196 ms | 1,571.246 ms |   *************** |         - |        - |        - |     25 KB |
|        Insert |      1000 | E-Sqlite | 1,634.867 ms |  63.1006 ms | 183.0663 ms | 1,620.922 ms |  **************** |         - |        - |        - |  1,058 KB |
| FindByIdAsync |     10000 | E-LiteDb |     5.764 ms |   0.2644 ms |   0.7499 ms |     5.621 ms |             ***** |  125.0000 | 117.1875 | 109.3750 |    585 KB |
|        Insert |     10000 | E-LiteDb |    13.222 ms |   0.2001 ms |   0.1774 ms |    13.177 ms |          ******** |  125.0000 | 109.3750 | 109.3750 |    610 KB |
| FindByIdAsync |     10000 | E-Sqlite | 1,583.535 ms |  26.5863 ms |  26.1113 ms | 1,578.088 ms |   *************** |         - |        - |        - |     18 KB |
|        Insert |     10000 | E-Sqlite | 1,721.227 ms |  40.9812 ms | 113.5587 ms | 1,717.559 ms | ***************** | 2000.0000 |        - |        - |  9,430 KB |
