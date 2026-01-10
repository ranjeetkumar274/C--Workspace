using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        for(int i = 0; i <n; i++){
            arr[i] =  int.Parse(Console.ReadLine());
        }


        Console.WriteLine("Doubled elements:");


      for(int i = 0; i <n; i++){
            Console.WriteLine(arr[i] * 2);
        }
    }
}
