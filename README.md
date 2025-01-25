# FindClosestPairOfPoints

Find the closest pair of points on a grids

## Divide and Conquerer Approach

This project implements the **divide and conquerer**  approach to _recursively_ find the closest pair of points on a map.


## ASCII Diagram of Operations
```
        scan ->                 
      Y                           
      |         a2         
      |                   
      |   a1           a3   
X--------------------------
      |     b1           b3
      |             b2
```

## Get Started

[!NOTE]
**dotnet build** to build the project

[!NOTE]
**dotnet restore** to restore nuget packages

[!NOTE]
**dotnet test** to run dotnet unit tests

[!IMPORTANT]
**dotnet run** to run project

## GitHub Actions

[!IMPORTANT]
**testing.yml** file contains code relevant for GitHub Actions to automatically run unit tests on code push or when a pull request is opened. _runs-on: ${{matrix.os}}_ is responsible for running unit tests on all operating systems: _ubuntu-latest_, _windows-latest_, _macOS-latest_.

## Links to relevant resources

Closest Pair of Points using Divide and Conquer algorithm: [Closest Pair of Points (via Geeks for Geeks)](https://www.geeksforgeeks.org/closest-pair-of-points-using-divide-and-conquer-algorithm/).

Algorithmic Formula [(Here)]("https://www.geeksforgeeks.org/wp-content/ql-cache/quicklatex.com-dcc2367d33eb48645a76fa11a03537a7_l3.svg)

## Big O Complexities

Time Complexity Let Time complexity of above algorithm be T(n). Let us assume that we use a _**O(nLogn)**_ sorting algorithm. The above algorithm divides all points in two sets and recursively calls for two sets. After dividing, it finds the strip in O(n) time, sorts the strip in _**O(nLogn)**_ time and finally finds the closest points in strip in O(n) time. So T(n) can expressed as follows 
_**T(n) = 2T(n/2) + O(n) + O(nLogn) + O(n)**_ 
_**T(n) = 2T(n/2) + O(nLogn)**_
_**T(n) = T(n x Logn x Logn)**_

Auxiliary Space: _**O(log n)**_

Notes 
1) Time complexity can be improved to _**O(nLogn)**_ by optimizing step 5 of the above algorithm. We will soon be discussing the optimized solution in a separate post. 
2) The code finds smallest distance. It can be easily modified to find the points with the smallest distance. 
3) The code uses quick sort which can be _**O(n^2)**_ in the worst case. To have the upper bound as _**O(n (Logn)^2)**_, a _**O(nLogn)**_ sorting algorithm like merge sort or heap sort can be used 