using Game.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Adventurers
{
    public class Ticket
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RarityType Rarity { get; set; }
        public int CrystalCost { get; set; }
        public int OrbCost { get; set; }
        public int HeroSoulCost { get; set; }


        public static Ticket Create(RarityType rarity)
        {
            return rarity switch 
            {
                RarityType.Common => new Ticket("Common Ticket", "Can summon Common and Uncommon adventurers",10,0,0),
                RarityType.Uncommon => new Ticket("Uncommon ticket", "Can summon Common, Uncommon and Rare adventurers",100,0,0),
                RarityType.Rare => new Ticket("Rare ticket", "Can summon Uncommon,Rare and Super rare adventurers",0,50,0),
                RarityType.SuperRare => new Ticket("Super Rare ticket","Can summon Rare, Super and Ultra rare adventureres",0,0,1),
                RarityType.UltraRare => new Ticket("Ultra Rare ticket","Guaranteed Ultra rare adventurer",0,0,0),
                _ => new Ticket("common ticket", "worst one",10,0,0)
            };

        }

        public Ticket(string name, string description, int crystalCost, int orbCost, int heroSoulCost)
        {
            Name = name;
            Description = description;
            CrystalCost = crystalCost;
            OrbCost = orbCost;
            HeroSoulCost = heroSoulCost;
        }


    }
}
