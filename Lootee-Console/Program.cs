using Lootee_Console;
using Lootee_Core;
using Lootee_Core.Models;


var username = "peter";
var password = "password";

var user = await User.Login(username, password);
await user!.Update();

Console.WriteLine(Globals.Token);
Console.WriteLine(Globals.BaseUrl);


var commandHandler = CommandHandler.Instance;

while(true)
{
    var input = Console.ReadLine();

    if(!string.IsNullOrWhiteSpace(input))
    {
        var splittedinput = input.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        commandHandler.TryExecuteCommand(splittedinput);
    }

}