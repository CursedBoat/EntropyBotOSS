using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System.Reflection;
using Discord.Commands;
using Microsoft.Extensions.Configuration;

namespace Entropy{
    public class PrefixHandler{
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public PrefixHandler(DiscordSocketClient client, CommandService commands){
            _client = client;
            _commands = commands;
        }

        public async Task InitializeAsync(){
            _client.MessageReceived += HandleCommandAsync;
        }

        public void AddModule<T>(){
            _commands.AddModuleAsync<T>(null);
        }

        public async Task HandleCommandAsync(SocketMessage messageParam){
            var message = messageParam as SocketUserMessage; // Makes sure that the messages are only user messages
            if (message == null) return;

            int argPos = 0;
            // I sincerely apologise to anyone reading the code
            if (!(message.HasStringPrefix(Config.prefix, ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;
            
            var context = new SocketCommandContext(_client, message);

            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
            

        }
    }
}