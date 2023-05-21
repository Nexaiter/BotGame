using Game.Api.Common;

namespace Game.Api
{
    public static class GameManager
    {
        public static void Launch()
        {
            Game.GetInstance();
        }
        public static async void LaunchBackgroundLoop()
        {
            Game.BackgroundEventHandling();
        }

        public static void SetupMessage(ulong userId, Func<FullMessage, bool, Task> sendMessagePrivate, Func<FullMessage, bool, Task> sendMessagePublic)
        {
            Message.Setup(userId, sendMessagePrivate, sendMessagePublic);
        }
        public static void Play(ulong userId, string commandName)
        {
            Game.GameLoop(userId, commandName);
        }
        public static void PlayWithButton(ulong userId, string buttonName, Func<FullMessage, Task> updateMessage)
        {
            throw new NotImplementedException();
        }
        public static void PlayWithSelectMenu(ulong userId, string optionName, Func<FullMessage, Task> updateMessage)
        {
            throw new NotImplementedException();
        }
    }
}
