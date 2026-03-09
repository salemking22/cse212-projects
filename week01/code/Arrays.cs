using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new array of size 'length'.
        // 2. Loop from 0 up to length - 1.
        // 3. For each index i, calculate (number * (i+1)).
        // 4. Store the result in the array.
        // 5. Return the array.

        double[] result = new double[length];   // Step 1
        for (int i = 0; i < length; i++)        // Step 2
        {
            result[i] = number * (i + 1);       // Step 3 & 4
        }
        return result;                          // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be  
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Handle empty list case.
        // 2. Use modulo (%) to adjust rotation if amount > list length.
        // 3. Slice the list into two parts:
        //    - The last 'amount' elements.
        //    - The remaining elements at the front.
        // 4. Clear the original list.
        // 5. Add the slices back in order (tail first, then head).
        // 6. Done.

        if (data.Count == 0) return;            // Step 1
        amount = amount % data.Count;           // Step 2

        List<int> tail = data.GetRange(data.Count - amount, amount); // Step 3a
        List<int> head = data.GetRange(0, data.Count - amount);      // Step 3b

        data.Clear();                           // Step 4
        data.AddRange(tail);                    // Step 5a
        data.AddRange(head);                    // Step 5b
    }
}