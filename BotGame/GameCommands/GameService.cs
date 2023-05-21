using DiscordBot.Api.Extensions;
using Discord;
using Discord.Commands;

namespace DiscordBot.Api.GameCommands
{
    public class GameService : IGameService
    {
        private readonly GameHostedJob _gameHostedService;

        public GameService(GameHostedJob GameHostedService)
        {
            _gameHostedService = GameHostedService;
        }
        public async Task Play(ICommandContext Context, bool isTest = false)
        {
            const ulong serverID = 695291513541754990;
            const ulong infoChannelId = 1108343306619977809;
            var guild = await Context.Client.GetGuildAsync(serverID);
            //var user = await guild.GetUserAsync(Context.Message.Author.Id);
            //if (user is null)
            //{
            //    await Context.Channel.SendMessageToChannel("Nie przyjmujemy osób z zewnątrz, idź stąd!");
            //    return;
            //}
            var channel = (IMessageChannel)await (await Context.Client.GetGuildAsync(serverID)).GetChannelAsync(infoChannelId);
            var authorId = isTest ? ulong.Parse(Context.Message.Content.Split(' ').First()) : Context.Message.Author.Id;
            var message = isTest ? string.Join(' ', Context.Message.Content.Split(' ').Skip(1)) : Context.Message.Content;

            await _gameHostedService.PlayGame(authorId, message!, Context.Channel.SendMessageToChannel, channel.SendMessageToChannel);
        }
    }
}
