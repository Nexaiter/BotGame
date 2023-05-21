using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Game.Api.Common;
using System.ComponentModel;

namespace DiscordBot.Api.Embeds
{
    public class EmbedService : IEmbedService
    {
        private static readonly Color _theme = Color.DarkRed;
        public readonly string _version;
        public EmbedService()
        {
            _version = "1.0";
        }
        public Embed GenerateEmbedMessage(SocketCommandContext context, string title, string message)
        {
            var embed = new EmbedBuilder();
            return embed.WithAuthor(context.Client.CurrentUser)
               .WithFooter(footer => footer.Text = _version)
               .WithColor(_theme)
               .WithTitle(title)
               .WithDescription(message)
               .WithCurrentTimestamp()
               .AddField("Komenda wywołana przez:", $"{context.Message.Author.Mention} na kanale {((SocketTextChannel)context.Message.Channel).Mention}")
               .Build();
        }
        public static (Embed Embed, MessageComponent Component) GenerateEmbedAndComponentsMessage(FullMessage fullMessage)
        {
            var componentBuilder = new ComponentBuilder();
            if (fullMessage.Buttons is not null)
            {
                foreach (var (Label, Id) in fullMessage.Buttons)
                {
                    componentBuilder.WithButton(Label, Id);
                }
            }

            if (fullMessage.Menus is not null)
            {
                foreach (var (MenuId, PlaceHolder, options) in fullMessage.Menus)
                {
                    var selectMenuBuilder = new SelectMenuBuilder();
                    selectMenuBuilder.WithCustomId(MenuId).WithPlaceholder(PlaceHolder);
                    foreach (var (id, value) in options)
                    {
                        selectMenuBuilder.AddOption(id, value);
                    }
                    componentBuilder.WithSelectMenu(selectMenuBuilder);
                }
            }

            var embedFieldsBuilder = new List<EmbedFieldBuilder>(fullMessage.Fields?.Count() ?? 0);
            if (fullMessage.Fields is not null)
            {
                foreach (var field in fullMessage.Fields)
                {
                    embedFieldsBuilder.Add(new EmbedFieldBuilder().WithName(field));
                }
            }

            var embedBuilder = new EmbedBuilder()
            .WithColor(Color.DarkBlue)
                .WithDescription(fullMessage?.Description ?? " ")
                .WithTitle(fullMessage?.Title ?? " ")
                .WithCurrentTimestamp();

            if (embedFieldsBuilder.Count is not 0)
            {
                embedBuilder.WithFields(embedFieldsBuilder);
            }
            return (embedBuilder.Build(), componentBuilder.Build());
        }
    }
}
