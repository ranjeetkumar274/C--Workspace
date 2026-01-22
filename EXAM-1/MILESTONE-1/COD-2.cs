using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using Milestone_COD2.Models;


public class Program
{

    public static string str = "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Encrypt=False";
    public static SqlConnection con = new SqlConnection(str);
    
    public static void Main(string[] args)
    {
        while(true){
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. List Rooms");
            Console.WriteLine("3. Delete Room By ID");
            Console.WriteLine("4. Delete Available Rooms");
            Console.WriteLine("5. Updated Room Status");
            Console.WriteLine("6. Search Room By Type");
            Console.WriteLine("7. Sort Room By Price");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice (1-8): ");
            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                 Console.WriteLine("Enter Details of the Room: ");
                 Console.Write("Enter Room Number: ");
                 string rn = Console.ReadLine();

                 Console.Write("Enter Room Type: ");
                 string rt = Console.ReadLine();

                 Console.Write("Enter Room Price: ");
                 int pr = int.Parse(Console.ReadLine());

                 Console.Write("Enter Room Availability: ");
                 bool st = bool.Parse(Console.ReadLine());

                 Room ro = new Room(rn,rt,pr,st);
                 AddRoom(ro);
                 break;

                case 2:
                 ListRooms();
                 break;

                case 3:
                 Console.Write("Enter Room ID to delete: ");
                 int id = int.Parse(Console.ReadLine());

                 DeleteRoomById(id);
                 break;

                case 4:
                 DeleteRoomAvailableRooms();
                 break;
                
                case 5:
                 Console.Write("Enter Room ID to update: ");
                 int idd = int.Parse(Console.ReadLine());


                 Console.Write("Enter Room New Availability: ");
                 bool stt = bool.Parse(Console.ReadLine());

                 UpdateRoomAvailability(idd,stt);
                 break;

                case 6:
                 Console.Write("Enter Room Type: ");
                 string rtt = Console.ReadLine();

                 SearchRoomByType(rtt);
                 break;

                case 7:
                 SortRoomsByPriceDescending();
                 break;

                case 8:
                 Console.WriteLine("Exiting the application...");
                 return;

                default:
                 Console.WriteLine("Invalid choice");
                 break;

            }
        }
    }

    public static void AddRoom(Room r){
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms where RoomNumber = {r.RoomNumber}",con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Fill(tb);

        if(tb.Rows.Count == 1){
            Console.WriteLine("Duplicate Room Number. Cannot add room.");
            return;
        }

        DataRow dr = tb.NewRow();
        string t = r.RoomType.ToLower();
        if(t == "single" || t == "double" || t == "suite"){
        dr[1] = r.RoomNumber;
        dr[2] = r.RoomType;
        dr[3] = r.PricePerNight;
        dr[4] = r.IsAvailable;
        }
        else{
            Console.WriteLine("Enter valid room type.");
            return;
        }

        tb.Rows.Add(dr);
        da.Update(tb);
        Console.WriteLine($"Room {r.RoomNumber} added successfully.");
    }

    public static void ListRooms(){
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms",con);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("No Rooms Available.");
            return;
        }

       foreach(DataRow r in tb.Rows){
        Console.WriteLine($"RoomID: {r[0]}\tRoom Number: {r[1]}\tRoom Type: {r[2]}\tPrice: {r[3]}\tAvailablity: {r[4]}\t");
       }
    }

    public static void SearchRoomByType(string type){
        string q = type.ToLower();
        
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms where RoomType = '{q}'",con);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("No Rooms Found.");
            return;
        }

        foreach(DataRow r in tb.Rows){
        Console.WriteLine($"RoomID: {r[0]}\tRoom Number: {r[1]}\tRoom Type: {r[2]}\tPrice: {r[3]}\tAvailablity: {r[4]}\t");
       }
    }

    public static void DeleteRoomById(int id){
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms where RoomID = {id}",con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("No Room Found.");
            return;
        }

        DataRow dr = tb.Rows[0];
        dr.Delete();

        da.Update(tb);
        Console.WriteLine($"Room Deleted successfully.");
    }

    public static void DeleteRoomAvailableRooms(){
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms where IsAvailable = 1",con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("No Avialable rooms Found.");
            return;
        }

        foreach(DataRow r in tb.Rows){
            r.Delete();
        }

        da.Update(tb);
        Console.WriteLine($"Available Rooms Deleted successfully.");
    }

    public static void UpdateRoomAvailability(int id, bool status){
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms where RoomID = {id}",con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("No Room Found.");
            return;
        }

        DataRow dr = tb.Rows[0];
        dr[4] = status;

        da.Update(tb);
        Console.WriteLine($"Room's Status updated successfully.");
    }

    public static void SortRoomsByPriceDescending(){
        DataTable tb = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter($"select * from rooms order by PricePerNight desc",con);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("No Rooms Available.");
            return;
        }

       foreach(DataRow r in tb.Rows){
        Console.WriteLine($"RoomID: {r[0]}\tRoom Number: {r[1]}\tRoom Type: {r[2]}\tPrice: {r[3]}\tAvailablity: {r[4]}\t");
       }
    }
    
}
