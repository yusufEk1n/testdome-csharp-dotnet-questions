/*
    >>> if discountType is Standard or Weight and cartWeight is less than or equal to 10, then return totalPrice * 0.94
    >>> if discountType is Seasonal, then return totalPrice * 0.88
    >>> otherwise, return totalPrice * 0.82
*/

using System;
public class MegaStore
{
    public enum DiscountType
    {
        Standard,
        Seasonal,
        Weight
    }
  
    public static double GetDiscountedPrice(double cartWeight, 
                                            double totalPrice, 
                                            DiscountType discountType)
    {
        if((discountType == DiscountType.Standard) || (discountType == DiscountType.Weight && cartWeight <= 10))
        {
            return totalPrice * 0.94;
        }
        else if(discountType == DiscountType.Seasonal)
        {
            return totalPrice * 0.88;
        }
        else
        {
            return totalPrice * 0.82;
        }
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine(GetDiscountedPrice(12, 100, DiscountType.Weight));
    }
}