//ShowAll List

public List <Booking> bookings = new List<Booking>();

public void DisplayBookings(){
        if(bookings.Count==0){
            Console.WriteLine("No Booking Details Available");
        }

        Console.WriteLine("Booking List:");
        foreach(Booking b in bookings){
            b.DisplayBookingDetails();
        }
    }

//ShowAll Dictionary

Dictionary<int,Animal> Animals = new Dictionary<int, Animal>();

public void DisplayAll(){
        if(Animals.Count==0){
            Console.WriteLine("No animals Available");
        }
        foreach(var i in Animals.Values){
            i.DisplayAnimalDetails();
        }
    }


//ShowAll HashSet

public HashSet<Actor> Actors = new HashSet<Actor>();

public void ShowAllActors(HashSet<Actor> ac){
        if(ac.Count==0){
            Console.WriteLine("No Actors Available to show.");
            return;
        }
        foreach(var i in ac){
            i.DisplayActorDetails();
        }
    }
