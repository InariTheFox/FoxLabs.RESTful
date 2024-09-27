using System.Reflection;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class TypeMetadata : TypeBaseMetadata, ITypeMetadata
    {
        public TypeMetadata(string name, Model model)
            : base(name, model)
        {
        }

        public TypeMetadata(Type type, Model model)
            : base(type, model)
        {
            Builder = new(this, model.Builder);
        }

        public TypeBuilder Builder { get; }

        public string FullName { get; }

        public bool HasNoIdentity { get; }

        public bool IsAbstract { get; }

        public bool IsAggregated { get; }

        public bool IsCollection { get; }

        public bool IsInterface { get; }

        public bool IsStatic { get; }

        public bool IsVoid { get; }

        public string PluralName { get; }

        public PropertyMetadata[] Properties { get; }

        public string ShortName { get; }

        public string SingularName { get; }

        public string UntitledName { get; }

        IPropertyMetadata[] ITypeMetadata.Properties
            => Properties;

        public bool IsOfType(ITypeMetadata other)
        {
            throw new NotImplementedException();
        }

        public ActionMetadata[] GetActions()
        {
            throw new NotImplementedException();
        }

        public PropertyMetadata GetProperty(string name)
        {
            throw new NotImplementedException();
        }

        internal PropertyMetadata AddProperty(string propertyName, Type propertyType, MemberInfo memberInfo)
        {
            throw new NotImplementedException();
        }

        IActionMetadata[] ITypeMetadata.GetActions()
            => GetActions();

        IPropertyMetadata ITypeMetadata.GetProperty(string name)
            => GetProperty(name);
    }
}