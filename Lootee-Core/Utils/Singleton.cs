using System.Reflection;

namespace Lootee_Console.Utils
{
    public abstract class Singleton<T> where T : class
    {
        private static T? instance;
        public static T Instance => instance ??= CreateInstance();

        private static T CreateInstance()
        {
            var constructors = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            return (T) constructors.Single().Invoke(null);
        }
    }
}
