using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Internal;

public class Program{

    public static void AddVehicle(SqlConnection con, int id, string name, string type, int year){


        string query = "Select * from Vehicle";
        DataTable tb = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(query,con);
        da.Fill(tb);

        DataRow r = tb.NewRow();
        r[0] = id;
        r[1] = name;
        r[2] = type;
        r[3] = year;

        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        tb.Rows.Add(r);
        da.Update(tb);
        Console.WriteLine("Vehicle added sucessfully!");

    }

    public static void DisplayAllVehicles(SqlConnection con){

        con.Open();

        string query = "select * from vehicle";
        SqlCommand cmd = new SqlCommand(query,con);
        SqlDataReader r = cmd.ExecuteReader();

        if(r.HasRows){
            Console.WriteLine("Vehicle Records:");
            Console.WriteLine("ID\nName\nType\nYear");
        while(r.Read()){
            Console.WriteLine($"{r[0]}\n{r[1]}\n{r[2]}\n{r[3]}");
        }
        }else{
            Console.WriteLine("No vehicle records found.");
        }

        r.Close();
        con.Close();
    }

    public static void EditVehicle(SqlConnection con, int id, string name, string type, int year){

        string query = "Select * from Vehicle where VehicleId = @id";
        DataTable tb = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(query,con);
        da.SelectCommand.Parameters.AddWithValue("@id",id);
        da.Fill(tb);

        DataRow r = tb.Rows[0];
        r[1] = name;
        r[2] = type;
        r[3] = year;

        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Update(tb);
        Console.WriteLine("Vehicle updated sucessfully!");

    }


    
    public static void Main(string[] args){
        string str = "USER ID=sa;password=examlyMssql@123;server=localhost;database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        using SqlConnection con = new SqlConnection(str);

       
        Console.WriteLine("Connection successful!");

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. Display All Vehicles");
            Console.WriteLine("3. Edit Vehicle");
            int choice = int.Parse(Console.ReadLine());
            switch(choice){
                case 1:
                 Console.Write("Vehicle ID: ");
                 int id = int.Parse(Console.ReadLine());

                 Console.Write("Vehicle Name: ");
                 string name = Console.ReadLine();

                 Console.Write("Vehicle Type: ");
                 string type = Console.ReadLine();

                 Console.Write("Manufacture Year: ");
                 int year = int.Parse(Console.ReadLine());

                 AddVehicle(con,id,name,type,year);
                 break;

                case 2:
                 DisplayAllVehicles(con);
                
                 break;

                case 3:
                 Console.Write("Enter Vehicle ID to edit: ");
                 int nid = int.Parse(Console.ReadLine());

                 Console.Write("New Vehicle Name: ");
                 string nname = Console.ReadLine();

                 Console.Write("New Vehicle Type: ");
                 string ntype = Console.ReadLine();

                 Console.Write("New Manufacture Year: ");
                 int nyear = int.Parse(Console.ReadLine());

                 EditVehicle(con,nid,nname,ntype,nyear);
                 break;

                default:
                 break;
            }

    }
}
