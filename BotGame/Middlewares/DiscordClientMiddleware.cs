using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Api.Embeds;
using DiscordBot.Api.GameCommands;
using DiscordBot.Api.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DiscordBot.Api.Middlewares
{
    internal sealed class DiscordClientMiddleware : DiscordClientService
    {
        private readonly IGameService _procekGameService;
        private readonly IServiceProvider _provider;
        private readonly CommandService _commandService;
        private readonly string _prefix;
        private readonly bool _isTest;

        public DiscordClientMiddleware(IGameService procekGameService, DiscordSocketClient client, ILogger<DiscordClientService> logger, IServiceProvider provider, CommandService commandService, IConfiguration config) : base(client, logger)
        {
            _procekGameService = procekGameService;
            _provider = provider;
            _commandService = commandService;
            _prefix = config["Prefix"];
            _isTest = bool.Parse(config["IsTest"]);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Client.MessageReceived += MessageReceivedEventHandler;
            //Client.UserJoined += UserJoinEventHandler;
            //Client.MessageDeleted += MessageDeletedEventHandler;
            //Client.MessageUpdated += MessageUpdatedEventHandler;
            _commandService.CommandExecuted += CommandExecutedEventHandler;
            Client.ButtonExecuted += EventButtonHandler;

            return InjectDependencyToCommandModules();
        }

        private Task<IEnumerable<ModuleInfo>> InjectDependencyToCommandModules()
        => _commandService.AddModulesAsync(typeof(DiscordBotApiModule).Assembly, _provider);

        private Task MessageUpdatedEventHandler(Cacheable<IMessage, ulong> arg1, SocketMessage arg2, ISocketMessageChannel arg3)
        {
            throw new NotImplementedException();
        }

        private Task MessageDeletedEventHandler(Cacheable<IMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2)
        {
            throw new NotImplementedException();
        }

        private Task UserJoinEventHandler(SocketGuildUser guildUser)
        {
            throw new NotImplementedException();
        }

        private Task CommandExecutedEventHandler(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
        => result switch
        {
            { IsSuccess: true } => Task.CompletedTask,
            _ when result.Error == CommandError.UnknownCommand && commandContext.Guild is null => _procekGameService.Play(commandContext, _isTest),
            _ when result.Error == CommandError.UnknownCommand => Task.CompletedTask,
            _ => commandContext.Channel.SendMessageAsync(result.ErrorReason)
        };

        private Task MessageReceivedEventHandler(SocketMessage socketMessage)
        {

            if (socketMessage is SocketUserMessage msg &&
                socketMessage.Source is MessageSource.User && socketMessage.Channel is SocketDMChannel)
            {
                var context = new SocketCommandContext(Client, msg);
                return _commandService.ExecuteAsync(context, 0, _provider);
            }

            //var argPos = 0;
            //if (socketMessage is SocketUserMessage message && socketMessage.Source is MessageSource.User
            //    && (message.HasStringPrefix(_prefix, ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            //    && message.Content.Length > 1)
            //{
            //    var context = new SocketCommandContext(Client, message);
            //    return _commandService.ExecuteAsync(context, argPos, _provider);
            //}
            return Task.CompletedTask;
        }
        public async Task EventButtonHandler(SocketMessageComponent component)
        {

            switch (component.Data.CustomId)
            {

                case "AdventurerList":

                    await AdventurerListButtonCommand(component);
                    break;
            }
        }

        public async Task AdventurerListButtonCommand(SocketMessageComponent component)
        {
            var embed = component.Message.Embeds.First();

            var builder = EmbedService.Clone(embed);

            builder.Description = "after button";


            await component.UpdateAsync(x => x.Embed = builder.Build());


        }
    }
}
