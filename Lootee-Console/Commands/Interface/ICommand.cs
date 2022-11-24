
namespace Lootee_Console.Commands.Interface
{
    public interface ICommand
    {
        public string Command { get; }
        public int MinArgs { get; }
        public int MaxArgs { get; }


        bool Execute(string[] args);

    }
}
