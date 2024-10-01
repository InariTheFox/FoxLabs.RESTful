using System.Reflection;
using FoxLabs.RESTFul.Adapter;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class PropertyMetadata : IPropertyMetadata
    {
        public PropertyMetadata(string name, PropertyInfo? propertyInfo, FieldInfo? fieldInfo, TypeBaseMetadata declaringType)
        {
            Builder = new(this, declaringType.Model.Builder);

            Name = name;
            ReturnType = declaringType.Model.FindType(propertyInfo.PropertyType)
                            ?? declaringType.Model.AddType(propertyInfo.PropertyType);
        }

        public PropertyBuilder Builder { get; }

        public ITypeMetadata ElementType { get; }

        public bool IsNullable { get; }

        public string Name { get; }

        public ITypeMetadata Owner { get; }

        public ITypeMetadata ReturnType { get; }

        public bool IsReadOnly { get; }

        public IObjectAdapter GetObject(IObjectAdapter target)
        {
            throw new NotImplementedException();
        }
    }
}