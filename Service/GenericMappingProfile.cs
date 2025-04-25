using AutoMapper;
using Service.Contracts;
using System.Reflection;

namespace dentistry_crm
{
    public class GenericMappingProfile : Profile
    {
        public GenericMappingProfile()
        {
            // Load all assemblies in the current AppDomain
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .ToList();

            foreach (var assembly in assemblies)
            {
                ApplyMappingsFromAssembly(assembly);
            }
        }
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var method = type.GetMethod("Mapping") ??
                             type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

                method?.Invoke(instance, new object[] { this });

                // Optional: log mappings for verification
                 Console.WriteLine($"✅ Mapping registered for: {type.FullName}");
            }
        }
    }
}
