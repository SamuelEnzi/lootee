using Lootee_Core.Models;

var username = "peter";
var password = "password";

var user = await User.Login(username, password);
await user!.Update();
Console.WriteLine(Lootee_Core.Globals.Token);
Console.WriteLine(Lootee_Core.Globals.BaseUrl);
