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

        public static void SetupMessage(ulong userId, Func<string, Task> sendMessagePrivate, Func<string, Task> sendMessagePublic)
        {
            Message.Setup(userId, sendMessagePrivate, sendMessagePublic);
        }
        public static void Play(ulong userId, string commandName)
        {
            Game.GameLoop(userId, commandName);
        }
    }
}
