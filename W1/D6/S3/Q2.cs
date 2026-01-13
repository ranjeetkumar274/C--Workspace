using System;

sealed class circle{
    private const double PI=3.14;
    private int radius;
    public circle(int radius){
        this.radius = radius;
    }
    public double Area(){
        return PI*radius*radius;
    }
    public double Circumference(){
        return 2*PI*radius;
    }
}

static class MathUtilities{
    public static int Square(int n){
        return n*n;
    }
    public static int Cube(int n){
        return n*n*n;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int r=int.Parse(Console.ReadLine());
        int n=int.Parse(Console.ReadLine());
        circle circle=new circle(r);
        Console.WriteLine("Area of Circle: " +circle.Area());
        Console.WriteLine("Circumference of Circle: "+circle.Circumference());
        Console.WriteLine("Square of "+n+": "+MathUtilities.Square(n));
        Console.WriteLine("Cube of "+n+": "+MathUtilities.Cube(n));

    }
}
