//Add List
public void AddBooking(Booking booking){
        var res=bookings.Find(a=>a.BookingId==booking.BookingId);
        if(res !=null){
            Console.WriteLine($"A booking with ID {booking.BookingId} already exists.");
            return;
        }

        bookings.Add(booking);
        Console.WriteLine("Booking Added Successfully");
    }


//Add Dictionary
 Dictionary<int,Animal> Animals = new Dictionary<int, Animal>();

    public void AddAnimal(Animal obj){
        if(Animals.ContainsKey(obj.AnimalId)){
            Console.WriteLine("Already exists");
            return;
        }

        Animals.Add(obj.AnimalId, obj);
        Console.WriteLine("Added");
        return;
    }


//Add HashSet
public void AddActors(HashSet<Actor> ac, Actor obj){
        var res = ac.FirstOrDefault(a=>a.ActorId==obj.ActorId);

        if (res!=null){
            Console.WriteLine("Actor already Added.");
            return;
        }

        ac.Add(obj);
        Console.WriteLine("Actor Added Successfully.");
    }
