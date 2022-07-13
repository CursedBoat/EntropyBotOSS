using Discord.Commands;
using Discord;
using Discord.WebSocket;
using static System.Linq.Enumerable;

namespace Entropy.Commands{
    public class PrefixGeneral:ModuleBase<SocketCommandContext>{
        [Command("ping")]
        [Alias("Sex", "sex", "Ping")]
        public async Task Pong(){
            await Context.Message.ReplyAsync("https://media.discordapp.net/attachments/973264581466132580/995613907005751386/shutthefuckup.gif");
        }

        [Command("spank")]
        [Alias("Spank")]
        public async Task Spank(SocketGuildUser user=null){
            if (user != null){
                try{
                    await Context.Message.ReplyAsync($"You spanked <@{user.Id}> :weary:");
                }
                catch(Exception ex){
                    var embed = new EmbedBuilder()
                        .WithTitle("An error occured")
                        .AddField("Error message", ex, true)
                        .Build();
                    
                    await Context.Message.ReplyAsync(embed: embed);
                }
            }
            else{
                await Context.Message.ReplyAsync("Mention a user dimwit");
            }
        }

        [Command("code")]
        [Alias("Code", "github", "wowthisbotisverygoodhowdoicontribute")]
        public async Task WowThisBotIsVeryGoodHowDoIContribute(){
            var embed = new EmbedBuilder()
                    .WithTitle("GitHub")
                    .WithDescription("The Open-Source repository of this bot can be found in the given link below :D")
                    .AddField("Link", "https://github.com/CursedBoat/EntropyBotOSS", false)
                    .Build();
            
            await Context.Message.ReplyAsync(embed: embed);
        }

        //Very spaghetti help command. Will improve in the future
        [Command("Help")]
        [Alias("help", "info", "commands")]
        public async Task Help(params string[] cmd){
            string[] help = Entropy.Modules.CommandDB._commands;
            string type = "";

            if (2 <= cmd.Length){ type = cmd[1]; }
            else { type = "info"; }

            if (cmd.Length == 0)
            {
                int n = help.Count();
                int _n = 0;
                string _response = "";

                foreach (var i in Enumerable.Range(0, n))
                {
                    string response = Modules.CommandDB.Commands(_n);
                    string newResponse = $"``{response}`` ";
                    _response = _response + newResponse;
                    _n ++;
                }

                var embed = new EmbedBuilder()
                    .WithTitle("Index of commands.")
                    .AddField("Do ``e!help <command>`` to recieve info about a specific command (case sensitive)", _response, true)
                    .WithFooter("Go get some help")
                    .Build();

                await Context.Message.ReplyAsync(embed: embed);
            }
            else
            {
                string cmdUsage = Modules.CommandDB.GetCommandInfo(cmd[0], "usage");
                string cmdExample = Modules.CommandDB.GetCommandInfo(cmd[0], "example");
                string cmdInfo = Modules.CommandDB.GetCommandInfo(cmd[0], "info");
                string cmdAliases = Modules.CommandDB.GetCommandInfo(cmd[0], "aliases");

                var embed = new EmbedBuilder()
                    .WithTitle("Command info")
                    .WithDescription("Displaying useful info regarding the command")
                    .AddField("Usage: ", cmdUsage, false)
                    .AddField("Example: ", cmdExample, false)
                    .AddField("Info: ", cmdInfo, false)
                    .AddField("Aliases: ", cmdAliases, false)
                    .Build();
                await Context.Message.ReplyAsync(embed: embed);
            }
        }
    }
}