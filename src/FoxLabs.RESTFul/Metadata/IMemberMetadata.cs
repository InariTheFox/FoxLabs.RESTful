namespace FoxLabs.RESTFul.Metadata
{
    public interface IMemberMetadata
    {
        ITypeMetadata ElementType { get; }

        bool IsNullable { get; }

        string Name { get; }

        ITypeMetadata Owner { get; }

        ITypeMetadata ReturnType { get; }
    }
}