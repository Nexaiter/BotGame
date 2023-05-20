using Game.Api.Players;
using System.Collections.Concurrent;
using System.Reflection;

namespace Game.Api
{
    internal sealed class Game
    {
        public ConcurrentDictionary<ulong, PlayerProfile> Players { get; } = new();
        private Game()
        {
          //  LoadAllCharacters.Load(Players);
        }
        private static Game? _instance;
        public static Game GetInstance() => _instance ??= new Game();
        public static void GameLoop(ulong userId, string commandName)
        {
            var players = GetInstance().Players;

            if (!Register.IsPlayerRegister(userId, players))
            {
                Register.RegisterNewPlayer(userId, commandName, players);
                return;
            }

           // Commands.Init(players[userId], commandName, players);

        }
        public static async void BackgroundEventHandling()
        {
            while (true)
            {
                var players = GetInstance().Players;
                foreach (var character in players.Values)
                {
                //    Adventure.Handling(character);
                //    Fishing.Handling(character);
                //    SaveAllCharacters.Save(players);
                //      ArenaManager.Handling(players);
                }
               
            }
        }
    }
}