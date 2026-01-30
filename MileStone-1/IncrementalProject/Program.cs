using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.BLL;
using System.Data.SqlClient;


namespace dotnetapp
{
    class Program
    {
        static void Main(string[] args)
        {
                   PlayersBLL pBll=new PlayersBLL();
                   TeamsBLL tBll=new TeamsBLL();

                   while(true)
                   {
                    Console.WriteLine("\nIPL Bidding Console App Menu:");
                    Console.WriteLine("1. Add Team to list");
                    Console.WriteLine("2. List Team for list");
                    Console.WriteLine("3. Add Player to list");
                    Console.WriteLine("4. List Player from list");
                    Console.WriteLine("5. Find Player from list");
                    Console.WriteLine("6. Edit Player in list");
                    Console.WriteLine("7. Delete Player from list");
                    Console.WriteLine("8. Add Team to DB");
                    Console.WriteLine("9. List Team from DB");
                    Console.WriteLine("10. Add Player to DB");
                    Console.WriteLine("11. List Player from DB");
                    Console.WriteLine("12. Edit Player in DB");
                    Console.WriteLine("13. Delete Player from DB");
                    Console.WriteLine("14. Exit");

                    Console.Write("Enter your choice: ");
                    int ch=int.Parse(Console.ReadLine());

                    switch(ch)
                    {
                        case 1:
                        tBll.AddTeam();
                        break;

                        case 2:
                        tBll.ListTeams();
                        break;

                        case 3:
                        Console.Write("Enter Team ID:");
                        pBll.AddPlayer(int.Parse(Console.ReadLine()));
                        break;

                        case 4:
                        pBll.ListPlayers();
                        break;

                        case 5:
                        Console.Write("Enter Player Name: ");
                        pBll.FindPlayer(Console.ReadLine());
                        break;

                        case 6:
                        pBll.EditPlayer();
                        break;

                        case 7:
                        pBll.DeletePlayer();
                        break;

                        case 8:
                        tBll.AddTeamToDB();
                        break;

                        case 9:
                        tBll.ListTeamsFromDB();
                        break;

                        case 10:
                        Console.Write("Enter Team ID: ");
                        pBll.AddPlayerToDB(int.Parse(Console.ReadLine()));
                        break;

                        case 11:
                        pBll.ListPlayersFromDB();
                        break;

                        case 12:
                        pBll.EditPlayerInDB();
                        break;

                        case 13:
                        pBll.DeletePlayerFromDB();
                        break;

                        case 14:
                        return;
                    }
                   }
        }
    }
}
