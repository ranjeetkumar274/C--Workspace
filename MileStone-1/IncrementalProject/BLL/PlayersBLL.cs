using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetapp.Managers;

namespace dotnetapp.BLL
{
    
    public class PlayersBLL
    {
        private IPlayerManager manager;
        public PlayersBLL()
        {
            manager=new PlayerManager();
        }

        public void AddPlayer(int teamId)
        {
            manager.AddPlayer(teamId);
        }

        public void ListPlayers()
        {
            manager.ListPlayers();
        }

        public void FindPlayer(string name)
        {
            manager.FindPlayer(name);
        }

        public void EditPlayer()
        {
            manager.EditPlayer();
        }

        public void DeletePlayer()
        {
            manager.DeletePlayer();
        }

        public void AddPlayerToDB(int teamId)
        {
            manager.AddPlayerToDB(teamId);
        }

        public void ListPlayersFromDB()
        {
           manager.ListPlayersFromDB();
        }

        public void EditPlayerInDB()
        {
            manager.EditPlayerInDB();
        }

        public void DeletePlayerFromDB()
        {
            manager.DeletePlayerFromDB();

        }
    }


}
