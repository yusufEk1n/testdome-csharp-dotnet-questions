/*
    >>> for each cell, accessible right, left, up and down directions are searched. If the cell is accessible, it returns true, otherwise it returns false.
    >>> returns false when out of bounds.
    >>> solution from https://github.com/jdegand/testdome-csharp-questions/blob/main/RoutePlanner.cs
*/

using System;
public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {

        if(toRow >= mapMatrix.GetLength(0) || toRow < 0 || toColumn >= mapMatrix.GetLength(1) || toColumn < 0)
        {
            return false;
        }
        
        bool[,] visited = new bool[mapMatrix.GetLength(0), mapMatrix.GetLength(1)];

        return FindPath(fromRow, fromColumn, toRow, toColumn, mapMatrix, visited);
    }

    public static bool FindPath(int row, int col, int toRow, int toColumn, bool[,] mapMatrix, bool[,] visited)
    {
        if(row < 0 || col < 0 || row >= mapMatrix.GetLength(0) || col >= mapMatrix.GetLength(1) || !mapMatrix[row, col] || visited[row, col])
        {
            return false;
        }

        if(row == toRow && col == toColumn)
        {
            return true;
        }

        visited[row, col] = true;

        if(FindPath(row + 1, col, toRow, toColumn, mapMatrix, visited) ||
           FindPath(row - 1, col, toRow, toColumn, mapMatrix, visited) ||
           FindPath(row, col + 1, toRow, toColumn, mapMatrix, visited) ||
           FindPath(row, col - 1, toRow, toColumn, mapMatrix, visited))
        {
            return true;
        }

        return false;
    }
    
    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, true, false},
            {true, false, true},
            {true, true, true}
        };
        
        Console.WriteLine(RouteExists(0, 0, 1, 2, mapMatrix));
    }
}