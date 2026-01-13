using System;
using System.Collections;

public class Album{
    public string Title{get; set;}
    public string Artist{get; set;}
}

public class Program
{
    public static void Main(string[] args)
    {
     ArrayList albums = new ArrayList();

     while(true){
        string title = Console.ReadLine();

        if(title.Equals("quit", StringComparison.OrdinalIgnoreCase)){
            break;
        }
        if(!IsValidInput(title)){
            continue;
        }
        string artist = Console.ReadLine();
        if(!IsValidInput(artist)){
            continue;
        }

        Album alb = new Album();
        alb.Title = title;
        alb.Artist = artist;
        albums.Add(alb);
        
     }   

     DisplayAlbums(albums);
    }

    private static bool IsValidInput(string input){
        return !string.IsNullOrWhiteSpace(input);
    }

    private static void DisplayAlbums(ArrayList albums){
        foreach(Album alb in albums){
            Console.WriteLine($"Title: {alb.Title}, Artist: {alb.Artist}");
        }
    }
}
