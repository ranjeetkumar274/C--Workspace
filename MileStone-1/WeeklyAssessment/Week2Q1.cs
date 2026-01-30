using System;
using System.Collections.Generic;

public class Gym{
    public List<string> Equipments;
    public const int MaxEquipments = 25;
    
    public Gym(){
        Equipments = new List<string>();
    }
    
    public void AddEquipment(string equip){
        if(string.IsNullOrWhiteSpace(equip)){
            throw new ArgumentException("Equipment name cannot be null, empty or whitespace.");
        }
        else{
            if(Equipments.Count >= MaxEquipments){
                throw new InvalidOperationException("Cannot add more than 25 equipment items.");
            }else{
                Equipments.Add(equip);
            }
        }
    }
    
    public void ShowEquipments(){
        foreach(var e in Equipments){
            Console.WriteLine(e);
        }
    }
    
    public void SearchEquipment(string name){
        bool found = Equipments.Contains(name);
        if(found){
            Console.WriteLine($"Item found : {name}");
        }else{
            Console.WriteLine("Item not found.");
        }
        
    }
}

public class Program{
    public static void Main(string[] args){
        
        Gym g = new Gym();
        
        while(true){
            
            
            Console.WriteLine("Choose your option");
            Console.WriteLine("1...Add Equipment");
            Console.WriteLine("2...Show Equipments");
            Console.WriteLine("3...Search Equipment");
            Console.WriteLine("4...Exit");
            
            int n = int.Parse(Console.ReadLine());
            try{
            switch(n){
                case 1:
                string eqp = Console.ReadLine();
                g.AddEquipment(eqp);
                break;
                
                case 2:
                g.ShowEquipments();
                break;
                
                case 3:
                string srch = Console.ReadLine();
                g.SearchEquipment(srch);
                break;
                
                case 4:
                return;
                break;
            }
            }catch(ArgumentException ae){
                Console.WriteLine(ae.Message);
            }catch(InvalidOperationException ie){
                Console.WriteLine(ie.Message);
            }
        }
    }
}
