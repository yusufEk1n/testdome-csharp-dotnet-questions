/*
    >>> if lessThan is within the array range, the loop continues until mid == left
    >>> if mid == left, sortedArray[mid] < lessThan < sortedArray[right] is the case.
    >>> In this case, mid + 1 is returned.
*/

using System;
public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        //lessThan out of right bound
        if(lessThan > sortedArray[sortedArray.Length - 1])
        {
            return sortedArray.Length;
        }

        //lessThan out of left bound
        if(lessThan <= sortedArray[0])
            return 0;

        int left = 0;
        int right = sortedArray.Length - 1;
        int mid = (left + right) / 2;

        while(left != mid)
        {
            if(sortedArray[mid] == lessThan)
            {
                return mid;
            }

            if(sortedArray[mid] > lessThan)
            {
                right = mid;
            }
            else
            {
                left = mid;   
            }

            mid = (left + right) / 2;
        }

        return mid + 1;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(SortedSearch.CountNumbers(new int[] { -1, 0, 1, 3, 5, 7 }, -2));
    }
}