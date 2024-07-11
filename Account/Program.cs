using System;

public class Account
{
    [Flags]
    public enum Access
    {
        Delete = 1,         // 0000 0001
        Publish = 1 << 1,   // 0000 0010
        Submit = 1 << 2,    // 0000 0100
        Comment = 1 << 3,   // 0000 1000
        Modify = 1 << 4,    // 0001 0000
        Writer = Submit | Modify,
        Editor = Delete | Publish | Comment,
        Owner = Writer | Editor
    }
    
    public static void Main(string[] args)
    {
        var a = Access.Writer.HasFlag(Access.Submit);
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}