using System;
using System.Globalization;


public class StringConverter{



    public static string ConvertString(string inp){
        return inp.ToUpper();
    }

    public static string ConvertString(string inp, bool toLower){
        if(toLower){
            return inp.ToLower();
        }else{
            return "";
        }
    }

    public static string ConvertString(string inp, int a){
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase(inp);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        string inp = Console.ReadLine();

        int n = int.Parse(Console.ReadLine());

        switch(n){
             case 1:
             Console.WriteLine(StringConverter.ConvertString(inp));
             break;
             
             case 2:
             Console.WriteLine(StringConverter.ConvertString(inp, true));
             break;
             
             case 3:
             Console.WriteLine(StringConverter.ConvertString(inp, 1));
             break;

             default:
             Console.WriteLine("Invalid choice.");
             break;
             
        }

        

        
    }
}
