using Discord;
using DiscordBot.Api.Embeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Api.Extensions
{
    public static class MessageChannelExtensions
    {
        public static Task SendMessageToChannel(this IMessageChannel channel, string text)
        => channel.SendMessageAsync(text);

        public static Task SendMessageWithEmbedToChannel(this IMessageChannel channel, string text)
        {
            var embed = EmbedService.GenerateEmbedMessage(text);
            var component = new ComponentBuilder()
            .WithButton("Adventurer Menu", "AdventurerList")
            .Build();
            return channel.SendMessageAsync(embed: embed,components: component);


        }
    }
}
