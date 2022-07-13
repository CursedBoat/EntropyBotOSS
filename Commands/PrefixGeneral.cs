using Discord.Commands;
using Discord;

namespace Entropy.Commands{
    public class PrefixGeneral:ModuleBase<SocketCommandContext>{
        [Command("sex")]
        public async Task Pong(){
            await Context.Message.ReplyAsync("https://media.discordapp.net/attachments/973264581466132580/995613907005751386/shutthefuckup.gif");
        }
    }
}