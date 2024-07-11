/*
    >>> if boat is moving to right:
        1. row is constant.
        2. toColumn > fromColumn.
        3. toColumn is not out of bounds.
        4. Can move at most 2 units to the right.
    
    >>> if boat is moving to left:
        1. row is constant.
        2. toColumn < fromColumn.
        3. toColumn is not out of bounds.
        4. Can move only 1 unit to the left.

    >>> if boat is moving to down:
        1. column is constant.
        2. toRow > fromRow.
        3. toRow is not out of bounds.
        4. Can move only 1 unit to the down.

    >>> if boat is moving to up:
        1. column is constant.
        2. toRow < fromRow.
        3. toRow is not out of bounds.
        4. Can move only 1 unit to the up.
*/

using System;

public class BoatMovements
{
    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        bool moveToRight = (fromRow == toRow) && (toColumn > fromColumn) && (toColumn < gameMatrix.GetLength(1)) && (toColumn - fromColumn < 3);
        bool moveToLeft =  (fromRow == toRow) && (toColumn < fromColumn) && (toColumn >= 0) && (fromColumn - toColumn < 2);
        bool moveToDown = (fromColumn == toColumn) && (toRow > fromRow) && (toRow < gameMatrix.GetLength(0)) && (toRow - fromRow < 2);
        bool moveToUp = (fromColumn == toColumn) && (toRow < fromRow) && (toRow >= 0) && (fromRow - toRow < 2);

        if(moveToRight)
        {
            int col = fromColumn;
            while(col <= toColumn)
            {
                if(!gameMatrix[fromRow, col])
                    return false;
                col++;
            }
            return true;  
        }
        else if (moveToLeft)
        {   
            int col = fromColumn;
            while(col >= toColumn)
            {
                if(!gameMatrix[fromRow, col])
                    return false;
                col--;
            }
            return true;  
        }
        else if(moveToDown)
        {
            int row = fromRow;
            while(row <= toRow)
            {
                if(!gameMatrix[row, fromColumn])
                    return false;
                row++;
            }
            return true;
        }
        else if(moveToUp)
        {
            int row = fromRow;
            while(row >= toRow)
            {
                if(!gameMatrix[row, fromColumn])
                    return false;
                row--;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Main()
    {
        bool[,] gameMatrix = 
        {
            {false, true,  true,  false, false, false},
            {true,  true,  true,  false, false, false},
            {true,  true,  true,  true,  true,  true},
            {false, true,  true,  false, true,  true},
            {false, true,  true,  true,  false, true},
            {false, false, false, false, false, false},
        };

        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
    }
}