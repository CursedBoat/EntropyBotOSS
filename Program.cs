using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;

namespace Entropy{
    public class Program{
        public static Task Main() => new Program().MainAsync();

        public async Task MainAsync(){
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                services.AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig
                {
                    GatewayIntents = GatewayIntents.AllUnprivileged,
                    AlwaysDownloadUsers = true
                })))
                .Build();
            await RunAsync(host);
        }

        public async Task RunAsync(IHost host){
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var _client = provider.GetRequiredService<DiscordSocketClient>();

            //Logging if it's ready on console
            _client.Log += async(LogMessage msg) => { Console.WriteLine(msg.Message); };
            _client.Ready += async() => { Console.WriteLine("Bot's ready shitter"); };

            await _client.LoginAsync(TokenType.Bot, Config.token);
            await _client.StartAsync();

            

            await Task.Delay(-1); //sex
        }
    }
}