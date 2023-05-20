using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Game.Api;

namespace DiscordBot.Api.GameCommands
{
    public class GameHostedJob : IHostedService, IDisposable
    {
        private int executionCount = 0;
        //private readonly ILogger<GameHostedJob> _logger;
        private Timer? _timer = null;

        public GameHostedJob()
        {
            //_logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
           // _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);

            return Task.CompletedTask;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void DoWork(object? state)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var count = Interlocked.Increment(ref executionCount);

           // _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);
            GameManager.Launch();
            GameManager.LaunchBackgroundLoop();
        }

        public Task PlayGame(ulong userId, string commandName, Func<string, Task> sendMessagePrivate, Func<string, Task> sendMessagePublic)
        {
            GameManager.SetupMessage(userId, sendMessagePrivate, sendMessagePublic);
            GameManager.Play(userId, commandName);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
           // _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
