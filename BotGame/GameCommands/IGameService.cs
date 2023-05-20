using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Api.GameCommands
{
    public interface IGameService
    {
        Task Play(ICommandContext Context, bool isTest = false);
    }
}
