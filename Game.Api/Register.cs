using Game.Api.Players;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Concurrent;
using Game.Api.Save;

namespace Game.Api
{
    internal static class Register
    {

        public static void RegisterNewPlayer(ulong userId, string command, ConcurrentDictionary<ulong, PlayerProfile> players)
        {
            if(!command.Contains("register "))
            {
                Message.Private(userId, "register using register playername command");
                return;
            }
            string name = command.Replace("register ", "");

            if(!NicknameValidator(name))
            {
                Message.Private(userId, "use of incorrect signs");
                return;
            }

            if (TooLongName(name))
            {
                Message.Private(userId, "Name too long");
                return;
            }

            if (TooShortName(name))
            {
                Message.Private(userId, "Name too short.");
                return;
            }

            name = FixSpacesInName(name);

            if (IsNameRegister(name, players, out _))
            {
                Message.Private(userId, "name already taken");
                return;
            }

            var playerProfile = new PlayerProfile(userId);
            players.TryAdd(userId, playerProfile);
            players[userId].ChangeName(name);
            PlayerProfileSaving.Save(playerProfile); 
        
        }

        public static bool IsPlayerRegister(ulong userId, ConcurrentDictionary<ulong, PlayerProfile> players)
        {
            foreach (var key in players.Keys)
            {
                if (key == userId)
                    return true;
            }
            return false;
        }
        public static bool IsNameRegister(string name, ConcurrentDictionary<ulong, PlayerProfile> players, out PlayerProfile? character)
        {
            foreach (var player in players)
            {
                if (player.Value.Name == name)
                {
                    character = player.Value;
                    return true;
                }
            }
            character = default;
            return false;
        }

        private static bool NicknameValidator(string stringToCheck)
        {
            var wantedCharsPattern = new Regex("^[a-zA-Z żźćńółęąśŻŹĆĄŚĘŁÓŃ]+$");
            return wantedCharsPattern.IsMatch(stringToCheck);
        }
        private static bool TooLongName(string name)
        {
            return name.Length >= 20;
        }
        private static bool TooShortName(string name)
        {
            return name.Length <= 2;
        }
        private static string FixSpacesInName(string name)
        {
            while (name.Contains("  "))
            {
                name = name.Replace("  ", " ");
            }

            if (name.EndsWith(' '))
                name = name.Remove(name.Length, 1);

            if (name.StartsWith(' '))
                name = name.Remove(0, 1);

            return name;
        }



    }
}