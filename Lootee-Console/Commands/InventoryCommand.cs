using Lootee_Console.Commands.Interface;

namespace Lootee_Console.Commands
{
    public class InventoryCommand : ICommand
    {
        public string Command => "inventory";
        public int MinArgs => 0;
        public int MaxArgs => 1;


        public bool Execute(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("User inventory...");
                return true;
            }

            if(args.Length == 1)
            {
                Console.WriteLine($"Inventory from: {args[0]}");
                return true;
            }

            return false;
        }
    }
}
