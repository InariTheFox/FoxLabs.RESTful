namespace FoxLabs.RESTFul.Metadata
{
    public interface ITypeMetadata
    {
        string FullName { get; }

        bool HasNoIdentity { get; }

        bool IsAbstract { get; }

        bool IsAggregated { get; }

        bool IsCollection { get; }

        bool IsInterface { get; }

        bool IsStatic { get; }

        bool IsVoid { get; }

        string PluralName { get; }

        IPropertyMetadata[] Properties { get; }

        string ShortName { get; }

        string SingularName { get; }

        string UntitledName { get; }

        bool IsOfType(ITypeMetadata other);

        IActionMetadata[] GetActions();
        
        IActionMetadata? GetAction(string name);
        
        IPropertyMetadata? GetProperty(string name);
    }
}