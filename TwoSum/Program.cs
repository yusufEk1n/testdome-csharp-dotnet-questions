/*
    >>> We create a hashset that holds all the differences.
    >>> We check if the required diffrence value is in the hashset.
    >>> If it is, we return the index of the element and the index of the difference.

    Example:
        { 3, 1, 5, 7, 5, 9 } and sum = 10
          |  |  |  |
          >>>>>>>>>> Hashset => { 3, 1, 5 }

        list[3] = 7 and contains(10 - 7) => true
        list.IndexOf(3) = 0 and index = 3
        return Tuple.Create(3, 0)
*/

using System;
using System.Collections.Generic;

class TwoSum
{
    public static Tuple<int, int> FindTwoSum(List<int> list, int sum)
    {
        HashSet<int> arr = new HashSet<int>();
        for(int i = 0; i < list.Count; i++)
        {
            var diff = sum - list[i];

            if(arr.Contains(diff))
            {
                return Tuple.Create(i, list.IndexOf(diff));
            }
            
            arr.Add(list[i]);
        }

        return null!;
    }

    public static void Main(string[] args)
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if(indices != null) 
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}