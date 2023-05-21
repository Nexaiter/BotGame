using Discord;
using DiscordBot.Api.Embeds;
using Game.Api.Common;

namespace DiscordBot.Api.Extensions
{
    public static class MessageChannelExtensions
    {
        public static Task SendMessageToChannel(this IMessageChannel channel, string text)
        => channel.SendMessageAsync(text);

        public static Task SendMessageToChannel(this IMessageChannel channel, FullMessage fullMessage, bool isNormalMessage = false)
        {
            if (isNormalMessage)
            {
                return channel.SendMessageToChannel(fullMessage.Description ?? fullMessage.Title ?? throw new ArgumentNullException(nameof(fullMessage),"If isNormalMessage is set to true, fullMessage must have Title or Description"));
            }
            var msg = EmbedService.GenerateEmbedAndComponentsMessage(fullMessage);
            return channel.SendMessageAsync(embed: msg.Embed, components: msg.Component);
        }
    }
}
