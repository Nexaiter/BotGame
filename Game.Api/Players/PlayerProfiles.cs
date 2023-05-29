using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Players
{
    public static class PlayerProfiles
    {
        public static ConcurrentBag<PlayerProfile> playerProfiles = new ConcurrentBag<PlayerProfile>();
        public static void PlayerProfileToList(PlayerProfile playerProfile)
        {
            playerProfiles.Add(playerProfile);
           
        }

        public static PlayerProfile GetPlayerById(ulong playerProfileId) => playerProfiles.First(x => x.UserId == playerProfileId);
        

    }
}
