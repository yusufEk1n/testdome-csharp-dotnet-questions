/*
    >>> if inclination is negative, then it is a downhill. So, we need to increase the speed.
    >>> else if inclination is equal or greater than the current speed, then it is a uphill. Doesn't have to power to do that. Return 0.
    >>> else inclination is positive, then it is a flat surface or a uphill. So, we need to decrease the speed. 
*/

using System;
public class GamePlatform
{
    public static double CalculateFinalSpeed(double initialSpeed, int[] inclinations)
    {
        double currentSpeed = initialSpeed;

        foreach(int inclination in inclinations)
        {
            if(inclination >= 90)
            {
                return 0;
            }
            
            if(inclination < 0)
            {
                currentSpeed += inclination * (-1);
            }
            else if(inclination >= currentSpeed)
            {
                return 0;
            }
            else 
            {
                currentSpeed -= inclination;
            }
        }

        return currentSpeed;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine(CalculateFinalSpeed(60, new int[] { 0, 30, 0, -45, 0 }));
    }
}