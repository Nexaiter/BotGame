using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Players
{
    public class PlayerProfile
    {
        public ulong UserId { get; }
        public string Name { get; set; } = "No name";
        public int AdventurerQuantityLimit { get; set; } = 10;
        public int Gold { get; set; } = 100;
        
       public PlayerProfile(ulong userId)
        {
            UserId = userId;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }


    }
}
