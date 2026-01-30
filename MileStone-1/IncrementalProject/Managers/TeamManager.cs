using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dotnetapp.Models;

using dotnetapp.BLL;

namespace dotnetapp.Managers
{
    public class TeamManager:ITeamManager
    {      private static List<Team> teams=new List<Team>();
        private string connectionString="User ID:sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Encrypt=False;";

        public void AddTeam()
        {
            Team team =new Team();
            Console.Write("Enter Team Name: ");
            team.Name=Console.ReadLine();

            Console.Write("Enter Maximum Budget: ");
            team.MaximumBudget=decimal.Parse(Console.ReadLine());
            team.Id=teams.Count+1;
            teams.Add(team);
            Console.WriteLine("Team added successfully!");
        }
        
        public void ListTeams()
        {
            foreach(var team in teams)
            {
                Console.WriteLine($"Team ID: {team.Id}, Name: {team.Name}, Budget: ${team.MaximumBudget}");
            }
        }

        public void AddTeamToDB()
        {
            try{
                using SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                Console.Write("Enter Team Name: ");
                string name=Console.ReadLine();

                Console.Write("Enter Maximum Budget: ");
                decimal budget=decimal.Parse(Console.ReadLine());
                string query="insert into Teams(Name,MaximumBudget)values(@Name,@Budget)";
                SqlCommand cmd=new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@Name",name);
                cmd.Parameters.AddWithValue("@Budget",budget);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Team added to the database successfully!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Error: "+ex.Message);
            }
        }

        public void ListTeamsFromDB()
        {
            try
            {
                using SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd=new SqlCommand("select * from Teams",con);
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                      Console.WriteLine($"Team ID: {dr["Id"]}, Name: {dr["Name"]}, MaximumBudget: {dr["MaximumBudget"]}");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Error: "+ex.Message);
            }
        }

    }
}
