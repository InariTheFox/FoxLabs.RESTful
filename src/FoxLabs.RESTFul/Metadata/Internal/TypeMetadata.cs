using System.Reflection;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class TypeMetadata : TypeBaseMetadata, ITypeMetadata
    {
        private SortedList<string, ActionMetadata> _actions = new(StringComparer.Ordinal);
        private SortedList<string, PropertyMetadata> _properties = new(StringComparer.InvariantCulture);

        public TypeMetadata(string name, Model model)
            : base(name, model)
        {
            Builder = new(this, model.Builder);
            FullName = name;
            ShortName = name;
        }

        public TypeMetadata(Type type, Model model)
            : base(type, model)
        {
            Builder = new(this, model.Builder);
            FullName = type.FullName;
            ShortName = type.Name;
        }

        public TypeBuilder Builder { get; }

        public string FullName { get; }

        public bool HasNoIdentity { get; internal set; }

        public bool IsAbstract { get; internal set; }

        public bool IsAggregated { get; internal set; }

        public bool IsCollection { get; internal set; }

        public bool IsInterface { get; internal set; }

        public bool IsStatic { get; internal set; }

        public bool IsVoid { get; internal set; }

        public string PluralName { get; internal set; }

        public new PropertyMetadata[] Properties
            => _properties.Values.ToArray();

        public string ShortName { get; internal set; }

        public string SingularName { get; internal set; }

        public string UntitledName { get; internal set; }

        IPropertyMetadata[] ITypeMetadata.Properties
            => Properties;

        public bool IsOfType(ITypeMetadata other)
        {
            throw new NotImplementedException();
        }

        public ActionMetadata[] GetActions()
        {
            return _actions.Values.ToArray();
        }

        public ActionMetadata? GetAction(string name)
        {
            _actions.TryGetValue(name, out var action);

            return action;
        }

        public PropertyMetadata? GetProperty(string name)
        {
            _properties.TryGetValue(name, out var property);

            return property;
        }

        internal ActionMetadata AddAction(string actionName, Type returnType, MemberInfo memberInfo)
        {
            if (_actions.ContainsKey(actionName))
            {
                throw new ArgumentException($"Action {actionName} is already added.");
            }
            
            var methodInfo = memberInfo as MethodInfo;
            
            var action = new ActionMetadata(actionName, methodInfo, this);

            _actions.Add(actionName, action);

            return action;
        }

        internal PropertyMetadata AddProperty(string propertyName, Type propertyType, MemberInfo memberInfo)
        {
            if (_properties.ContainsKey(propertyName))
            {
                throw new ArgumentException($"Property {propertyName} is already added.");
            }
            
            var propertyInfo = memberInfo as PropertyInfo;
            var fieldInfo = memberInfo as FieldInfo;

            var property = new PropertyMetadata(propertyName, propertyInfo, fieldInfo, this);

            _properties.Add(propertyName, property);
            
            return property;
        }

        IActionMetadata[] ITypeMetadata.GetActions()
            => GetActions();

        IActionMetadata ITypeMetadata.GetAction(string name)
            => GetAction(name);
        
        IPropertyMetadata ITypeMetadata.GetProperty(string name)
            => GetProperty(name);
    }
}