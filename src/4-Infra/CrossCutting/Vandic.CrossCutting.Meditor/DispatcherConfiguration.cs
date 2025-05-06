using System.Reflection;

namespace Vandic.CrossCutting.Meditor
{
    public class DispatcherConfiguration
    {
        internal List<Assembly> AssembliesToRegister { get; } = new List<Assembly>();

        public DispatcherConfiguration RegisterServicesFromAssembly(Assembly assembly)
        {
            AssembliesToRegister.Add(assembly);
            return this;
        }
    }
}
