using System;


public class Human{
    public string Name{get; set;}
    
    public int Age {get; set;}
    
    public Human(string name, int age){
        Name = name;
        Age = age;
    }
}

public class Student:Human{
    public string Department{get; set;}
    
    public double GPA{get; set;}
    
    
    public Student(string name, int age, string dept, double gPA):base(name, age){
        Department = dept;
        GPA = gPA;
    }
    
    
    public bool ValidForScholorship(){
        return GPA > 3.5;
    }
}


public class Professor:Human{
    public string Department{get; set;}
    
    public int Publications{get; set;}
    
    public Professor(string name, int age, string dept, int pbcs):base(name, age){
        Department = dept;
        Publications = pbcs;
    }
    
    
    public bool EligibleForGrant(){
        return Publications >= 10;
    }
}

public class Tester{
    
    public static void Main(String[] args){
        
        String t = Console.ReadLine();
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        
        if(t.ToUpper() == "S"){
            string dept = Console.ReadLine();
            double gpa = double.Parse(Console.ReadLine());
            
            Student s = new Student(name, age, dept, gpa);
        
        Console.WriteLine($"Name: {s.Name}");
        Console.WriteLine($"Age: {s.Age}");
        Console.WriteLine($"Department: {s.Department}");
        
        if(s.ValidForScholorship()){
            Console.WriteLine("Valid: YES");
        }else{
            Console.WriteLine("Valid: No");
        }
        }
        else if(t.ToUpper() == "P"){
        string dept = Console.ReadLine();
        int pbcs = int.Parse(Console.ReadLine());
            
        Professor p = new Professor(name, age, dept, pbcs);
        
        Console.WriteLine($"Name: {p.Name}");
        Console.WriteLine($"Age: {p.Age}");
        Console.WriteLine($"Department: {p.Department}");
        
        if(p.EligibleForGrant()){
            Console.WriteLine("Valid: YES");
        }else{
            Console.WriteLine("Valid: No");
        }
        
    }else{
        Console.WriteLine("Enter Valid Human Type.");
    }
    }
}
