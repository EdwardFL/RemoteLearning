# Results

### Test performance of Boxing and Unboxing for Value Types (int).

|   No. of iterations     | 1000 | 100000 | 1000000 |
|:-----------------------:|:----:|:------:|:-------:|
|     Boxing T1           |  401 |  22699 |  369791 |
|    Without boxing T1    |  244 |  9821  |  96577  |
|     Boxing T2           |  390 |  45165 |  492919 |
|    Without boxing T2    |  128 |  10151 |  474102 |
|     Boxing T3           |  676 |  14092 | 1818754 |
|    Without boxing T3    |  115 |  6470  |  112652 |
|     Boxing T4           |  239 |  46947 |  977830 |
|    Without boxing T4    |  124 |  8094  |  173665 |
|     Boxing T5           |  296 |  18284 | 1079816 |
|    Without boxing T5    |  166 |  11289 |  102193 |

### Test performance of Boxing and Unboxing for Reference Types (string).

| No. of iterations | 1000 | 100000 | 1000000 |
|:-----------------:|:----:|:------:|:-------:|
|     Boxing T1     |  217 |  12616 |  278120 |
| Without Boxing T1 |  262 |  28050 |  145056 |
|     Boxing T2     |  235 |  17330 |  130164 |
| Without Boxing T2 |  255 |  14635 |  223345 |
|     Boxing T3     |  151 |  19586 |  162046 |
| Without Boxing T3 |  209 |  16245 |  153983 |
|     Boxing T4     |  150 |  14133 |  155247 |
| Without Boxing T4 |  197 |  11493 |  147503 |
|     Boxing T5     |  222 |  16498 |  216014 |
| Without Boxing T5 |  232 |  17771 |  160188 |
---
For the Value Types, Boxing & Unboxing takes more time than a normal list of int. For a small list of int values there is a small difference in time performance, but when it comes to a bigger list of int values, as we can see, there is a big difference of time performance.

For the Reference Types, the difference is very small. For a small list, the operation without Boxing takes more time than the other with Boxing. For a bigger list, things change, and the operation with Boxing takes more time than the other without Boxing.