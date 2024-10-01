using System.Reflection;
using FoxLabs.RESTFul.Adapter;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class ActionMetadata : IActionMetadata
    {
        public ActionMetadata(string name, MethodInfo methodInfo, TypeBaseMetadata declaringType)
        {
            Builder = new ActionBuilder(this, declaringType.Model.Builder);

            Name = name;
            ReturnType = declaringType.Model.FindType(methodInfo.ReturnType);
        }

        public ActionBuilder Builder { get; }

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