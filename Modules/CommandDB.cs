//Command database
namespace Entropy.Modules{
    class CommandDB{
        //Command index
        public static string[] _commands = {"Sex", "Help", "Spank", "Code"};
        public static string Commands(int index){
            try{
                string[] commands = _commands;
                return commands[index];
            }
            catch(Exception ex){
                return ex.Message;
            }
        }

        //Command info starts here
        public static string GetCommandInfo(string cmd, string type){
            //Alias documenting
            if (cmd == "ping" || cmd == "sex") { cmd = "sex"; }
            if (cmd == "info" || cmd == "commands" || cmd == "help") { cmd = "help"; }
            if (cmd == "code" || cmd == "github" || cmd == "wowthisbotisverygoodhowdoicontribute") { cmd = "github"; }

            switch (cmd)
            {
                //Start documenting command info here.
                case "sex":
                    if (type == "usage"){ return "e!sex"; }
                    else if (type == "example") { return "e!sex"; }
                    else if (type == "info") { return "You get... sex?"; }
                    else if (type == "aliases") { return "sex, ping"; }
                    else { return "Invalid argument."; }
                case "help":
                    if (type == "usage"){ return "e!help"; }
                    else if (type == "example") { return "e!help help example"; }
                    else if (type == "info") { return "...what do you think it does"; }
                    else if (type == "aliases") { return "help, commands, info"; }
                    else { return "Invalid argument."; }
                case "spank":
                    if (type == "usage"){ return "e!spank"; }
                    else if (type == "example") { return "e!spank @realixe"; }
                    else if (type == "info") { return "Spank the user! :weary:"; }
                    else if (type == "aliases") { return "none"; }
                    else { return "Invalid argument."; }
                case "github":
                    if (type == "usage"){ return "e!github"; }
                    else if (type == "example") { return "e!github thanks snth for the wonderful bot i love you please marry me"; }
                    else if (type == "info") { return ":smirk: get contributin'"; }
                    else if (type == "aliases") { return "code, github, wowthisbotisverygoodhowdoicontribute"; }
                    else { return "Invalid argument."; }             
            }
            return "Invalid command"; // Dummy return path
        }
    }
}