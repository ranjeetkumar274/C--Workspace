using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetapp.Managers;

namespace dotnetapp.BLL
{
  public class TeamsBLL
  {
   
   private ITeamManager manager;
   public TeamsBLL()
   {
    manager=new TeamManager();
   }

   public void AddTeam()
   {
    manager.AddTeam();
   }

   public void ListTeams()
   {
         manager.ListTeams();
   }

   public void AddTeamToDB()
   {
      manager.AddTeamToDB();
   }

   public void ListTeamsFromDB()
   {
    manager.ListTeamsFromDB();
   }




  }

}
