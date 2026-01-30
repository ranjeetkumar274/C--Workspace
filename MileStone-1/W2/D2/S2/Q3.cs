using System;

public class Program
{
    public static void Main(string[] args)
    {
        try{
            int num = int.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());
            decimal cost;
            if(num <= 0){
                throw new ArgumentException("Number of tickets must be greater than 0.");
            }else{
                if(price <= 0){
                    throw new ArgumentException("Price per ticket must be greater than 0.");
                }
                else{
                    cost = num * price;
                    Console.WriteLine($"Total ticket cost: {Math.Round(cost,2)}");
                }
            } 
        }catch(FormatException e){
            Console.WriteLine("Error: Please enter a valid number.");
        }catch(ArgumentException e){
            Console.WriteLine($"Error: {e.Message}");
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
}
