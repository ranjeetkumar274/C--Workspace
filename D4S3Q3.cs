using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
     string inp = Console.ReadLine();
     string del = Console.ReadLine();


     StringBuilder sb = new StringBuilder();

     foreach(char ch in inp){
        if(del.IndexOf(ch) == -1){
            sb.Append(ch);
        }
     }
   

     Console.WriteLine(sb.ToString());


    }
}
