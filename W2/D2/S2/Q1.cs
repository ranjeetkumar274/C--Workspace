using System;

public class InvalidPriceException : Exception{

    public InvalidPriceException(){}

    public InvalidPriceException(string message):base(message){}

    public InvalidPriceException(string message, Exception inner):base(message, inner){}

}

public class InvalidQuantityException : Exception{

    public InvalidQuantityException(){}

    public InvalidQuantityException(string message):base(message){}

    public InvalidQuantityException(string message, Exception inner):base(message, inner){}

}



public class Program
{
    public static void Main(string[] args)
    {
        double price = 0.0, quantity = 0.0;

        try{
            price = double.Parse(Console.ReadLine());
            if(price > 0){
                quantity = double.Parse(Console.ReadLine());
                if(quantity < 0){
                    throw new InvalidQuantityException("Error: Quantity must be greater than zero.");
                }else{
                    Console.WriteLine("Total cost is "+Math.Round((price*quantity),1));
                }
            }else{
                throw new InvalidPriceException("Error: Price must be greater than zero.");
            }
        }catch(InvalidQuantityException qe){
            Console.WriteLine(qe.Message);
        }catch(InvalidPriceException pe){
            Console.WriteLine(pe.Message);
        }catch(FormatException fe){
            Console.WriteLine("Error: Please enter a valid number.");
        }
    }
}
