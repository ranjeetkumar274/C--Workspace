    using System;

    public abstract class Shape{
        public abstract double CalculateArea();
    }

    public class Rectangle: Shape{

        public double L{get; set;}

        public double W{get; set;}

        public Rectangle(double l, double w){
            L = l;
            W = w;
        }

        public override double CalculateArea()
        {
            return L*W;
        }
    }

    public class Circle: Shape{

        public double Radius{get; set;}

        public Circle(double r){
            Radius = r;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if(n <= 0){
                Console.WriteLine("Please enter a valid positive integer.");
                return;
            }

            List<Shape> shapes = new();
            List<string> names = new();



            for(int i = 0; i < n; i++){
                string s = Console.ReadLine().ToLower();


                if(s == "rectangle"){

                    shapes.Add(new Rectangle(
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine())
                    ));
                    names.Add("Rectangle");
                }
                else{
                    shapes.Add(new Circle(double.Parse(Console.ReadLine())));
                    names.Add("Circle");
                }
            }

            Console.WriteLine("Areas of the shapes:");

            for(int i = 0; i < shapes.Count; i++){
                Console.WriteLine($"Area of Shape {i+1} ({names[i]}): {shapes[i].CalculateArea():0.##}");
            }


        }
    }
