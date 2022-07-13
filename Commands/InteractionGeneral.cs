using Discord.Interactions;
using Discord;

namespace Entropy.Commands{
    public class InteractionGeneral:InteractionModuleBase<SocketInteractionContext>{
        [SlashCommand("sex", "You get... sex?")]
        public async Task HandleSexCommand(){
            await RespondAsync("https://cdn.discordapp.com/attachments/973264581466132580/995613907005751386/shutthefuckup.gif");
        }
    }
}