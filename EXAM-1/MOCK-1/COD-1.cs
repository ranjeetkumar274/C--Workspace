

//In this question we just need to practice Add and DisplayAll for MOCK-1



using System;
using System.Collections.Generic;


public class Booking{
    public int BookingId{get; set;}
    public string PassengerName{get; set;}
    public string FlightNumber{get; set;}
    public string SeatNumber{get; set;}
    public string Destination{get; set;}

    public Booking(){}

    public Booking(int id, string name, string number, string seat, string dest){
        BookingId = id;
        PassengerName = name;
        FlightNumber = number;
        SeatNumber = seat;
        Destination = dest;
    }

    public void DisplayBookingDetails(){
        Console.WriteLine($"Booking ID: {BookingId}, Passenger: {PassengerName}, Flight: {FlightNumber}, Seat: {SeatNumber}, Destination: {Destination}");
    }
}

public class BookingManager{
    public List<Booking> list = new List<Booking>();


    public void AddBooking(Booking book){
        var res = list.Find(o => o.BookingId == book.BookingId);
        if(res != null){
            Console.WriteLine("Booking Details already Present with this Id.");
            return;
        }
        list.Add(book);
        Console.WriteLine("Booking details added successfully.");
    }
    public void DisplayBookings(){
        if(list.Count == 0){
            Console.WriteLine("List is Empty.");
            return;
        }
        foreach(Booking b in list){
            b.DisplayBookingDetails();
        }
    }


}

public class Program{
    public static BookingManager bm = new BookingManager();
    public static void Main(string[] args){

        while(true){
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Booking");
            Console.WriteLine("2. Show All Bookings");;
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose Options:  ");

            int ch = int.Parse(Console.ReadLine());
            switch(ch){
                case 1:
                 Console.Write("Enter Booking Id: ");
                 int iid = int.Parse(Console.ReadLine());

                 Console.Write("Enter Passenger Name: ");
                 string namee = Console.ReadLine();

                 Console.Write("Enter Flight Number: ");
                 string fn = Console.ReadLine();

                 Console.Write("Enter Seat Number: ");
                 string sn = Console.ReadLine();

                 Console.Write("Enter Destination Name: ");
                 string desti = Console.ReadLine();

                Booking bo = new Booking(iid,namee,fn,sn,desti);
                bm.AddBooking(bo);
                break;
                
                case 2:
                 bm.DisplayBookings();
                 break;

                case 3:
                 return;
                 break;

                default:
                 Console.WriteLine("Choose Valid option. Try Again");
                 break;
            }
        }
    }
}
