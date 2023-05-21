using Discord;
using Discord.WebSocket;
using DiscordBot.Api.Embeds;
using Game.Api.Common;

namespace DiscordBot.Api.Extensions
{
    public static class SocketMessageComponentExtensions
    {
        public static Task UpdateMessage(this SocketMessageComponent component, FullMessage fullMessage)
        {
            var msg = EmbedService.GenerateEmbedAndComponentsMessage(fullMessage);

            return component.UpdateAsync(x =>
                    {
                    x.Embed = msg.Embed;
                    x.Components = msg.Component;
                    });
        }
    }
}
