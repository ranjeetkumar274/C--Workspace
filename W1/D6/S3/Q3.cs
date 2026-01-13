using System;
using System.Runtime.InteropServices;


public class StringAnalyzer{
    private static char[] Vowels = {'a','e','i','o','u','A','E','I','O','U'};
    public static(int vowelCount, int consonantCount)
    CountVowelsAndConsonants(string input){
        int vowels=0;
        int consonants=0;
        foreach(char c in input){
            if(char.IsLetter(c)){
                if(Array.Exists(Vowels,element=>element==c)){
                    vowels++;
                }
                else{
                    consonants++;
                }
            }
        }
        return(vowels,consonants);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        string input=Console.ReadLine();
        var result=StringAnalyzer.CountVowelsAndConsonants(input);
        Console.WriteLine($"Number of vowels: {result.vowelCount}");
        Console.WriteLine($"Number of consonants: {result.consonantCount}");

    }
}
