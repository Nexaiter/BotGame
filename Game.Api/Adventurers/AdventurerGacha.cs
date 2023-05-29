using Game.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Adventurers
{
    public class AdventurerGacha
    {
        Random random = new Random();
        string rarity;

        public RarityType CommonAdventurerPull()
        {
            int rnd = random.Next(1, 11);

            if (rnd > 6)
            {
                return RarityType.Uncommon;
            }
            return RarityType.Common;
        }
        public RarityType UncommonAdventurerPull()
        {
            int rnd = random.Next(1, 11);

            if(rnd < 3)
            {
                return RarityType.Common;
            }
            else if(rnd > 2 || rnd < 7)
            {
                return RarityType.Uncommon;
            }
            return RarityType.Rare;
        }




    }
}
