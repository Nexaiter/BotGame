using Game.Api.Common;

namespace Game.Api
{
    internal sealed class Message
    {
        private readonly Dictionary<ulong, Func<FullMessage, bool, Task>> _sendMessagePrivate = new();
        private Func<FullMessage, bool, Task> _sendMessagePublic;
        private Message(ulong userId, Func<FullMessage, bool, Task> sendMessagePrivate, Func<FullMessage, bool, Task> sendMessagePublic)
        {
            _sendMessagePrivate.Add(userId, sendMessagePrivate);
            _sendMessagePublic = sendMessagePublic;
        }

        private static Message? _instance;
        public static Message GetInstance() => _instance ??= new Message(0, null, null);
        public static Message Setup(ulong userId, Func<FullMessage, bool, Task> sendMessagePrivate, Func<FullMessage, bool, Task> sendMessagePublic)
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

        public static void SendPrivateMessage(ulong userId, string text)
        {
           GetInstance()._sendMessagePrivate[userId](new FullMessage(text), true);
        }

        public static void SendPublicMessage(string text)
        {
            GetInstance()._sendMessagePublic(new FullMessage(text), true);
        }
        public static void SendPrivateEmbedMessage(ulong userId, FullMessage msg)
        {
            GetInstance()._sendMessagePrivate[userId](msg, false);
        }

        public static void SendPublicEmbedMessage(ulong userId, FullMessage msg)
        {
            GetInstance()._sendMessagePrivate[userId](msg, false);
        }
    }
}