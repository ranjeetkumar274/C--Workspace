using System;

public class Program
{
    public delegate double ArithmeticOperation(double a, double b);

    public static double Add(double a, double b){
        return a+b;
    }

        public static double Subtract(double a, double b){
        return a-b;
    }
        public static double Multiply(double a, double b){
        return a*b;
    }

        public static double Divide(double a, double b){
        if(b == 0){
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return a/b;
    }

    public static double PerformOperation(ArithmeticOperation operation, double a, double b){
        return operation(a,b);
    }
    public static void Main(string[] args)
    {
        try{
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            string operationInput = Console.ReadLine();

            ArithmeticOperation operation;

            switch(operationInput.ToLower()){
                case "add":
                 operation = Add;
                 break;

                case "subtract":
                 operation = Subtract;
                 break;

                case "multiply":
                 operation = Multiply;
                 break;

                case "divide":
                 operation = Divide;
                 break;

                default:
                 Console.WriteLine("Invalid operation.");
                 return;
            }

            double result = PerformOperation(operation, firstNumber, secondNumber);
            Console.WriteLine($"The result is: {result:F2}");
        }catch(DivideByZeroException ex){
            Console.WriteLine("$Error: {ex.Message}");
        }catch(FormatException){
            Console.WriteLine("Error: Please enter valid numeric values.");
        }
    }
}
