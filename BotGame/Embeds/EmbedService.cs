using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using DiscordBot.Api.Embeds;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

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
        public static Embed GenerateEmbedMessage(string message)
        {
            var embed = new EmbedBuilder();
            return embed
               .WithColor(_theme)
               .WithDescription(message)
               .Build();
        }

        public static EmbedBuilder Clone(Embed embed)
        {
            var embedBuilder = new EmbedBuilder();
            return embedBuilder
               //.WithAuthor(embed.Author!.Value.Name, embed.Author.Value.IconUrl, embed.Author.Value.Url)
               //.WithFooter(embed.Footer.Value.Text, embed.Footer.Value.IconUrl)
               .WithColor(embed.Color.Value.R, embed.Color.Value.G, embed.Color.Value.B)
               //.WithTitle(embed.Title)
               .WithDescription(embed.Description);
               //.WithCurrentTimestamp()
              // .WithFields(BuilderToEmbed(embed.Fields));

               
        }

        //public static IEnumerable<EmbedFieldBuilder> BuilderToEmbed(IEnumerable<EmbedField> fields)
        //{
            
        //    foreach (var field in fields)
        //    {
        //        var builder = new EmbedFieldBuilder();
        //        builder.WithValue(field);
        //        yield return builder;
        //    }
        //}





    }
}
