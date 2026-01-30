using System;
using System.Linq.Expressions;

public class Program
{
public static int[] ParseArray(string input){
    string[] parts = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    int[] arr = new int[parts.Length];
    for(int i = 0; i < parts.Length; i++){
        arr[i] = int.Parse(parts[i]);
    }
    return arr;
}
    public static void Main(string[] args)
    {
        try{
        string input1 = Console.ReadLine();
        int[] numbers1 = ParseArray(input1);

        string input2 = Console.ReadLine();
        int[] numbers2 = ParseArray(input2);

        if(numbers1.Length != numbers2.Length){
            Console.WriteLine("Error: Arrays must have the same length for addition.");
            return;
        }

        int[] sumArr = new int[numbers1.Length];
        for(int i = 0; i < numbers1.Length; i++){
            sumArr[i] = numbers1[i] + numbers2[i];
        }

        int index = int.Parse(Console.ReadLine());

        if(index < 0 || index >= sumArr.Length){
            Console.WriteLine("Error: Index out of range for the sum array.");
            Console.WriteLine("Exception Message: Index was outside the bounds of the array.");
            return ;
        }
        Console.WriteLine($"Element at index {index} in the sum array: {sumArr[index]}");
    }
    catch(FormatException fe){
        Console.WriteLine("Error: Invalid input format. Please enter integers only.");
        Console.WriteLine("Exception Message: Input string was not in a correct format.");
    }
    }

}
