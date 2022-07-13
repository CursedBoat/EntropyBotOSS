using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Discord.Interactions;
using Discord.Commands;

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
                }))
                .AddSingleton(x => new InteractionService( x.GetRequiredService<DiscordSocketClient>() ) )
                .AddSingleton<InteractionHandler>()
                .AddSingleton(x => new CommandService() )
                .AddSingleton<PrefixHandler>()
                )
                .Build();
            await RunAsync(host);
        }

        public async Task RunAsync(IHost host){
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            
                      
            var commands = provider.GetRequiredService<InteractionService>();
            var _client = provider.GetRequiredService<DiscordSocketClient>();
            var sCommands = provider.GetRequiredService<InteractionService>();
            await provider.GetRequiredService<InteractionHandler>().InitializeAsync();
            var pCommands = provider.GetRequiredService<PrefixHandler>();            
            pCommands.AddModule<Entropy.Commands.PrefixGeneral>();
            await pCommands.InitializeAsync();
            

            //Logging if it's ready on console
            _client.Log += async(LogMessage msg) => { Console.WriteLine(msg.Message); };
            _client.Ready += async() => { 
                Console.WriteLine("Bot's ready shitter"); 
                await sCommands.RegisterCommandsGloballyAsync();
                };

            await _client.LoginAsync(TokenType.Bot, Config.token);
            //await _client.LoginAsync(TokenType.Bot, Config.testToken2); //Just for testing purposes, don't pay attention to this
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}