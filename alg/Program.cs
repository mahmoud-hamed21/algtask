using System;

class HeapSort_
{
    // Main HeapSort Method
    public static void HeapSort(int[] array)
    {
        int n = array.Length;

        // Step 1: Build Max-Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // Step 2: Extract elements from the heap
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (maximum) with the last element
            Swap(array, 0, i);

            // Restore heap property for the reduced heap
            Heapify(array, i, 0);
        }
    }

    // Heapify Method: Maintains max-heap property for a subtree
    private static void Heapify(int[] array, int n, int i) //O(log n)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // Left child
        int right = 2 * i + 2; // Right child

        // Check if left child is larger than root
        if (left < n && array[left] > array[largest])
        {
            largest = left;
        }

        // Check if right child is larger than largest so far
        if (right < n && array[right] > array[largest])
        {
            largest = right;
        }

        // If largest is not root
        if (largest != i)
        {
            Swap(array, i, largest);

            // Recursively heapify the affected subtree
            Heapify(array, n, largest);
        }
    }

    // Utility method to swap two elements in an array
    private static void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }

    // Main Program to Test HeapSort
    static void Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", array));

        HeapSort(array);

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", array));
    }
}
