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
    static class EmbedTemplates
    {
        //    (EnumHelper.GetEnumDescription(ButtonId.), ButtonId..ToString()),
        //register
        public static FullMessage AfterRegistrationEmbed { get; private set; } = new FullMessage(
        Description: "Welcome! You are succesfully registered. You can now proceed to main menu or see a little guide introducing the game! Good luck!",
        Buttons: new List<(string, string)>()
        {
            EmbedButtonId.MainMenu.GetButton(),
            EmbedButtonId.HelpMenu.GetButton(),
        });

        //help
        public static FullMessage HelpMenuEmbed { get; private set; } = new FullMessage(
        Description: "Welcome to help menu. Please choose what you'd like to learn about:",
        Buttons: new List<(string, string)>()
        {
            EmbedButtonId.MainMenu.GetButton(),
        });

        //menu
        public static FullMessage MainMenuEmbed { get; private set; } = new FullMessage(
        Description: "Main menu",


        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.PlayerProfile.GetButton(),
             EmbedButtonId.Guild.GetButton(),
             EmbedButtonId.HelpMenu.GetButton()
        });


        //player profile
        public static FullMessage PlayerProfileEmbed(PlayerProfile playerProfile) => new FullMessage(
        Description: $"Your profile {playerProfile.Name}. Here you can have a look at your stats.",
        Fields: new List<(string, string)>()
        {
            ("Familia name:", playerProfile.FamiliaName),
            ("Familia level:",playerProfile.FamiliaLevel.ToString()),
            ("Adventurer Limit",playerProfile.AdventurerQuantityLimit.ToString()),
            ("Your gold:",playerProfile.Gold.ToString()),
            ("Your crystals:",playerProfile.Crystal.ToString()),
            ("\u200B","\u200B"),
            ("Your orbs:",playerProfile.Orb.ToString()),
            ("Your hero souls:",playerProfile.HeroSoul.ToString()),
           // ("    \u200B","   \u200B")

        },

        Buttons: new List<(string, string)>()
        {
            FunctionButtonId.AddCrystal.GetButton(),
            FunctionButtonId.ChangeName.GetButton(),
            EmbedButtonId.AdventurerMenu.GetButton(),
            EmbedButtonId.MainMenu.GetButton()
        });

        //adventurers
        public static FullMessage AdventurerMenuEmbed { get; private set; } = new FullMessage(
        Description: "Adventurer menu. You can go to your adventurers list or try to find new ones!",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.AdventurerList.GetButton(),
             EmbedButtonId.AdventurerPull.GetButton(),
             EmbedButtonId.TicketShop.GetButton(),
             EmbedButtonId.PlayerProfile.GetButton(),
        });
        public static FullMessage AdventurerListEmbed { get; private set; } = new FullMessage(
        Description: "Adventurer list TODO",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.AdventurerMenu.GetButton(),

        });
        public static FullMessage AdventurerPullEmbed { get; private set; } = new FullMessage(
        Description: "Adventurer pull TODO",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.AdventurerMenu.GetButton(),
             EmbedButtonId.AdventurerList.GetButton(),
             EmbedButtonId.TicketShop.GetButton(),

        });
        public static FullMessage TicketShopEmbed(PlayerProfile playerProfile) => new FullMessage(
        Description: "Here you can buy tickets to summon adventurers.",

        Fields: new List<(string, string)>()
        {
            ("Common ticket cost: 10 crystals", $"You have: {playerProfile.Crystal.ToString()}"),
            ("Uncommon ticket cost: 100 crystals",$"You have: {playerProfile.Crystal.ToString()}"),
            ("\u200B","   \u200B"),
            ("Rare ticket cost: 50 orbs",$"You have: {playerProfile.Orb.ToString()}"),
            ("Super rare ticket cost: 1 hero soul",$"You have: {playerProfile.HeroSoul.ToString()}"),
            ("\u200B","   \u200B"),
            ($"You have {playerProfile.CommonTicketAmount.ToString()} C, {playerProfile.UncommonTicketAmount.ToString()} U, {playerProfile.RareTicketAmount.ToString()} R, {playerProfile.SuperRareTicketAmount.ToString()} SR, {playerProfile.UltraRareTicketAmount.ToString()} UR tickets.","\u200B")
                      

        },

        Buttons: new List<(string, string)>()
        {
             FunctionButtonId.BuyCommonTicket.GetButton(),
             FunctionButtonId.BuyUncommonTicket.GetButton(),
             FunctionButtonId.BuyRareTicket.GetButton(),
             FunctionButtonId.BuySuperRareTicket.GetButton(),
             EmbedButtonId.AdventurerMenu.GetButton(),
             EmbedButtonId.AdventurerPull.GetButton(),

        });
        //guild embeds
        public static FullMessage GuildEmbed { get; private set; } = new FullMessage(
        Description: "Guild TODO",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.NewsBoard.GetButton(),
             EmbedButtonId.HintsBoard.GetButton(),
             EmbedButtonId.LoreBook.GetButton(),
             EmbedButtonId.MainMenu.GetButton()


         });
        public static FullMessage NewsBoardEmbed { get; private set; } = new FullMessage(
        Description: "News Board TODO",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.Guild.GetButton(),
             EmbedButtonId.MainMenu.GetButton()


           });
        public static FullMessage HintsBoardEmbed { get; private set; } = new FullMessage(
         Description: "Hint board TODO",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.Guild.GetButton(),
             EmbedButtonId.MainMenu.GetButton()


        });
        public static FullMessage LoreBookEmbed { get; private set; } = new FullMessage(
        Description: "Lore Book TODO",

        Buttons: new List<(string, string)>()
        {
             EmbedButtonId.Guild.GetButton(),
             EmbedButtonId.MainMenu.GetButton()


        });

        
    }
}
