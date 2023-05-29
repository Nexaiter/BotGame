using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Enums
{
    public enum EmbedButtonId
    {
        [Description("Main Menu")]
        MainMenu = 1,
        [Description("Help Menu")]
        HelpMenu = 2,
        [Description("Player Profile")]
        PlayerProfile = 3,
        [Description("Adventurer Menu")]
        AdventurerMenu = 4,
        [Description("Adventurer List")]
        AdventurerList = 5,
        [Description("Adventurer Pull")]
        AdventurerPull = 6,
        [Description("Guild")]
        Guild = 7,
        [Description("News board")]
        NewsBoard = 8,
        [Description("Hints board")]
        HintsBoard = 9,
        [Description("Lore Book")]
        LoreBook = 10,
        [Description("Ticket Shop")]
        TicketShop = 11


    }
}
