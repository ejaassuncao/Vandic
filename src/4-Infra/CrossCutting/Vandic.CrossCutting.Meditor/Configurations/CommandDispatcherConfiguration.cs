using System.Reflection;

namespace Vandic.CrossCutting.Meditor.Configurations
{
    public class CommandDispatcherConfiguration
    {
        internal List<Assembly> AssembliesToRegister { get; } = new List<Assembly>();

        public CommandDispatcherConfiguration RegisterServicesFromAssembly(Assembly assembly)
        {
            AssembliesToRegister.Add(assembly);
            return this;
        }
    }
}
