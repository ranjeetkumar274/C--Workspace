using System;
using System.Collections.Generic;

public class Booking{
    public int BookingId{get; set;}
    public string PassengerName{get; set;}
    public string FlightNumber{get; set;}
    public string SeatNumber{get; set;}
    public string Destination{get; set;}

    public Booking(){}

    public Booking(int id, string pname, string flightnum, string seatnum, string dest){
        BookingId = id;
        PassengerName = pname;
        FlightNumber = flightnum;
        SeatNumber = seatnum;
        Destination = dest;
    }

    public void DisplayBooking(){
        Console.WriteLine($"Booking ID: {BookingId}, Passenger Name: {PassengerName}, FlightNumber: {FlightNumber}, Seat Number: {SeatNumber}, Destination: {Destination}");
    }
}

public class BookingManager{

    public HashSet<Booking> bookings = new HashSet<Booking>();

    public void AddBooking(HashSet<Booking> hs,Booking b){
        var res = hs.FirstOrDefault(a => a.BookingId == b.BookingId);
        if(res != null){
            Console.WriteLine("Booking is already exists.");
            return;
        }
        hs.Add(b);
        Console.WriteLine("Booking added successfully.");
    }

    public void UpdateBookingDestination(HashSet<Booking> hs,int id, string dest){
        var res = hs.FirstOrDefault(a => a.BookingId == id);
        if(res == null){
            Console.WriteLine("Booking is not available.");
            return;
        }

        res.Destination = dest;
        Console.WriteLine("Booking updated successfully.");
    }

    public void DeleteBookingById(HashSet<Booking> hs,int id){
       var res = hs.FirstOrDefault(a => a.BookingId == id);
       if(res == null){
        Console.WriteLine("Booking is not available.");
        return;
       }

       hs.Remove(res);
       Console.WriteLine("Booking deleted successfully.");
    }


    public void SearchBookingById(HashSet<Booking> hs,int id){
        var res = hs.FirstOrDefault(a => a.BookingId == id);
        if(res == null){
            
            Console.WriteLine("Bookings is not available,");
            return;
        }

        res.DisplayBooking();

    }

    public void DisplayAllBookings(HashSet<Booking> hs){

        if (hs.Count==0)
        {
            Console.WriteLine("No bookings available.");
            return;
        }

       foreach(var v in hs){
        v.DisplayBooking();
       }

    }
}

public class Program{
    public static BookingManager bm = new BookingManager();
    public static void Main(string[] args){

        while(true){
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Booking");
            Console.WriteLine("2. List All Bookingss");
            Console.WriteLine("3. Update Destination");
            Console.WriteLine("4. Search Booking By Id");
            Console.WriteLine("5. Delete Booking");
            Console.WriteLine("6. Exit");
            Console.Write("Select your option: ");
            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                 Console.Write("Booking ID:");
                 int id = int.Parse(Console.ReadLine());

                 Console.Write("Passenger Name:");
                 string pn = Console.ReadLine();

                 Console.Write("Flight Number:");
                 string fn = Console.ReadLine();

                 Console.Write("Seat Number:");
                 string sn = Console.ReadLine();

                 Console.Write("Destination:");
                 string dest = Console.ReadLine();

                 Booking b = new Booking(id,pn,fn,sn,dest);
                 bm.AddBooking(bm.bookings, b);
                 break;
                
                case 2:
                bm.DisplayAllBookings(bm.bookings);
                break;

                case 3:
                Console.Write("Booking ID:");
                int idd = int.Parse(Console.ReadLine());

                Console.Write("Enter Destination: ");
                string destt = Console.ReadLine();
                bm.UpdateBookingDestination(bm.bookings,idd,destt);
                break;

                case 4:
                Console.Write("Booking ID:");
                int iddd = int.Parse(Console.ReadLine());
                bm.SearchBookingById(bm.bookings,iddd);
                break;

                 case 5:
                Console.Write("Booking ID:");
                int idddd = int.Parse(Console.ReadLine());
                bm.DeleteBookingById(bm.bookings,idddd);
                 break;

                 case 6:
                 Console.WriteLine("Exiting the program...");
                 return;

                 default:
                 Console.WriteLine("Invalid choice.");
                 break;
            }
        }
    }
}
