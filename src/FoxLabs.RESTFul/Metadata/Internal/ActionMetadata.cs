using FoxLabs.RESTFul.Adapter;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class ActionMetadata : IActionMetadata
    {
        public ITypeMetadata ElementType { get; }

        public bool IsNullable { get; }

        public string Name { get; }

        public ITypeMetadata Owner { get; }

        public ITypeMetadata ReturnType { get; }

        public bool HasReturn { get; }

        public bool IsStatic { get; }

        public int ParameterCount { get; }

        public IActionParameterMetadata[] Parameters { get; }

        public IObjectAdapter Execute(IObjectAdapter target, IObjectAdapter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}