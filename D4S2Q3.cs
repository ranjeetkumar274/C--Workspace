using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        string inp = Console.ReadLine() ?? string.Empty;
        if(inp.Length == 0){
            Console.WriteLine("Compressed string: ");
            return;
        }  

        StringBuilder com = new StringBuilder();

        char[] arr = inp.ToCharArray();

        int i = 0;

        while(i < arr.Length){
            char ch = arr[i];
            int count = 0;

            while(i < arr.Length && arr[i] == ch){
                count++;
                i++;
            }

            com.Append(ch);
            com.Append(count);
        }             

        if(com.Length >= inp.Length){
            Console.WriteLine($"Compressed string: {inp}");
        }
        else{
            Console.WriteLine($"Compressed string: {com}");
        }

    }
}
