# Searching with Merge Sort and Balanced Binry Search Tree Paraller and Sequential

The program is create a test case and store it in a text file and then reading it


Sequential algorithm,

Reading an array of integers and sort it using merge sort
algorithm then put the sorted array in the balanced binary search
tree, to search for a specific element.

Timing on 100 million data length:
1- 52 ms
2- 55 ms
3- 44 ms
4- 51 ms
5- 57 ms
6- 46 ms
7- 46 ms
8- 54 ms


Parallel algorithm,

Reading an array of integers and divide it into four parts and sort each
part separately using four threads and then put four parts in four
balanced binary search tree by four threads also, and decide which
thread gonna start to search by comparing start value and end value
of BBST with the element I want to search for.

Timing on 100 million data length:
1- 31 ms
2- 35 ms
3- 35 ms
4- 32 ms
5- 32 ms
6- 35 ms
7- 36 ms
8- 34 ms
9- 33 ms
