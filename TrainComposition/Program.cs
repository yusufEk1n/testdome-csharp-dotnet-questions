/*
    >>> LeftHead is always the leftmost wagon of the train.
    >>> RightHead is always the rightmost wagon of the train.
*/

using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

public class TrainComposition
{
    public class Train
    {
        public int WagonId { get; set; }
        public Train Right { get; set; }
        public Train Left { get; set; }

        public Train(int wagonId)
        {
            WagonId = wagonId;
        }
    }

    public Train LeftHead { get; set; }
     public Train RightHead { get; set; }

    public void AttachWagonFromLeft(int wagonId)
    {
        var newTrain = new Train(wagonId);
        if (LeftHead == null)
        {
            LeftHead = newTrain;
            RightHead = newTrain;
        }
        else
        {
            newTrain.Right = LeftHead;
            LeftHead.Left = newTrain;
            LeftHead = newTrain;
        }
    }

    public void AttachWagonFromRight(int wagonId)
    {
        var newTrain = new Train(wagonId);
        if (RightHead == null)
        {
            LeftHead = newTrain;
            RightHead = newTrain;
        }
        else
        {
            RightHead.Right = newTrain;
            newTrain.Left = RightHead;
            RightHead = newTrain;
        }
    }

    public int DetachWagonFromLeft()
    {
        if(LeftHead != null)
        {
            int wagonId = LeftHead.WagonId;
            LeftHead = LeftHead.Right;
            return wagonId;
        }

        return 0;
    }

    public int DetachWagonFromRight()
    {
        if(RightHead != null)
        {
            int wagonId = RightHead.WagonId;
            RightHead = RightHead.Left;
            return wagonId;
        }

        return 0;
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}