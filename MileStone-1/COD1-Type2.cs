using System;
using System.Collections.Generic;
using System.Linq;
public class Trainer{
    public int TrainerId{get; set;}
    public string TrainerName{get; set;}
    public int Age{get; set;}
    public static int id;

    public Trainer(){

    }

    public Trainer(string name, int age){
        TrainerId = ++id;
        TrainerName = name;
        Age = age;
    }

    public void DisplayDetails(){
        Console.WriteLine($"TrainerID: {TrainerId}, Trainer Name: {TrainerName}, Age: {Age}");
    }
}

public class TrainerManager{
    public HashSet<Trainer> Trainers = new HashSet<Trainer>();

    public void AddTrainer(HashSet<Trainer> lst, Trainer obj){
        lst.Add(obj);
        Console.WriteLine("Trainer added successfully.");
    }


    public void ShowTrainersInAsc(HashSet<Trainer> lst){
        if(lst.Count == 0){
            Console.WriteLine("List is Empty.");
            return;
        }else{
            Console.WriteLine("Trainer Detail:");
            var res = lst.OrderBy(t => t.TrainerName);
            foreach(Trainer r in res){
                r.DisplayDetails();
            }
        }
    }

    public void ShowTrainers(HashSet<Trainer> lst){
        if(lst.Count == 0){
            Console.WriteLine("List is Empty.");
            return;
        }else{
            Console.WriteLine("Trainer Detail:");
            foreach(Trainer t in lst){
                t.DisplayDetails();
            }
        }
    }
}

public class Program{


    public static void Main(string[] args){

        TrainerManager tm = new TrainerManager();
        while(true){
        Console.WriteLine("1....Add Trainer");
        Console.WriteLine("2....Show Trainer");
        Console.WriteLine("3....Sorting");
        Console.WriteLine("4....Exit");


        Console.WriteLine("Enter option: ");
        int opt = int.Parse(Console.ReadLine());

        switch(opt){
            case 1:
             Console.Write("Enter Name: ");
             string n = Console.ReadLine();

             Console.Write("Enter Age: ");
             int age = int.Parse(Console.ReadLine());
             Trainer t = new Trainer(n,age);
             tm.AddTrainer(tm.Trainers,t);
             break;
            case 2:
             tm.ShowTrainers(tm.Trainers);
             break;
            case 3:
             tm.ShowTrainersInAsc(tm.Trainers);
             break;
            case 4:
             Console.WriteLine("Exitting the Program.");
             return;
             break;
            default:
             Console.WriteLine("Invalid Entry.");
             break;

        }
        }
        
    }
}
