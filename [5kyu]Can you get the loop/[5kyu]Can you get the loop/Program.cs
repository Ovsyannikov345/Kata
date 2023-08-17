using System;

public class Kata
{
    public static int getLoopSize(LoopDetector.Node startNode)
    {
        var fastPointer = startNode;

        var slowPointer = startNode;

        do
        {
            fastPointer = fastPointer.next.next;
            slowPointer = slowPointer.next;
        }
        while (fastPointer != slowPointer);

        int loopLength = 0;

        do
        {
            fastPointer = fastPointer.next;
            loopLength++;
        }
        while (fastPointer != slowPointer);

        return loopLength;
    }
}