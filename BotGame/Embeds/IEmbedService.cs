using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Api.Embeds
{
    public interface IEmbedService
    {
        Embed GenerateEmbedMessage(SocketCommandContext context, string title, string message);
    }
}
