using Game.Api.Common;
using Game.Api.Enums;
using Game.Api.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api
{
    public static class EmbedFunctionTemplates
    {
        public static FullMessage DefaultEmbed<T>(Action<T> playerFunction, T value, PlayerProfile playerProfile)
        {
            playerFunction(value);
            return EmbedTemplates.PlayerProfileEmbed(playerProfile);

        }
        public static FullMessage TicketEmbed(Action<PlayerProfile> playerFunction, PlayerProfile value)
        {
            playerFunction(value);
            return EmbedTemplates.TicketShopEmbed(value);

        }
        
    }
}
