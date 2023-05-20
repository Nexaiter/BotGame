namespace Game.Api
{
    internal sealed class Message
    {
        private readonly Dictionary<ulong, Func<string, Task>> _sendMessagePrivate = new();
        private Func<string, Task> _sendMessagePublic;
        private Message(ulong userId, Func<string, Task> sendMessagePrivate, Func<string, Task> sendMessagePublic)
        {
            _sendMessagePrivate.Add(userId, sendMessagePrivate);
            _sendMessagePublic = sendMessagePublic;
        }

        private static Message? _instance;
        public static Message GetInstance() => _instance ??= new Message(0, null, null);
        public static Message Setup(ulong userId, Func<string, Task> sendMessagePrivate, Func<string, Task> sendMessagePublic)
        {
            if (_instance is null)
            {
                return _instance = new Message(userId, sendMessagePrivate, sendMessagePublic);
            }
            if (!GetInstance()._sendMessagePrivate.ContainsKey(userId))
            {
                GetInstance()._sendMessagePrivate.Add(userId, sendMessagePrivate);
            }
            GetInstance()._sendMessagePublic = sendMessagePublic;
            return GetInstance();
        }

        public static void Private(ulong userId, string text)
        {
           GetInstance()._sendMessagePrivate[userId](text);
           // GetInstance()._sendMessagePublic(text);
        }

        public static void Public(string text)
        {
            GetInstance()._sendMessagePublic(text);
        }
    }
}