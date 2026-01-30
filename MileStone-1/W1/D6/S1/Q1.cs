using System;

public class Animal{

    public virtual void MakeSound(){
        Console.WriteLine("Some generic animal sound");
    }
}

public class Dog: Animal{

    public override void MakeSound(){
        Console.WriteLine("Bark");
    }
}

public class Cat: Animal{

    public override void MakeSound(){
        Console.WriteLine("Meow");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        if(n == 0){
            Console.WriteLine("Please enter a valid positive integer.");
            return;
        }

        string[] arr = new string[n];

        for(int i = 0; i < n; i++){
            arr[i] = Console.ReadLine();
        }

        Console.WriteLine("Sounds of the animals in the array:");

        Animal an = new Animal();
        Dog d = new Dog();
        Cat c = new Cat();

        for(int i = 0; i < n; i++){
            if(arr[i] == "animal"){
                an.MakeSound();
            }
            else if(arr[i] == "dog"){
                d.MakeSound();
            }
            else if(arr[i] == "cat"){
                c.MakeSound();
            }
        }
    }
}
