using System;
using System.Collections.Generic;
using System.Reflection;

public class Room{
    
    public int RoomId{get; set;}
    public string RoomType{get; set;}
    public decimal PricePerNight{get; set;}
    public string Availability{get; set;}
    
    public Room(int rid, string rtype, decimal ppn, string avail){
        RoomId = rid;
        RoomType = rtype;
        PricePerNight = ppn;
        Availability = avail;
    }
    
    public void DisplayRoomDetails(){
        Console.WriteLine($"Room ID: {RoomId}, Type: {RoomType}, Price: {PricePerNight}, Availability: {Availability}");
    }
}

public class HotelManager{

    Dictionary<int, Room> Rooms = new Dictionary<int, Room>();

    public void AddRoom(Room r){
        if(Rooms.ContainsKey(r.RoomId)){
            Console.WriteLine($"Room with id {r.RoomId} already exists.");
        }
        else{
            Rooms.Add(r.RoomId,r);
            Console.WriteLine($"Room with id {r.RoomId} Added successfully.");
            r.DisplayRoomDetails();
        }
    }

    public void UpdateRoom(int rid, string nrtype, decimal nrp, string na){


        bool flag = false;
            foreach(var item in Rooms.Values){
                if(item.RoomId == rid){
                    item.RoomType = nrtype;
                    item.PricePerNight = nrp;
                    item.Availability = na;
                    flag = true;
                }     
        }
        if(flag){
            Console.WriteLine($"Room with id {rid} Updated successfully.");
        }else{
            Console.WriteLine($"Room with id {rid} Not found.");
        }
        
        
    }


    public void SearchRoom(int rid){
        bool flag = false;
         foreach(var item in Rooms.Values){
            if(item.RoomId == rid){
                Console.WriteLine($"Room with id {rid} is Available : ");
                item.DisplayRoomDetails();
                flag = true;
            }
         }
         if(!flag){
            Console.WriteLine($"Room with id {rid} Not found.");
         }
         
    }

    public void DisplayRooms(){
        foreach(var item in Rooms.Values){
            item.DisplayRoomDetails();
        }
    }


}

public class Program{
    public static void Main(string[] args){

        HotelManager hm = new HotelManager();

        while(true){
            Console.WriteLine("Choose options from Menu: ");
            Console.WriteLine("1...Add Room: ");
            Console.WriteLine("2...Update Room: ");
            Console.WriteLine("3...Search Room: ");
            Console.WriteLine("4...Display All Rooms: ");
            Console.WriteLine("5...Exit: ");

            int opt = int.Parse(Console.ReadLine());

            switch(opt){
                case 1:
                 Console.Write("Enter Room Id: ");
                 int id = int.Parse(Console.ReadLine());

                 Console.Write("Enter Room Type: ");
                 string type = Console.ReadLine();

                 Console.Write("Enter Price: ");
                 decimal price = decimal.Parse(Console.ReadLine());

                 Console.Write("Enter Availability: ");
                 string avail = Console.ReadLine();

                 Room r = new Room(id,type,price,avail);
                 hm.AddRoom(r);
                 break;

                case 2:
                 Console.Write("Enter Room Id: ");
                 int nid = int.Parse(Console.ReadLine());

                 Console.Write("Enter New Room Type: ");
                 string ntype = Console.ReadLine();

                 Console.Write("Enter New Price: ");
                 decimal nprice = decimal.Parse(Console.ReadLine());

                 Console.Write("Enter New Availability: ");
                 string navail = Console.ReadLine();

                 hm.UpdateRoom(nid,ntype,nprice,navail);
                 break;

                case 3:
                 Console.Write("Enter Room Id: ");
                 int sid = int.Parse(Console.ReadLine());
                 hm.SearchRoom(sid);
                 break;

                case 4:
                 hm.DisplayRooms();
                 break;

                case 5:
                 Console.WriteLine("Exitting....");
                 return;
                 break;
                
                default:
                 Console.WriteLine("Enter valid option.");
                 break;
                 
            }
        }
    }
}
