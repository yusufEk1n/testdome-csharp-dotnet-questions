using System;

public class TextInput 
{
    public string currentValue = "";
    
    public virtual void Add(char c)
    {
        currentValue += c;
    }

    public string GetValue()
    {
        return currentValue;
    }
}

public class NumericInput : TextInput
{
    public override void Add(char c)
    {
        if(char.IsDigit(c))
        {
            currentValue += c;
        }
    }
}

public class UserInput
{
    public static void Main(string[] args)
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}