using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using dotnetapp.Models;
using System.Runtime.CompilerServices;



namespace dotnetapp.Managers
{
    public class PlayerManager:IPlayerManager
    {
        private static List<Player> players =new List<Player>();

        private string connectionString="User ID:sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Encrypt=False;";

        public void AddPlayer(int teamId)
        {
            Player p=new Player();
            Console.Write("Enter Player Name: ");
            p.Name=Console.ReadLine();

            Console.Write("Enter Age: ");
            p.Age=int.Parse(Console.ReadLine());

            Console.Write("Enter Category: ");
            p.Category=Console.ReadLine();

            Console.Write("Enter Bidding Price: ");
            p.BiddingPrice=decimal.Parse(Console.ReadLine());

            p.TeamId=teamId;
            p.Id=players.Count+1;

            players.Add(p);
            Console.WriteLine("Player added successfully!");
        }

        public void ListPlayers()
        {
            foreach(var p in players)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Age: {p.Age}, Category: {p.Category}, Price: {p.BiddingPrice}, TeamId: {p.TeamId}");

            }
        }

        public void FindPlayer(string name)
        {
            var p=players.Find(x=>x.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
            if(p!=null)
            Console.WriteLine($"Found: {p.Name}, Age:{p.Age}, Category: {p.Category}");
            else
            Console.WriteLine("Player not found");
        }

        public void EditPlayer()
        {
            Console.WriteLine("Enter Player Id: ");
            int id=int.Parse(Console.ReadLine());
            var p=players.Find(x=>x.Id==id);
            if(p==null)
            return;

            Console.Write("New Name: ");
            p.Name=Console.ReadLine();
            Console.Write("New Age: ");
            p.Age=int.Parse(Console.ReadLine());
            Console.WriteLine("Player updated!");
        }

        public void DeletePlayer()
        {
            Console.Write("Enter Player ID:");
            int id=int.Parse(Console.ReadLine());
            players.RemoveAll(p=>p.Id==id);
        }

        public void AddPlayerToDB(int teamId)
        {
            try{
                using SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                Console.Write("Enter Player Name: ");
                string name=Console.ReadLine();

                Console.Write("Enter Age: ");
                int age=int.Parse(Console.ReadLine());

                Console.Write("Enter Category: ");
                string category=Console.ReadLine();

                Console.Write("Enter Bidding Price: ");
                decimal price=decimal.Parse(Console.ReadLine());


                string query=@"insert into Players(Name,Age,Category,BiddingPrice,TeamId) values(@Name,@Age,@Category,@Price,@TeamId)";

                SqlCommand cmd=new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age",age);
                cmd.Parameters.AddWithValue("@Category",category);
                cmd.Parameters.AddWithValue("@Price",price);
                cmd.Parameters.AddWithValue("@TeamId",teamId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player added to DB successfully!");
                
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Error: "+ex.Message);
            }
        }

        public void ListPlayersFromDB()
        {
            try
            {
                using SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                string query=@"select p.Id,p.Name,p.Age,p.Category,p.BiddingPrice,t.Name as Team from Players p join Teams t On p.TeamId=t.Id";
                SqlCommand cmd=new SqlCommand(query, con);
                SqlDataReader dr=cmd.ExecuteReader();

                while(dr.Read())
                {
                    Console.WriteLine($"ID: {dr["Id"]}, Name:{dr["Name"]},Age: {dr["Age"]}, Category: {dr["Category"]}, Price:{dr["BiddingPrice"]},Team:{dr["Team"]}");
                }



            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Error: "+ex.Message);
            }
        }

        public void EditPlayerInDB()
        {
            try
            {
                using SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                Console.Write("Enter Player ID: ");
                int id =int.Parse(Console.ReadLine());
                Console.Write("New Age: ");
                int age=int.Parse(Console.ReadLine());

                SqlCommand cmd=new SqlCommand("update Players set Age=@Age where Id=@Id",con);
                cmd.Parameters.AddWithValue("@Age",age);
                cmd.Parameters.AddWithValue("@Id",id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player updated in DB!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Error:"+ex.Message);
            }
        }

        public void DeletePlayerFromDB()
        {
            try
            {
                using SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                Console.Write("Enter PlayerID: ");
                int id=int.Parse(Console.ReadLine());
                SqlCommand cmd=new SqlCommand("delete from Players where Id=@Id",con);

                cmd.Parameters.AddWithValue("Id",id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player deleted from DB!");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Error: "+ex.Message);
            }
        }

    }
    
}
