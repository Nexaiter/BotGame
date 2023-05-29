using Game.Api.Adventurers;
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
        public int FamiliaLevel { get; set; } = 1;
        public string FamiliaName { get; set; } = "No familia established yet";
        public int AdventurerQuantityLimit { get; set; } = 10;
        public List<Adventurer> Adventurer { get; set; }
        public int Gold { get; set; } = 100;
        public int Crystal { get; set; } = 1000;
        public int Orb { get; set; } = 1000;
        public int HeroSoul { get; set; } = 1000;
        public int CommonTicketAmount { get; set; } = 0;
        public int UncommonTicketAmount { get; set; } = 0;
        public int RareTicketAmount { get; set; } = 0;
        public int SuperRareTicketAmount { get; set; } = 0;
        public int UltraRareTicketAmount { get; set; } = 0;


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
