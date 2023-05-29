using Game.Api.Common;
using Game.Api.Enums;
using Game.Api.Players;
using System.Security.Cryptography.X509Certificates;

namespace Game.Api
{
    public static class GameManager
    {
        public static void Launch()
        {
            Game.GetInstance();
        }
        public static async void LaunchBackgroundLoop()
        {
            Game.BackgroundEventHandling();
        }

        public static void SetupMessage(ulong userId, Func<FullMessage, bool, Task> sendMessagePrivate, Func<FullMessage, bool, Task> sendMessagePublic)
        {
            Message.Setup(userId, sendMessagePrivate, sendMessagePublic);
        }
        public static void Play(ulong userId, string commandName)
        {
            Game.GameLoop(userId, commandName);
        }
        public static void PlayWithButton(ulong userId, string buttonId, Func<FullMessage, Task> updateMessage)
        {
            var player = PlayerProfiles.GetPlayerById(userId);

            var (enumType, enumValue) = EnumHelper.GetEnumTypeAndValueWithSeparator(buttonId);

            FullMessage embedTemplate = enumType switch
            {
                EmbedButtonId => EmbedButtonIdSwitch(enumValue, player),
               FunctionButtonId => FunctionButtonIdSwitch(enumValue, player),
            };

            ////////////////////////////
            updateMessage(embedTemplate);





        }

        private static FullMessage EmbedButtonIdSwitch(string buttonId, PlayerProfile player)
        {
            return (Enum.Parse<EmbedButtonId>(buttonId)) switch
            {
                EmbedButtonId.MainMenu => EmbedTemplates.MainMenuEmbed,
                EmbedButtonId.PlayerProfile => EmbedTemplates.PlayerProfileEmbed(player),
                EmbedButtonId.HelpMenu => EmbedTemplates.HelpMenuEmbed,
                EmbedButtonId.AdventurerMenu => EmbedTemplates.AdventurerMenuEmbed,
                EmbedButtonId.AdventurerList => EmbedTemplates.AdventurerListEmbed,
                EmbedButtonId.AdventurerPull => EmbedTemplates.AdventurerPullEmbed,
                EmbedButtonId.TicketShop => EmbedTemplates.TicketShopEmbed(player),
                EmbedButtonId.Guild => EmbedTemplates.GuildEmbed,
                EmbedButtonId.NewsBoard => EmbedTemplates.NewsBoardEmbed,
                EmbedButtonId.HintsBoard => EmbedTemplates.HintsBoardEmbed,
                EmbedButtonId.LoreBook => EmbedTemplates.LoreBookEmbed,
                _ => throw new NotImplementedException("Not implemented switch embed default")
            };
        }

        private static FullMessage FunctionButtonIdSwitch(string buttonId, PlayerProfile player)
        {
            return (Enum.Parse<FunctionButtonId>(buttonId)) switch
            {
                FunctionButtonId.AddCrystal => EmbedFunctionTemplates.DefaultEmbed(player.AddCrystals, 10, player),
                FunctionButtonId.ChangeName => EmbedFunctionTemplates.DefaultEmbed(player.ChangeName, "name", player),
                FunctionButtonId.BuyCommonTicket => EmbedFunctionTemplates.TicketEmbed(PlayerFunctions.BuyCommonTicket, player),
                FunctionButtonId.BuyUncommonTicket => EmbedFunctionTemplates.TicketEmbed(PlayerFunctions.BuyUncommonTicket, player),
                FunctionButtonId.BuyRareTicket => EmbedFunctionTemplates.TicketEmbed(PlayerFunctions.BuyRareTicket, player),
                FunctionButtonId.BuySuperRareTicket => EmbedFunctionTemplates.TicketEmbed(PlayerFunctions.BuySuperRareTicket, player),
             
                _ => throw new NotImplementedException("Not implemented switch embed default")
            } ;

        }

        public static void PlayWithSelectMenu(ulong userId, string menuId, Func<FullMessage, Task> updateMessage)
        {
            throw new NotImplementedException();
        }
    }
}
