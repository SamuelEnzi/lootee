using Lootee_Console.Commands.Interface;
using Lootee_Console.Utils;
using System.Reflection;

namespace Lootee_Console
{
    public class CommandHandler : Singleton<CommandHandler>
    {
        private readonly List<ICommand> commands = new();

        private CommandHandler()
        {
            var typeList = GetCommands("Lootee_Console.Commands");
            foreach(var type in typeList)
                commands.Add((ICommand) Activator.CreateInstance(type)!);
        }


        public bool TryExecuteCommand(string[] input)
        {
            if(input.Length <= 0)
                return false;

            var command = commands.Find(x =>
                string.Equals(x.Command, input[0], StringComparison.InvariantCultureIgnoreCase));

            if(command == null)
                return false;

            var arguments = input.Skip(1).ToArray();
            if(arguments.Length > command.MaxArgs && arguments.Length < command.MinArgs)
                return false;

            return command.Execute(arguments);
        }


        private IEnumerable<Type> GetCommands(string @namespace) =>
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => string.Equals(x.Namespace, @namespace, StringComparison.Ordinal));

    }
}
