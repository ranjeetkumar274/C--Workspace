using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Team
    {
        public int Id{get; set;}
        public string Name{get; set;}

        public decimal MaximumBudget{get; set;}

        public List<Player> Players{get; set;}=new List<Player>();
    }
}
