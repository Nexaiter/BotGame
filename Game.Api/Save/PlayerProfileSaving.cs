using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game.Api.Players;

namespace Game.Api.Save
{
    internal static class PlayerProfileSaving
    {
        private static readonly string Path = "Players/PlayerList.json";
        public static void Save(PlayerProfile playerProfile)
        {
            string jsonString = JsonSerializer.Serialize(playerProfile);
            File.WriteAllText(Path, jsonString);
            
        }

    }
}
