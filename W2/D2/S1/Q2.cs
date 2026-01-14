using System;

public class CricketMatch{
    public int[] playerScores {get; set;} = new int[5];

    public int currIdx{get; set;}=0;

    public void AddPlayerScore(int score){
        playerScores[currIdx++] = score;
    }

    public void CalculateTotalScore(){
        int sum = 0;
        for(int i = 0; i < 5; i++){
            sum += playerScores[i];
        }
        Console.WriteLine($"Total score of the cricket team: {sum}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        string[] strArr = str.Split(' ');
        int[] numArr = new int[strArr.Length];
        int score;

        CricketMatch cm = new CricketMatch();

        try{
            for(int i = 0; i < strArr.Length; i++){
                score = int.Parse(strArr[i]);
                if(score < 0 || score > 50){
                    throw new ArgumentException("Invalid score. Score must be between 0 and 50.");
                }
                if(strArr.Length > 5){
                    throw new ArgumentException("Cannot add more than 5 player scores.");
                }
                cm.AddPlayerScore(score);
            }
            cm.CalculateTotalScore();
        }catch(ArgumentException ae){
            Console.WriteLine($"Error: {ae.Message}");
        }catch(InvalidOperationException e){
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
